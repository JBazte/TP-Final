using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveChest : MonoBehaviour {

    public GameObject keyCode;
    private bool active;
    public Camera theCamera;

    private void Start()
    {
        active = false;    
    }

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            theCamera = FindObjectOfType<Camera>();
            theCamera.backgroundColor = new Color32(46, 44, 45, 0);
            theCamera.GetComponent<CameraController>().enabled = false;
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            keyCode.SetActive(true);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            keyCode.SetActive(false);
            active = false;
        }

    }
}
