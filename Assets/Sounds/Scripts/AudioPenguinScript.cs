using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPenguinScript : MonoBehaviour {
    public AudioClip PenguingSpawn;
    public AudioClip PenguingDie;
    public AudioClip PenguingShoot;
    public AudioClip PenguingLaught;
    public AudioClip PenguinChainsaw;
    public AudioClip PenguinGainMoney;

    private AudioSource Source;

    bool tick =true;

	void Start ()
    {
        
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
    }

    public void PenguingSpawnSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }
        
        Source.PlayOneShot(PenguingSpawn, 1f);
    }
   
    public void PenguingDieSound ()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(PenguingDie, 1f);
    }

    public void PenguingChainsawSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(PenguinChainsaw, 1f);
    }

    public void PenguingLaughSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(PenguingLaught, 1f);
    }

    public void PenguingNoiseSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(PenguinGainMoney, 1f);
    }

    public void PenguinShootSound()
    {
        if (tick)
        {
            Source = GetComponent<AudioSource>();
            tick = false;
        }

        Source.PlayOneShot(PenguingShoot, 1f);
    }
}
