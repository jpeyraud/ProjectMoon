using UnityEngine;
using System.Collections;

public enum GeneratorType {None,Wood,Stone,Iron}

public class ConstructionBehavior : MonoBehaviour {

	public float woodRequired;
	public float stoneRequired;
	public float ironRequired;
	public GeneratorType generatorType = GeneratorType.None;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
