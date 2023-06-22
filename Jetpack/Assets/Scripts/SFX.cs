using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource asteroidBoom;
    public AudioSource jetpackSFX;


    public void playJetpackSound()
    {
        jetpackSFX.Play();
    }

    public void stopJetpackSound()
    {
        jetpackSFX.Stop();
    }

    public void playAsteroidBoom()
    {
        asteroidBoom.Play();
    }


}
