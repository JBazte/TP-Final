using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traps : MonoBehaviour {

    private bool flashActive;
    public float flashLength;
    private float flashCounter;
    public SpriteRenderer playerSprite;
    public PlayerController thePlayer;
    public AudioSource HurtSound;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = Color.red;
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = Color.white;
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = Color.red;
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = Color.white;
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
                StartCoroutine(Die());
            }
            flashCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            thePlayer.jump = KeyCode.None;
            thePlayer.right = KeyCode.None;
            thePlayer.left = KeyCode.None;
            flashActive = true;
            flashCounter = flashLength;
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Collider2D>().enabled = false;
            HurtSound.Play();
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
