using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using AssemblyCSharp;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i=0; i<mInitialNumNimmables; i++) {
			AddNimmable();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void AddNimmable() {
		var position = new Vector3(Random.Range(-30,30), Random.Range(-30,30), -1.01f);
		var scale = Random.Range(0.2f, 0.6f);
		AddNimmable(position, scale);
	}

	void AddNimmable(Vector3 position, float scale)
	{
		var nimmable = GameObject.Instantiate(mNimmablePrefab);
		nimmable.transform.position = position;
		nimmable.transform.localScale = new Vector3(scale, scale, scale);
		nimmable.transform.parent = this.gameObject.transform;
		mNimmables.Add(nimmable);
	}


	private static bool NimmInRange(NimmableController nimmable, Vector2 p, float range)
	{
		return Geometry.Intersects(new Geometry.Circle(p, range), nimmable.Frame);
	}

	public void DoNimm(Vector2 position, float range)
	{
		var nimmable = NimmableControllers.Where(n => NimmInRange(n, position, range)).FirstOrDefault();
		if (nimmable != null) {
			mNimmables.Remove(nimmable.gameObject);
			GameObject.Destroy(nimmable.gameObject);
		}
	}

	public IEnumerable<NimmableController> NimmableControllers
	{
		get { return mNimmables.Select(n => (NimmableController)n.GetComponent(typeof(NimmableController))); }
	}


	[SerializeField]
	private GameObject mNimmablePrefab;

	[SerializeField]
	private float mInitialNumNimmables;

	private List<GameObject> mNimmables = new List<GameObject>();
}

