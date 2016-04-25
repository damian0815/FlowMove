using System;
using UnityEngine;

namespace AssemblyCSharp
{
	[CreateAssetMenu(fileName = "NimmLightAction", menuName = "Actions/NimmLight", order = 1)]
	public class NimmLightAction: Action
	{
		public override void Begin()
		{
			base.Begin();
			mNimmFx = GameObject.Instantiate(mNimmFx);
			mNimmFx.transform.parent = Player.gameObject.transform;
			mNimmFx.transform.localPosition = new Vector3(0,0,0);
			//mNimmFx.transform.localScale = new Vector3(MAX_FX_SCALE, MAX_FX_SCALE, MAX_FX_SCALE);
			mFxStartScale = mNimmFx.transform.localScale.x;
		}

		public override void Stop()
		{
			GameObject.Destroy(mNimmFx);
		}

		private float Map(float x, float xMax, float xMin, float outMax, float outMin)
		{
			return (outMax-outMin) * (x-xMin)/(xMax-xMin);
		}

		protected override void Apply()
		{
			float timePct = 1.0f - (TimeRemaining / mDuration);
			float startScale = mFxStartScale;
			float endScale = MIN_FX_SCALE;
			float scale = mFxStartScale + /*(float)Math.Sqrt(timePct)*/timePct*timePct * (endScale - startScale);
			mNimmFx.transform.localScale = new Vector3(scale,scale,scale);

			var levelController = (LevelController)Player.Level.GetComponent(typeof(LevelController));
			levelController.DoNimm(Player.transform.position, mRange);
		}


		public override bool BlocksMovementInput { get { return true; } }

		float mFxStartScale;
		const float MIN_FX_SCALE = 0.1f;

		[SerializeField]
		GameObject mNimmFx;

		[SerializeField]
		float mRange;
	}

}

