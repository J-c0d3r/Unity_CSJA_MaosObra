using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip sfx;
    public AudioClip sfx2;
    public AudioClip bgm;
    private AudioSource audioSource;
    public static AudioController current;

    void Start()
    {
        current = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void ChangeBGM()
    {
        audioSource.clip = sfx;
    }

}



