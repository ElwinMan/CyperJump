using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip chestSound, coinSound, gameOverSound, hurtSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        chestSound = Resources.Load<AudioClip> ("ChestSound");
        coinSound = Resources.Load<AudioClip> ("CoinSound");
        gameOverSound = Resources.Load<AudioClip> ("GameOverSound");
        hurtSound = Resources.Load<AudioClip> ("HurtSound");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "ChestSound":
            audioSrc.PlayOneShot (chestSound);
            break;

            case "CoinSound":
            audioSrc.PlayOneShot (coinSound);
            break;

            case "GameOverSound":
            audioSrc.PlayOneShot (gameOverSound);
            break;

            case "HurtSound":
            audioSrc.PlayOneShot (hurtSound);
            break;



        }
    }
}
