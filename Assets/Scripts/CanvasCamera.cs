using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour {

    private Canvas can;
    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
        can = GetComponent<Canvas>();
        can.worldCamera = cam;
    }
}
