using UnityEngine;
using System.Collections;

public class MyRealDad : MonoBehaviour {

	public string parent;

	void Awake(){
		parent = transform.parent.name;
	}
}
