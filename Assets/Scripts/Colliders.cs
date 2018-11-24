using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour {

    public int number;
    public bool col1;
    public bool col2;
    public bool col3;
    public bool col4;

    private bool active1;
    private bool active2;
    private bool active3;
    private bool active4;

    private void Update()
    {
        

        if (Input.GetKey(KeyCode.E))
        {
            if (active1)
            {
                col1 = true;
                col2 = false;
                col3 = false;
                col4 = false;
            } else if (active2)
            {
                col2 = true;
                col1 = false;
                col3 = false;
                col4 = false;
            } else if (active3)
            {
                col3 = true;
                col2 = false;
                col1 = false;
                col4 = false;
            } else if (active4)
            {
                col4 = true;
                col2 = false;
                col3 = false;
                col1 = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && number == 1)
        {
            active1 = true;
        } else if(other.tag == "Player" && number == 2 && Input.GetKey(KeyCode.E))
        {
            active2 = true;
        } else if(other.tag == "Player" && number == 3 && Input.GetKey(KeyCode.E))
        {
            active3 = true;
        } else if(other.tag == "Player" && number == 4 && Input.GetKey(KeyCode.E))
        {
            active4 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            col1 = false;
            col2 = false;
            col3 = false;
            col4 = false;
            active1 = false;
            active2 = false;
            active3 = false;
            active4 = false;
        }
    }
}
