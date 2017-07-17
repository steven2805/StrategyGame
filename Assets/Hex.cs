using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex {

	public Hex(int q, int r)
	{
		this.Q = q;
		this.R = r;
		this.S = -(q + r);

	}

	public readonly int Q; //column
	public readonly int R; //Row
	public readonly int S; //Sum

	static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt (3) / 2;

	float radius = 1f;
	bool allowWrapEastWest = true;
	bool allowWrapNorthSouth = false;


	public Vector3 Position()
	{
		return new Vector3 (
			HexHorizontalSpacing() * (this.Q + this.R / 2f),
			0,
			HexVerticalSpacing() * this.R
		);
			
	}



	public float HexHeight()
	{
		return radius * 2;
	}

	public float HexWidth(){
		return WIDTH_MULTIPLIER * HexHeight();
	}

	public float HexVerticalSpacing(){
		return HexHeight() * 0.75f;
	}

	public float HexHorizontalSpacing(){
		return HexWidth();
	}

	public Vector3 positionFromCamera( Vector3 cameraPosition,float numRows,float numColumns)
	{
		float mapHeight = numRows * HexVerticalSpacing();
		float mapWidth = numColumns * HexHorizontalSpacing ();

		//base position
		Vector3 position = Position();

		position.x -= cameraPosition.x;
		position.y -= cameraPosition.y;
	

		if (allowWrapEastWest) {
			while (position.x < -mapWidth / 2) {
				position.x += mapWidth;
			}
			while (position.x >= mapWidth / 2) {
				position.x -= mapWidth;
			}
		}
		if (allowWrapNorthSouth) {
			while (position.z < -mapHeight / 2) {
				position.z += mapHeight;
			}
			while (position.z >= mapHeight / 2) {
				position.z -= mapHeight;
			}
		}

		position.x += cameraPosition.x;
		position.z += cameraPosition.z;

		return position;


	}

}
