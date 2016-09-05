using UnityEngine;
using System.Collections.Generic;

public class DisplayConstructionMenu : MonoBehaviour {

	public int itemPerLine = 4;
	public float spacing = 0.15f;

	private List<GameObject> miniConstructions;
	private List<string> miniConstructionsName;
	private GameObject constructionMenu;

	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		miniConstructions = new List<GameObject>();
		miniConstructionsName = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		// Display the construction menu when the ApplicationMenu button is held pressed, else delete it
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			generateConstructionList ();
		}
		else if (constructionMenu != null && !device.GetTouch(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			miniConstructionsName.Clear();
			miniConstructions.Clear();
			Destroy(constructionMenu);
		}
	}
		
	private void generateConstructionList() {

		// create the construction menu as a child of this controller
		constructionMenu = new GameObject();
		constructionMenu.name = "ConstructionMenu";
		constructionMenu.transform.parent = transform;
		constructionMenu.transform.position = transform.position;
		constructionMenu.transform.rotation = transform.rotation;

		// List of the prefabs to instantiate inside the contruction menu
		miniConstructionsName.Add ("woodcutter_mini");
		miniConstructionsName.Add ("mine_mini");
		miniConstructionsName.Add ("barracks_mini");
		miniConstructionsName.Add ("house_mini");

		// Generate the mini constructions and set them at the proper position inside the menu
		for(int i = 0; i < miniConstructionsName.Count; i++) {
			GameObject newGo = Instantiate(Resources.Load("Mini/"+miniConstructionsName[i]),  constructionMenu.transform.position,  constructionMenu.transform.rotation, constructionMenu.transform) as GameObject;
			miniConstructions.Add (newGo);
			newGo.transform.localPosition = new Vector3(i*spacing, 0,0);
			newGo.GetComponent<Rigidbody>().useGravity = false;
			newGo.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
