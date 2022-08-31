using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Object : MonoBehaviour {

	float lastFal = 0f;

	void Start () {
		
	}
	

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1, 0, 0);

			if (IsValidGridPositions ()) {
				UpdateMatrix ();
			} else {
				transform.position += new Vector3 (1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0);

			if (IsValidGridPositions ()) {
				UpdateMatrix ();
			} else {
				transform.position += new Vector3 (-1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (0, 0, -90);
			if (IsValidGridPositions ()) {
				UpdateMatrix ();
			} else {
				transform.Rotate (0, 0, 90);
			}

		}
		else if (Input.GetKeyDown (KeyCode.DownArrow) || Time.time - lastFal >= 1)
		{
			
			transform.position += new Vector3 (0, -1, 0);
			if (IsValidGridPositions ()) {
				UpdateMatrix ();
			} else {
				transform.position += new Vector3 (0, 1, 0);
				Matrix_Grid.DeletWholeRows();
				FindObjectOfType<Spawner> ().SpawnRandom ();
				enabled = false;
			}
			lastFal = Time.time;
		}

	}

	bool IsValidGridPositions()
	{
		foreach (Transform child in transform)
		{
			Vector2 v = Matrix_Grid.RoudVector (child.position);
		

			if (!Matrix_Grid.InIsInsideBorder (v))
			{
				return false;
			}	
			if (Matrix_Grid.grid [(int)v.x, (int)v.y] != null
			    && Matrix_Grid.grid [(int)v.x, (int)v.y].parent != transform)
			{
				return false;
			}

		}
		return true;
	}

	void UpdateMatrix()
	{
		for (int y = 0; y < Matrix_Grid.column; ++y)
		{
			for (int x = 0; x < Matrix_Grid.row; ++x)
			{
				if (Matrix_Grid.grid [x, y] != null)
				{
					if (Matrix_Grid.grid [x, y].parent == transform)
					{
						Matrix_Grid.grid [x, y] = null;
					}
				}
			}
		}
		foreach (Transform child in transform)
		{
			Vector2 v = Matrix_Grid.RoudVector (child.position);
			Matrix_Grid.grid [(int)v.x, (int)v.y] = child;
		}
	}
}
