using System;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class ActionQueue
	{
		public ActionQueue ()
		{
		}

		public Action CurrentAction { get; private set; } 
	
		public void Enqueue(Action act)
		{
			mQueue.Enqueue(act);
		}

		public void Update(PlayerController player)
		{
			UpdateCurrentAction(player);
			AdvanceToNextActionIfAppropriate(player);
		}

		private void UpdateCurrentAction(PlayerController player)
		{
			if (CurrentAction != null) {
				CurrentAction.Update();
				if (CurrentAction.IsDone) {
					CurrentAction.Stop();
					CurrentAction = null;
				}
			}
		}

		private void AdvanceToNextActionIfAppropriate(PlayerController player)
		{
			if (CurrentAction == null && mQueue.Any()) {
				CurrentAction = mQueue.Dequeue();
				CurrentAction.Begin();
			}
		}

		private Action mCurrentAction;
		private Queue<Action> mQueue = new Queue<Action>();
	}
}

