using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexComponent : MonoBehaviour {

	void Start()
	{
		HexMap = GameObject.FindObjectOfType<HexMap> ();
	}

	public Hex Hex;
	public HexMap HexMap;

	void Update(){

		if(Hex == null)
		{
			return;
		}

		this.transform.position = Hex.positionFromCamera (
			Camera.main.transform.position,
			HexMap.numRows,
			HexMap.numColumns
		);
	}
}