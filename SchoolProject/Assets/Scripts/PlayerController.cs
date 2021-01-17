using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverText, restartButton;
    public GameObject heart1, heart2, heart3;
    public int playerHealth = 3;
    int playerLayer, enemyLayer, waterLayer;
    bool coroutineAllowed = true;
    Color color;
    Renderer rend;
    public int coinValue = 1;

    void Start () 
    {
        playerLayer = this.gameObject.layer;
        enemyLayer = LayerMask.NameToLayer ("Enemy");

        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        heart1 = GameObject.Find ("Heart_1");
        heart2 = GameObject.Find ("Heart_2");
        heart3 = GameObject.Find ("Heart_3");

        heart1.gameObject.SetActive (true);
        heart2.gameObject.SetActive (true);
        heart3.gameObject.SetActive (true);

        rend = GetComponent<Renderer> ();
        color = rend.material.color;

        gameOverText.SetActive(false);
        restartButton.SetActive(false);

    } 

    void OnCollisionEnter2D (Collision2D col) 
    {
        if (col.gameObject.tag.Equals("water"))
        {
            playerHealth = 0;

            if (playerHealth < 1)
            {
                AudioManagerScript.PlaySound ("GameOverSound");
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        if (col.gameObject.tag.Equals("Enemy"))
        {
            AudioManagerScript.PlaySound ("HurtSound");
            playerHealth -= 1;
            switch (playerHealth)
            {
                case 2:
                heart3.gameObject.SetActive (false);
                if (coroutineAllowed)
                  StartCoroutine ("Immortal");
                break;

                case 1:
                heart2.gameObject.SetActive (false);
                if (coroutineAllowed)
                  StartCoroutine ("Immortal");
                break;

                case 0:
                heart1.gameObject.SetActive (false);
                if (coroutineAllowed)
                  StartCoroutine ("Immortal");
                break;
            }

            if (playerHealth < 1)
            {
                AudioManagerScript.PlaySound ("GameOverSound");
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        
    }

    IEnumerator Immortal () 
    {
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision (playerLayer, enemyLayer, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds (3f);
        Physics2D.IgnoreLayerCollision (playerLayer, enemyLayer, false);
        color.a = 1f;
        rend.material.color = color;
        coroutineAllowed = true;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        /*
        * if player collide with gameObject with "Coins" tag,
        * Destroy it and add the coinValue on the GUI
        */
        if (other.gameObject.CompareTag("Coins")) {
            Destroy(other.gameObject);
            AudioManagerScript.PlaySound ("CoinSound");
            ScoreManager.instance.ChangeCoinAmount(coinValue);
        }
    }
}
