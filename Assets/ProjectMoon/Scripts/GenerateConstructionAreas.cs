using UnityEngine;
using System.Collections;

public class GenerateConstructionAreas : MonoBehaviour {

    public GameObject AreaPrefab = null;
    public float Spacing = 0.2f;
    public float PositionShift = 1f;

    private static int itemCount = 9;
    private static int itemPerLine = 3;

    private ArrayList buildAreasList;

    // Use this for initialization
    void Start () {
		buildAreasList = new ArrayList();

		if (AreaPrefab != null) {
			for (int i=0; i< itemCount; i++) {
				GameObject go = Instantiate(AreaPrefab, gameObject.transform) as GameObject;
				go.transform.position = new Vector3((i % itemPerLine - 1f) * (PositionShift + Spacing), 0.01f, (i / itemPerLine - 1f) * (PositionShift + Spacing));
				buildAreasList.Add(go);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
