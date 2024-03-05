using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Main Theme");
    }
    public void PlayMusic (string song)
    {
        Sound s = Array.Find(musicSounds, x => x.name == song);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }
    }
    public void PlaySFX(string sound)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == sound);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            {
                sfxSource.PlayOneShot(s.clip);
            }
        }
    }
}
