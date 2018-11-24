using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveChest : MonoBehaviour {

    public GameObject keyCode;
    private bool active;

    private void Start()
    {
        active = false;    
    }

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
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
