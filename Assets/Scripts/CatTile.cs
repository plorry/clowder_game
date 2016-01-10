using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Globals {
	public static string[] possibleNames = {"donk", "cabby", "chat", "weemer"};
	public static string[] possibleDirections = {"up", "down", "left", "right"};
}

public class CatTile : MonoBehaviour {

	private int trapChallenge;
	public GameObject challengeText;
	public CatTile childCat;
	private string catName;
	private List<string> myDirections = new List<string>();
	private int diceThreshold;
	private int diceToss;
	public GameObject myZone;
	public Tile myTile;

	void Start () {
		RandomChallenge ();
		catName = Globals.possibleNames [Random.Range (0, Globals.possibleNames.Length - 1)];
		SetBreedDirections (100);
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

	void SetBreedDirections (int chanceForNext) {
		string direction = Globals.possibleDirections [Random.Range (0, Globals.possibleDirections.Length)];
		if (!myDirections.Contains(direction)) {
			myDirections.Add(direction);
		}
		int roll = Random.Range (0, 100);
		if (roll < chanceForNext) {
			SetBreedDirections(chanceForNext / 3);
		}
	}

	void Breed () {
		int[] tileDirection = { 0,0 };
		foreach (string direction in myDirections) {
			Tile newTile = myTile.getNeighbour(direction);

			if (!newTile.occupied) {
				CatTile newCat = (CatTile)Instantiate (childCat, new Vector3(0,0,0), transform.rotation);
				newCat.SetPositionTile(newTile);
			}
		}
	}

	void CreateNeighbour (int direction) {

	}

	public void SetPositionTile (Tile tile) {
		transform.Translate (tile.transform.position);
		myTile = tile;
		tile.OccupyWith (this);
	}
}
