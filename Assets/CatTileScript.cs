using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Globals{
	public static string[] possibleNames = {"donk", "cabby", "chat", "weemer"};
	public static string[] possibleDirections = {"up", "down", "left", "right"};
}

public class CatTileScript : MonoBehaviour {

	private int trapChallenge;
	public GameObject challengeText;
	public Transform childCat;
	private string catName;
	private List<string> myDirections = new List<string>();
	private int diceThreshold;
	private int diceToss;

	void Start () {
		RandomChallenge ();
		catName = Globals.possibleNames [Random.Range (0, Globals.possibleNames.Length - 1)];
		SetBreedDirections ();
		foreach (var dir in myDirections) {
			print (dir);
		}
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Breed();
		}
	}

	void RandomChallenge () {
		trapChallenge = Random.Range (1, 12);
		var tm = challengeText.GetComponent<TextMesh> ();
		tm.text = trapChallenge.ToString();
	}

	void SetBreedDirections () {
		diceThreshold = 1;
		for (var i = 0; i < Globals.possibleDirections.Length; i++) {
			diceToss = Random.Range(1,6);
			if (diceToss >= diceThreshold) {
				myDirections.Add(Globals.possibleDirections[i]);
				diceThreshold += 2;
			}
		}
	}

	void Breed () {
		Vector3 thisPosition = transform.position;
		Vector3 newPosition = new Vector3 (thisPosition.x - 3, thisPosition.y, thisPosition.z);
		childCat.transform.SetParent (transform);
		Instantiate (childCat, newPosition, transform.rotation);
	}

	void CreateNeighbour (int direction) {

	}
}
