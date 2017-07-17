using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GenerateMap ();
		
	}

	public GameObject HexPrefab;

	public Material[] HexMaterials;

	public int numRows = 0;
	public int numColumns = 0;

	public void GenerateMap()
	{
		for (int column = 0; column < numColumns; column++)
		{
			for (int row = 0; row < numRows; row++) {
				//instatiate hex
				Hex h = new Hex (column, row);

				Vector3 pos = h.positionFromCamera(
					Camera.main.transform.position,
					numRows,
					numColumns
				);


				GameObject hexGO = (GameObject)Instantiate (
					HexPrefab,
					pos,
					Quaternion.identity,
					this.transform

				);
				hexGO.GetComponent<HexComponent>().Hex = h;


				MeshRenderer mr = hexGO.GetComponentInChildren<MeshRenderer>();
				mr.material = HexMaterials[Random.Range (0, HexMaterials.Length)];
			}
		}

		//StaticBatchingUtility.Combine (this.gameObject);

			
	}
}