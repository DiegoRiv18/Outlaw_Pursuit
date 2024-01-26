using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Sources--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------Audio Clips-----------")]
    public AudioClip music;
    public AudioClip swordSlash;
    public AudioClip coinPickup;
    public AudioClip death;
    public AudioClip finalDeath;

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
