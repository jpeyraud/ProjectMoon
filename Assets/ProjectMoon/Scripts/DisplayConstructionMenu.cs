using UnityEngine;
using System.Collections.Generic;

public class DisplayConstructionMenu : MonoBehaviour {

	private List<GameObject> miniConstructions;
	private List<string> miniConstructionsName;

	// Use this for initialization
	void Start () {
		generateConstructionList ();
	}
	
	// Update is called once per frame
	void Update () {
		updatePos (gameObject.transform);
	}


	private void updatePos(Transform t) {
		for(int i = 0; i < miniConstructionsName.Count; i++) {
			miniConstructions [i].transform.position = t.position;
			miniConstructions [i].transform.rotation = t.rotation;
		}
	}

	private void generateConstructionList() {
		miniConstructionsName = new List<string>();
		miniConstructionsName.Add ("woodcutter_mini");
		miniConstructionsName.Add ("mine_mini");
		miniConstructionsName.Add ("barracks_mini");
		miniConstructionsName.Add ("house_mini");

		miniConstructions = new List<GameObject>();

		for(int i = 0; i < miniConstructionsName.Count; i++) {
			miniConstructions.Add (Instantiate(Resources.Load("Mini/"+miniConstructionsName[i]), new Vector3(0.04f*i,0f,0f), new Quaternion(), gameObject.transform) as GameObject);
		}
	}
}
