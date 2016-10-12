using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RessourcesManager : MonoBehaviour {

	private float wood;
	private float stone;
	private float iron;

	private const float woodPerSecGeneration = 0.2f;
	private const float stonePerSecGeneration = 0.2f;
	private const float ironPerSecGeneration = 0.2f;

	private int nbOfWoodGenerator = 0;
	private int nbOfStoneGenerator = 0;
	private int nbOfIronGenerator = 0;

	public Text woodNumberUI;
	public Text stoneNumberUI;
	public Text ironNumberUI;

	// Use this for initialization
	void Start () {
		wood = 0f;
		stone = 0f;
		iron = 0f;

		InvokeRepeating("generateRessources", 2.0f, 1f);
	}

	void generateRessources () {
		wood += nbOfWoodGenerator * woodPerSecGeneration;
		stone += nbOfStoneGenerator * stonePerSecGeneration;
		iron += nbOfIronGenerator * ironPerSecGeneration;

		woodNumberUI.text = ""+(int)wood;
		stoneNumberUI.text = ""+(int)stone;
		ironNumberUI.text = ""+(int)iron;
	}

	public void addWoodGenerator() {
		nbOfWoodGenerator++;
	}

	public void addStoneGenerator() {
		nbOfStoneGenerator++;
	}

	public void addIronGenerator() {
		nbOfIronGenerator++;
	}
}
