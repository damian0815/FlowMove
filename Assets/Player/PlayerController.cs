using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerController : MonoBehaviour {

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
		mActionQueue.Update(this);
	}

	[SerializeField]
	float mSpeedFactor = DEFAULT_SPEED_FACTOR;
	const float DEFAULT_SPEED_FACTOR = 0.1f;


	ActionQueue mActionQueue = new ActionQueue();

}
