using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioPlayer;

    public void playSoundEffect()
    {
        audioPlayer.Play();
    }
}
