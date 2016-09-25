using UnityEngine;
using System.Collections;

public class GenerateConstructionAreas : MonoBehaviour {

    public GameObject areaPrefab = null;
    public float spacing = 0.2f;
    public float positionShift = 1f;

    private static int itemCount = 9;
    private static int itemPerLine = 3;

    private ArrayList buildAreasList;

    // Use this for initialization
    void Start () {
		buildAreasList = new ArrayList();

		if (areaPrefab != null) {
			for (int i=0; i< itemCount; i++) {
				GameObject go = Instantiate(areaPrefab, gameObject.transform) as GameObject;
				go.transform.position = new Vector3((i % itemPerLine - 1f) * (positionShift + spacing), 0.01f, (i / itemPerLine - 1f) * (positionShift + spacing));
				go.name = "ConstructionArea"+i;
				buildAreasList.Add(go);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
