using UnityEngine;
using System.Collections;

public class NimmableController : MonoBehaviour {

	public bool PointIsInside(Vector2 worldPoint) {
		var localPoint = this.gameObject.transform.InverseTransformPoint(worldPoint);
		if (localPoint.x < -sizeW/2 || localPoint.x > sizeW/2) {
			return false;
		}
		if (localPoint.z < -sizeH/2 || localPoint.z > sizeH/2) {
			return false;
		}
		return true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[SerializeField]
	float sizeW;
	[SerializeField]
	float sizeH;


}
