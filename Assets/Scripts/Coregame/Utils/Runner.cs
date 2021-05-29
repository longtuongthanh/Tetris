using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
	public static class Runner
	{
		private class CoroutineRunner : MonoBehaviour
		{
			public Action OnUpdate = default;
			public Action OnLateUpdate = default;
			public Action OnAppPause = default;
			public Action OnAppResume = default;

			private void OnApplicationPause(bool pauseStatus)
			{
				if (pauseStatus) OnAppPause?.Invoke();
				else OnAppResume?.Invoke();
			}

			private void Update()
			{
				OnUpdate?.Invoke();
			}

			private void LateUpdate()
			{
				OnLateUpdate?.Invoke();
			}
		}

		public static Action OnAppPause = default;
		public static Action OnAppResume = default;

		static CoroutineRunner _coroutineRunner;
		static List<Action> _mainThreadActionQueue = new List<Action>();
		static List<Action> _updateActionQueue = new List<Action>();
		static List<Action> _lateUpdateActionQueue = new List<Action>();
		static readonly object _lockCall = new object();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void InitRunner()
		{
			GameObject go = new GameObject("_Runner");
			_coroutineRunner = go.AddComponent<CoroutineRunner>();
			_coroutineRunner.OnUpdate += Update;
			_coroutineRunner.OnLateUpdate += LateUpdate;
			_coroutineRunner.OnAppPause += AppPause;
			_coroutineRunner.OnAppResume += AppResume;
			_coroutineRunner.StartCoroutine(MainThreadUpdater());
			GameObject.DontDestroyOnLoad(_coroutineRunner);
			Debug.Log("Init runnder done");
		}

		public static Coroutine StartCoroutine(IEnumerator coroutine)
		{
			return _coroutineRunner.StartCoroutine(coroutine);
		}

		public static void StopCoroutine(Coroutine coroutine)
		{
			if (coroutine != null)
			{
				_coroutineRunner.StopCoroutine(coroutine);
			}
		}

		public static void CallOnMainThread(Action func)
		{
			if (func == null)
			{
				throw new System.Exception("Function can not be null");
			}

			lock (_lockCall)
			{
				_mainThreadActionQueue.Add(func);
			}
		}

		public static void ScheduleUpdate(Action action)
		{
			_updateActionQueue.Add(action);
		}

		public static void UnscheduleUpdate(Action action)
		{
			_updateActionQueue.Remove(action);
		}

		public static void ScheduleLateUpdate(Action action)
		{
			_lateUpdateActionQueue.Add(action);
		}

		public static void UnscheduleLateUpdate(Action action)
		{
			_lateUpdateActionQueue.Remove(action);
		}

		private static IEnumerator MainThreadUpdater()
		{
			while (true)
			{
				lock (_lockCall)
				{
					if (_mainThreadActionQueue.Count > 0)
					{
						for (int i = 0; i < _mainThreadActionQueue.Count; i++)
						{
							_mainThreadActionQueue[i].Invoke();
						}

						_mainThreadActionQueue.Clear();
					}
				}

				yield return new WaitForEndOfFrame();
			}
		}

		private static void Update()
		{
			for (int i = 0; i < _updateActionQueue.Count; i++)
			{
				_updateActionQueue[i].Invoke();
			}
		}

		private static void LateUpdate()
		{
			for (int i = 0; i < _lateUpdateActionQueue.Count; i++)
			{
				_lateUpdateActionQueue[i].Invoke();
			}
		}

		private static void AppPause()
		{
			OnAppPause?.Invoke();
		}

		private static void AppResume()
		{
			OnAppResume?.Invoke();
		}
	}
}