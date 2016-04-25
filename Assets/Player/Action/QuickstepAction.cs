using System;
using UnityEngine;

namespace AssemblyCSharp
{
	[CreateAssetMenu(fileName = "QuickstepAction", menuName = "Actions/Quickstep", order = 1)]
	public class QuickstepAction : Action
	{
		public override void Begin()
		{
			base.Begin();
			mStartMovementInput = Player.MovementInput;
			if (mStartMovementInput.magnitude > 0) {
				mStartMovementInput.Normalize();
			} else {
				mStartMovementInput = new Vector2(0, -1);
			}
		}

		protected override void Apply()
		{
		}

		public override bool BlocksMovementInput { get { return true; } }
		public override Vector2 Movement 
		{ 
			get { 
				var timeFactor = 1 - TimeRemaining/mDuration;
				timeFactor = timeFactor*timeFactor*timeFactor*timeFactor;
				timeFactor = 1 - timeFactor;
				return mStartMovementInput * (1 + mSpeedMultiplier * TimeRemaining/mDuration); 
			} 
		}

		[SerializeField]
		private float mSpeedMultiplier = 5.0f;

		private Vector2 mStartMovementInput;

	}
}

