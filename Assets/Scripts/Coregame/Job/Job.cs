using System;
using UnityEngine;

namespace GameCore
{
	public enum JobState
	{
		Idle,
		Running,
		Finish
	}

	public abstract class Job
	{
		public Action<Job> OnWillStart;
		public Action<Job> OnFinished;
		public Action<Job, float> OnProgressed;

		public virtual float Weight => 1f;
		protected virtual bool FinishAfterExecution => true;

		private float startTime;

		protected float _progress;
		public virtual float Progress
		{
			get => _progress;
			protected set
			{
				_progress = Mathf.Clamp01(value);
				OnProgressed?.Invoke(this, _progress);
			}
		}

		public virtual JobState State { get; protected set; } = JobState.Idle;

		public virtual void Setup(object data)
		{

		}

		public virtual void Run()
		{
			startTime = Time.realtimeSinceStartup;
			if (Debug.isDebugBuild)
				Debug.LogFormat($"[Job] <color=#2e8299>Start <b>{this.GetType().Name}</b>: {Time.realtimeSinceStartup:F2}s</color>");

			State = JobState.Running;
			Progress = 0;
			OnWillStart?.Invoke(this);

			Execute();

			if (FinishAfterExecution)
				Finish();
		}

		protected virtual void Finish()
		{
			Debug.LogFormat($"[Job] <color=#2e9947>Finish <b>{this.GetType().Name}</b>: {Time.realtimeSinceStartup:F2}s - Total: {(Time.realtimeSinceStartup - startTime):F2}</color>");

			State = JobState.Finish;
			Progress = 1;
			OnFinished?.Invoke(this);
		}

		protected abstract void Execute();
	}
}
