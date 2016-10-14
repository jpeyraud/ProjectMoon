using UnityEngine;
using System.Collections;

public class ConstructionAreaBehavior : MonoBehaviour {

	public bool isAvailable;

	// Use this for initialization
	void Start () {
		isAvailable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addGenerator(GeneratorType type)  {
		switch (type) {
		case GeneratorType.Wood :
			transform.parent.GetComponent<RessourcesManager>().addWoodGenerator (); 
			break;
		case GeneratorType.Stone :
			transform.parent.GetComponent<RessourcesManager>().addStoneGenerator (); 
			break;
		case GeneratorType.Iron :
			transform.parent.GetComponent<RessourcesManager>().addIronGenerator (); 
			break;
		}
	}

}
