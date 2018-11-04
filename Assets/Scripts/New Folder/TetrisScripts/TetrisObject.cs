using UnityEngine;
using System.Collections;

public class TetrisObject : MonoBehaviour {

	float lastFall = 0f;
	Spawner spawner;
	// Use this for initialization
	void Start () {
		spawner = FindObjectOfType<Spawner> ();
		if (!IsValidGridPosition()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(transform.position);
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1, 0, 0);

			if (IsValidGridPosition ()) {
				UpdateMatrixGrid ();
			} else {
				transform.position += new Vector3 (-1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0);
				
			if (IsValidGridPosition ()) {
				UpdateMatrixGrid ();
			} else {
				transform.position += new Vector3 (1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (new Vector3 (0, 0, -90));

			if (IsValidGridPosition ()) {
				UpdateMatrixGrid ();
			} else {
				transform.Rotate (new Vector3 (0, 0, 90));
			}
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Time.time - lastFall >= 1) {
			//Debug.Log (IsValidGridPosition());
			transform.position += new Vector3(0,-1,0);

			if (IsValidGridPosition()) {
				//print ("GOOD");
				
				UpdateMatrixGrid();
			}else{
				//print ("BAD :(" + transform.gameObject.name + " " + transform.position);
				transform.position += new Vector3(0,1,1);

				MatrixGrid.DeleteWholeRows();
//				Debug.Log (lastFall);
				spawner.SpawnRandom();

				enabled = false;
			}
			lastFall = Time.time;
		}

	}

	bool IsValidGridPosition() {
		//Debug.Log(transform.childCount);
		string childInfo = "";
		foreach (Transform child in transform) {
			Vector2 v = MatrixGrid.RoundVector (child.position);
			childInfo += gameObject.name + "::" + child.name + " = " + v + "\n";
			if (!MatrixGrid.IsInsideBorder (v)) {
				print ("INVALID, Stopping... FInal Child Info from: " + gameObject.name);
				print ("\n" + childInfo);
				
				return false;
			}

			//if (MatrixGrid.grid [(int)v.x, (int)v.y] != null 
				//&& MatrixGrid.grid [(int)v.x, (int)v.y].parent != child
			   // ) {
				//	Debug.Log("Second thing failed it");
				//	Debug.Log (MatrixGrid.grid[(int)v.x, (int)v.y]);
				//	Debug.Log (MatrixGrid.grid[(int)v.x, (int)v.y].parent);
				//	Debug.Log (transform);
				//return false;
				//}
			}
			print (childInfo);
			return true;
		}

	void UpdateMatrixGrid(){
		string ourNiceGrid = "";
		//Debug.Log ("Updating " + transform.gameObject.name);
		for (int y = 0; y < MatrixGrid.column; ++y) {
			ourNiceGrid += "\n";
			for (int x = 0; x < MatrixGrid.row; ++x) {
				if(MatrixGrid.grid[x,y]) 
				{
					ourNiceGrid += MatrixGrid.grid[x,y].position;
				}else { 
						ourNiceGrid += 0;
					};
				
				//if (MatrixGrid.grid [x, y] != null) {
				//	if (MatrixGrid.grid [x, y].parent = transform) {
				///		MatrixGrid.grid [x, y] = null;
				//	}
				//}
			}
		}
			//print (ourNiceGrid);
		
		foreach (Transform child in transform) {
			Vector2 v = MatrixGrid.RoundVector (child.position);
			MatrixGrid.grid [(int)v.x, (int)v.y] = child; 

		}
	}
}
