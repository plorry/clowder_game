using UnityEngine;
using System.Collections;

public static class TileConstants {
	public static Hashtable directions = new Hashtable ();
}


public class Tile : MonoBehaviour {

	public bool occupied;
	public CatTile occupiedBy;
	public GridClass myGrid;

	public int row;
	public int col;
	private bool isActive = false;
	
	void Start() {
	}
	
	void Update() {
		if (isActive) {
			GetComponent<Light> ().enabled = true;
		} else if (GetComponent<Light> ().isActiveAndEnabled) {
			GetComponent<Light> ().enabled = false;
		}
	}

	// Fill this tile with a catTile
	public void OccupyWith(CatTile catTile) {
		occupied = true;
		occupiedBy = catTile;
	}

	public void EmptyTile() {
		occupied = false;
		occupiedBy = null;
	}

	public Tile getNeighbour (string direction) {
		int[] checkDirection = new int[2] {0,0};

		if (direction == "up") {
			checkDirection[1] = checkDirection[1] + 1;
		} else if (direction == "down") {
			checkDirection[1] = checkDirection[1] - 1;
		} else if (direction == "left") {
			checkDirection[0] = checkDirection[0] - 1;
		} else if (direction == "right") {
			checkDirection[0] = checkDirection[0] + 1;
		}

		Tile newTile = myGrid.GetTileAt (row + checkDirection[0], col + checkDirection[1]);

		return newTile;
	}

	public void Select () {
		isActive = true;
	}

	public void Deselect () {
		isActive = false;
	}

}