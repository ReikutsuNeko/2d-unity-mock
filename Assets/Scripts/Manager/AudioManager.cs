using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Singleton;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public Vector2 volume = new Vector2(0.5f, 0.9f);
    public Vector2 pitch = new Vector2(0.8f, 1.2f);

    // play a clip from a designated AudioSource
    public void PlaySoundEffect(AudioClip audioClip, AudioSource audioSource)
    {
        if (audioSource == null) {
            Debug.Log("audio null");
            return;
        }

        audioSource.volume = Random.Range(volume.x, volume.y);
        audioSource.pitch = Random.Range(pitch.x, pitch.y);

        audioSource.clip = audioClip;
        audioSource.Stop();
        audioSource.Play();

        Debug.Log("audio");
    }
}
