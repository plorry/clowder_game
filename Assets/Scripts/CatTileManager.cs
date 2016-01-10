using UnityEngine;
using System.Collections;

public class CatTileManager : MonoBehaviour {

	public CatTile catTilePrefab;
	public GridClass gridPrefab;
	private GridClass myGrid;


	void Awake() {

	}
	// Use this for initialization
	void Start () {
		myGrid = (GridClass)Instantiate (gridPrefab);
		GenerateStartingCatTiles ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateStartingCatTiles() {
		CatTile newCatTile = Instantiate (catTilePrefab);
		var newTile = myGrid.GetTileAt (8, 8);
		newCatTile.SetPositionTile (newTile);

		CatTile newCatTile2 = Instantiate (catTilePrefab);
		var newTile2 = myGrid.GetTileAt (7, 8);
		newCatTile2.SetPositionTile (newTile2);

		CatTile newCatTile3 = Instantiate (catTilePrefab);
		var newTile3 = myGrid.GetTileAt (7, 7);
		newCatTile3.SetPositionTile (newTile3);

		CatTile newCatTile4 = Instantiate (catTilePrefab);
		var newTile4 = myGrid.GetTileAt (8, 7);
		newCatTile4.SetPositionTile (newTile4);
	}
}
