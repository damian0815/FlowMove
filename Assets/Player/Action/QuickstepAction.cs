using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class QuickstepAction : Action
	{
		public QuickstepAction ()
			: base(DURATION)
		{
		}

		public override void Start(PlayerController player)
		{
			mStartMovementInput = player.MovementInput;
			if (mStartMovementInput.magnitude > 0) {
				mStartMovementInput.Normalize();
			} else {
				mStartMovementInput = new Vector2(0, -1);
			}
		}

		protected override void Apply(PlayerController player)
		{
		}

		public override bool BlocksMovementInput { get { return true; } }
		public override Vector2 Movement 
		{ 
			get { 
				return mStartMovementInput * (1 + SPEED_MULTIPLIER * TimeRemaining/DURATION); 
			} 
		}

		private const float DURATION = 0.3f;
		private const float SPEED_MULTIPLIER = 10.0f;

		private Vector2 mStartMovementInput;

	}
}

