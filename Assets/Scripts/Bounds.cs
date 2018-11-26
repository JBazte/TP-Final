using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour {

    public GameObject thePlayer;
    private Traps[] callReload;

    private void Start()
    {
        callReload = FindObjectsOfType<Traps>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Instantiate(thePlayer, new Vector3(-7.5f, -3.17f, 0f), Quaternion.identity);
            for(int i = 0; i < callReload.Length; i++)
            {
                callReload[i].Reload();
            }
        }
    }

}
