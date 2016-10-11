using UnityEngine;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

	public float wood;
	public float stone;
	public float iron;

	public const float woodPerSecGeneration = 0.2f;
	public const float stonePerSecGeneration = 0.2f;
	public const float ironPerSecGeneration = 0.2f;

	// Use this for initialization
	void Start () {
		wood = 0f;
		wood = 0f;
		wood = 0f;

		InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);
	}


}
