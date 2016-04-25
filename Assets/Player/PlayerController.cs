using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerController : MonoBehaviour {

	public GameObject NimmLightFx { get { return mNimmLightFx; } }
	public GameObject Level { get { return mLevel; } }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateActions();
		UpdateMovement();
	}

	public Vector2 MovementInput { get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); } }

	void UpdateMovement() {
		Vector2 movement;
		if (mActionQueue.CurrentAction != null && mActionQueue.CurrentAction.BlocksMovementInput) {
			movement = mActionQueue.CurrentAction.Movement;
		} else {
			movement = MovementInput;;
		}
		transform.Translate(mSpeedFactor * movement);
	}

	void UpdateActions() {

		if (Input.GetButtonDown("Quickstep")) {
			Debug.Log("Quickstep pressed");
			var action = new QuickstepAction();
			mActionQueue.Enqueue(action);
		} 
		if (Input.GetButtonDown("NimmLight")) {
			Debug.Log("NimmLight pressed");
			var action = new NimmLightAction();
			mActionQueue.Enqueue(action);
		}
		mActionQueue.Update(this);
	}

	[SerializeField]
	private float mSpeedFactor = DEFAULT_SPEED_FACTOR;
	private const float DEFAULT_SPEED_FACTOR = 0.1f;

	[SerializeField]
	private GameObject mLevel;

	[SerializeField]
	private GameObject mNimmLightFx;

	private ActionQueue mActionQueue = new ActionQueue();

}
