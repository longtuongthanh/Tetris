using System;
using System.Threading;
using UnityEngine;

namespace GameCore
{
	public abstract class ThreadJob : Job
	{
		readonly object _lockProgress = new object();
		readonly object _lockState = new object();

		protected override bool FinishAfterExecution => false;
		public override float Progress
		{
			get
			{
				lock (_lockProgress)
				{
					return _progress;
				}
			}
			protected set
			{
				lock (_lockProgress)
				{
					_progress = Mathf.Clamp01(value);
					OnProgressed?.Invoke(this, _progress);
				}
			}
		}

		private JobState _state = JobState.Idle;
		public override JobState State
		{
			get
			{
				lock (_lockState)
				{
					return _state;
				}
			}
			protected set
			{
				lock (_lockState)
				{
					_state = value;
				}
			}
		}


		protected override void Execute()
		{
			ThreadPool.QueueUserWorkItem(state => ExecuteWrapper());
		}

		void ExecuteWrapper()
		{
			ExecuteThread();
			Runner.CallOnMainThread(() => Finish());
		}

		protected abstract void ExecuteThread();
	}


	public class LambdaThreadJob : ThreadJob
	{
		Action _action;

		public LambdaThreadJob(Action action) => _action = action;

		protected override void ExecuteThread()
		{
			_action?.Invoke();
		}
	}
}
