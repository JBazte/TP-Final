using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));	
	}
}
