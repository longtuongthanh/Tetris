using System.Collections;
using UnityEngine;

namespace GameCore
{
	public abstract class CoroutineJob : Job
	{
		protected override bool FinishAfterExecution => false;

		protected override void Execute()
		{
			Runner.StartCoroutine(ExecuteWrapper());
		}

		private IEnumerator ExecuteWrapper()
		{
			yield return ExecuteCoroutine();
			Finish();
		}

		protected abstract IEnumerator ExecuteCoroutine();
	}

	public class FuncCoroutineJob : CoroutineJob
	{
		protected override bool FinishAfterExecution => false;
		private IEnumerator _func;
		private YieldInstruction _yieldInstruction;

		public FuncCoroutineJob(IEnumerator func) => _func = func;
		public FuncCoroutineJob(YieldInstruction yieldInstruction) => _yieldInstruction = yieldInstruction;

		protected override IEnumerator ExecuteCoroutine()
		{
			if (_func != null)
				yield return _func;

			if (_yieldInstruction != null)
				yield return _yieldInstruction;
		}
	}
}