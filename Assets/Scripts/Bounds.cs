using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

}
