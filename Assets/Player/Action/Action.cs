using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public abstract class Action : ScriptableObject
	{
		public PlayerController Player { get; set; }

		public virtual void Begin() 
		{
			TimeRemaining = mDuration;
		}

		public virtual void Stop()
		{
		}

		public void Update()
		{
			TimeRemaining -= Time.deltaTime;
			Apply();
		}

		protected float TimeRemaining{ get; private set; }

		protected abstract void Apply();

		public virtual bool BlocksMovementInput { get { return false; } }
		public virtual Vector2 Movement { get { return new Vector2(0,0); } }

		public bool IsDone { get { return TimeRemaining <= 0; } }

		[SerializeField]
		protected float mDuration = 1.0f;

	}
}

