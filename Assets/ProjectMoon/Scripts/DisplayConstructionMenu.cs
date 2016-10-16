using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayConstructionMenu : MonoBehaviour {

	public GameObject gameInterface;
	public GameObject constructionPriceLabel;

	private int itemPerLine;
	private float spacing;
	private float gameInterfaceMargin;
	private Vector3 constructionPriceMargin;
	private float verticalStartPos;
	private List<GameObject> miniConstructions;
	private List<string> miniConstructionsName;
	private GameObject constructionMenu;

	private Quaternion menuOrientation;
	private Quaternion   
	priceLabelOrientation;

	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();

		miniConstructions = new List<GameObject>();
		miniConstructionsName = new List<string>();

		// parameters
		itemPerLine = 3;
		spacing = 0.15f;
		constructionPriceMargin = new Vector3(0f, 0.07f, -0.04f);
		gameInterfaceMargin = 0.5f*spacing;
		menuOrientation = Quaternion.Euler (-50, 180, 0);
		priceLabelOrientation = Quaternion.Euler (50, 0, 0);

		generateConstructionList ();
		constructionMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		// Display the construction menu when the ApplicationMenu button is held pressed, else delete it
		if(device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			setActivateConstructionMenu (true);
		}
		else if (constructionMenu != null && !device.GetTouch(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
			setActivateConstructionMenu (false);
		}
	}

	private void setActivateConstructionMenu(bool activate) {
		// Reset the game interface position
		if (activate) {
			gameInterface.transform.SetParent(constructionMenu.transform);
			gameInterface.transform.localPosition = new Vector3 ((itemPerLine-1)*spacing/2f, 0, verticalStartPos + spacing + gameInterfaceMargin);
			gameInterface.transform.localRotation = menuOrientation;
			gameInterface.transform.Rotate (0, 180, 0);
			gameInterface.SetActive (true);
		}

		constructionMenu.SetActive (activate);
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
		miniConstructionsName.Add ("smithy");
		miniConstructionsName.Add ("barracks");
		miniConstructionsName.Add ("house");
		miniConstructionsName.Add ("tower");

		// Generate the mini constructions and set them at the proper position inside the menu
		verticalStartPos = spacing*((miniConstructionsName.Count-1)/itemPerLine) + gameInterfaceMargin;
		for(int i = 0; i < miniConstructionsName.Count; i++) {
			GameObject newGo = Instantiate(Resources.Load("Prefabs/"+miniConstructionsName[i]),  constructionMenu.transform.position,  constructionMenu.transform.rotation, constructionMenu.transform) as GameObject;
			miniConstructions.Add (newGo);
			newGo.transform.localPosition = new Vector3((i%itemPerLine)*spacing, 0, verticalStartPos-(i/itemPerLine)*spacing);
			newGo.transform.localRotation = menuOrientation;
			newGo.GetComponent<Rigidbody>().useGravity = false;
			newGo.GetComponent<Rigidbody>().isKinematic = true;

			// create text labels for construction prices
			GameObject priceLabel = Instantiate(constructionPriceLabel, constructionMenu.transform.position,  constructionMenu.transform.rotation, constructionMenu.transform) as GameObject;
			priceLabel.transform.localPosition = new Vector3((i%itemPerLine)*spacing, 0, verticalStartPos-(i/itemPerLine)*spacing);
			priceLabel.transform.localPosition = priceLabel.transform.localPosition + constructionPriceMargin;
			priceLabel.transform.localRotation = priceLabelOrientation;
			priceLabel.SetActive(true);
		}


	}
}
