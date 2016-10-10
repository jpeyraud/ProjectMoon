using UnityEngine;
using System.Collections;

public class ConstructOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "ConstructionArea") {
			if (collider.GetComponent<ConstructionAreaBehavior> ().isAvailable) {
				transform.position = collider.transform.position;
				transform.rotation = collider.transform.rotation;
				transform.localScale *= 7f;
				gameObject.GetComponent<Rigidbody>().useGravity = false;
				gameObject.GetComponent<Rigidbody>().isKinematic = true;

				collider.GetComponent<ConstructionAreaBehavior> ().isAvailable = false;
			}
		}
	}

	void OnTriggerExit(Collider collider)
	{
		
	}
}
