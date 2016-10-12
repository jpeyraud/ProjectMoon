using UnityEngine;
using System.Collections;

public class ConstructionAreaBehavior : MonoBehaviour {

	private bool isAvailable;
	public bool IsAvailable { 
		get{ 
			return isAvailable; 
		}
		set{ 
			isAvailable = value;
			if(!isAvailable)
				transform.parent.GetComponent<RessourcesManager>().addWoodGenerator (); 
		}
	}

	// Use this for initialization
	void Start () {
		isAvailable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
