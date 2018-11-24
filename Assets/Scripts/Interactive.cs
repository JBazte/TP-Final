using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {

    public GameObject keyCode1;
    public GameObject keyCode2;
    public GameObject keyCode3;
    public GameObject keyCode4;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    public GameObject otherCol1;
    public GameObject otherCol2;
    public GameObject otherCol3;
    public GameObject otherCol4;
    
    private void Update()
    {
        if (otherCol1.GetComponent<Colliders>().col1 == true && Input.GetKey(KeyCode.E))
        {
            text1.SetActive(true);
        } else if (otherCol2.GetComponent<Colliders>().col2 == true && Input.GetKey(KeyCode.E))
        {
            text2.SetActive(true);
        } else if(otherCol3.GetComponent<Colliders>().col3 == true && Input.GetKey(KeyCode.E))
        {
            text3.SetActive(true);
        }else if (otherCol4.GetComponent<Colliders>().col4 == true && Input.GetKey(KeyCode.E))
        {
            text4.SetActive(true);
        }
        else
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            keyCode1.SetActive(true);
            keyCode2.SetActive(true);
            keyCode3.SetActive(true);
            keyCode4.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            keyCode1.SetActive(false);
            keyCode2.SetActive(false);
            keyCode3.SetActive(false);
            keyCode4.SetActive(false);
        }

    }
}
