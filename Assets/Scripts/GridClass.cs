using UnityEngine;
using System.Collections;


public class GridClass : MonoBehaviour {

	public int rows;
	public int cols;
	public Tile tilePrefab;
	public string myName;
	public Tile[,] myTiles = new Tile[16, 16];

	void Awake() {
		GenerateTiles ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateTiles() {
		for (var i = 0; i < rows; i++) {
			for (var j = 0; j < cols; j++) {
				Vector3 thisPosition = new Vector3( -8 + i, 0, -8 + j );
				Tile newTile = (Tile)Instantiate (tilePrefab, thisPosition, transform.rotation);

				newTile.row = i;
				newTile.col = j;
				newTile.myGrid = this;

				myTiles[i, j] = newTile;
			}
		}
	}

	// Return the tile object at the given coordinates
	public Tile GetTileAt(int x, int y) {
		return myTiles[x, y];
	}
}
