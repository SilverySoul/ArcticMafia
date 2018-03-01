using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBearScript : MonoBehaviour
{
    public AudioClip BearDie;
    public AudioClip BearHit;
    public AudioClip BearOK;

    private AudioSource Source;

    bool tick = true;

    void Start()
    {

        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
    }

    public void BearDieSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(BearDie, 1f);
    }

    public void BearOKSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(BearOK, 1f);
    }

    public void BearHitSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(BearHit, 1f);
    }

}
