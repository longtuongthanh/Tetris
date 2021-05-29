using System;

namespace GameCore
{
	public class LambdaJob : Job
	{
		private Action _action;

		public LambdaJob(Action action) => _action = action;

		protected override void Execute()
		{
			_action?.Invoke();
		}
	}
}