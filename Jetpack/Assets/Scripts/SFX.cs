using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource jetpackSFX;
    public void playJetpackSound()
    {
        jetpackSFX.Play();
    }

    public void stopJetpackSound()
    {
        jetpackSFX.Stop();
    }

}
