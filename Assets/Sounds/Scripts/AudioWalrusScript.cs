using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWalrusScript : MonoBehaviour
{
    public AudioClip WalrusRoar;
    public AudioClip WalrusDie;
    public AudioClip WalrusHit;
    public AudioClip WalrusMove;

    private AudioSource Source;

    bool tick = true;

    private void Start()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
    }

    public void WalrusRoarSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
        Source.PlayOneShot(WalrusRoar, 1f);
    }

    public void WalrusDieSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
        Source.PlayOneShot(WalrusDie, 1f);
    }

    public void WalrusHitSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
        Source.PlayOneShot(WalrusHit, 1f);
    }
    public void WalrusMoveSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
        Source.PlayOneShot(WalrusMove, 1f);
    }
}
