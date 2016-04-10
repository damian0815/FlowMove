using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class Action
	{
		public Action(float mDuration)
		{
			TimeRemaining = mDuration;
		}

		public virtual void Start(PlayerController player)
		{
		}

		public void Update(PlayerController player)
		{
			TimeRemaining -= Time.deltaTime;
			Apply(player);
		}

		protected float TimeRemaining{ get; private set; }

		protected abstract void Apply(PlayerController player);

		public virtual bool BlocksMovementInput { get { return false; } }
		public virtual Vector2 Movement { get { return new Vector2(0,0); } }

		public bool IsDone { get { return TimeRemaining <= 0; } }

	
	}
}

