using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class NimmLightAction: Action
	{
		public NimmLightAction ()
			: base(DURATION)
		{
		}

		public override void Start(PlayerController player)
		{
			//mNimmFx = (GameObject)GameObject.CreatePrimitive(PrimitiveType.Sphere);
			mNimmFx = GameObject.Instantiate(player.NimmLightFx);
			mNimmFx.transform.parent = player.gameObject.transform;
			mNimmFx.transform.localPosition = new Vector3(0,0,0);
			//mNimmFx.transform.localScale = new Vector3(MAX_FX_SCALE, MAX_FX_SCALE, MAX_FX_SCALE);
			mFxStartScale = mNimmFx.transform.localScale.x;
		}

		public override void Stop(PlayerController player)
		{
			GameObject.Destroy(mNimmFx);
		}

		private float Map(float x, float xMax, float xMin, float outMax, float outMin)
		{
			return (outMax-outMin) * (x-xMin)/(xMax-xMin);
		}

		protected override void Apply(PlayerController player)
		{
			float scale = Map(TimeRemaining, DURATION, 0, mFxStartScale, MIN_FX_SCALE);
			scale *= scale;
			mNimmFx.transform.localScale = new Vector3(scale,scale,scale);
		}


		public override bool BlocksMovementInput { get { return true; } }

		const float DURATION = 0.3f;
		float mFxStartScale;
		const float MIN_FX_SCALE = 0.1f;

		GameObject mNimmFx;
	}
}

