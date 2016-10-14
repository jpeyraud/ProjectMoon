using UnityEngine;
using System.Collections.Generic;

public class DisplayConstructionMenu : MonoBehaviour {

	public int itemPerLine = 4;
	public float spacing = 0.15f;
	public GameObject gameInterface;

	private List<GameObject> miniConstructions;
	private List<string> miniConstructionsName;
	private GameObject constructionMenu;

	private Quaternion menuOrientation;

	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		miniConstructions = new List<GameObject>();
		miniConstructionsName = new List<string>();

		menuOrientation = Quaternion.Euler (-50, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		// Display the construction menu when the ApplicationMenu button is held pressed, else delete it
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			generateConstructionList ();
			gameInterface.SetActive (true);
		}
		else if (constructionMenu != null && !device.GetTouch(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			miniConstructionsName.Clear();
			miniConstructions.Clear();
			gameInterface.SetActive (false);
			gameInterface.transform.parent = null;
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
		miniConstructionsName.Add ("woodcutter");
		miniConstructionsName.Add ("mine");
		miniConstructionsName.Add ("barracks");
		miniConstructionsName.Add ("house");
		miniConstructionsName.Add ("smithy");
		miniConstructionsName.Add ("factory");
		miniConstructionsName.Add ("tower");
		miniConstructionsName.Add ("cauldron");
		miniConstructionsName.Add ("oracle");
		miniConstructionsName.Add ("throne");


		// Generate the mini constructions and set them at the proper position inside the menu
		float margin = 0.5f*spacing;
		float verticalStartPos = spacing*(miniConstructionsName.Count/itemPerLine) + margin;
		for(int i = 0; i < miniConstructionsName.Count; i++) {
			GameObject newGo = Instantiate(Resources.Load("Prefabs/"+miniConstructionsName[i]),  constructionMenu.transform.position,  constructionMenu.transform.rotation, constructionMenu.transform) as GameObject;
			miniConstructions.Add (newGo);
			newGo.transform.localPosition = new Vector3((i%itemPerLine)*spacing, 0, verticalStartPos-(i/itemPerLine)*spacing);
			newGo.transform.localRotation = menuOrientation;
			newGo.GetComponent<Rigidbody>().useGravity = false;
			newGo.GetComponent<Rigidbody>().isKinematic = true;
		}

		// Instantiate the game interface
		gameInterface.transform.SetParent(constructionMenu.transform);
		gameInterface.transform.localPosition = new Vector3 ((itemPerLine-1)*spacing/2f, 0, verticalStartPos + spacing + margin);
		gameInterface.transform.localRotation = menuOrientation;
		gameInterface.transform.Rotate (0, 180, 0);
	}
}
