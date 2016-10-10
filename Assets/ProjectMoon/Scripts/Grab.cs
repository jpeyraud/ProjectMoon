using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Grab : MonoBehaviour
{
	
	public Rigidbody attachPoint;

	SteamVR_TrackedObject trackedObj;

	FixedJoint joint;
	GameObject objectSelected;	
	GameObject objectCollided;	

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);

		if (objectCollided != null && joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			// select the collided object
			objectSelected = objectCollided;

			// create a fixed joint on the provided attach point
			objectSelected.transform.parent = null;
			objectSelected.transform.position = attachPoint.transform.position;
			joint = objectSelected.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
			objectSelected.GetComponent<Rigidbody>().isKinematic = false;
			objectSelected.GetComponent<Rigidbody>().useGravity = true;
		}
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = joint.gameObject;
			var rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			objectSelected = null;
		
			// Apply contruction script on collision
			go.AddComponent<ConstructOnCollision>();

			// Throw Object
			var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
			if (origin != null)
			{
				rigidbody.velocity = origin.TransformVector(device.velocity);
				rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
			}
			else
			{
				rigidbody.velocity = device.velocity;
				rigidbody.angularVelocity = device.angularVelocity;
			}

			rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Grabbable" && objectSelected == null) 
		{
			objectCollided = collider.gameObject; 
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Grabbable")
		{
			objectCollided = null;
		}
	}
}
