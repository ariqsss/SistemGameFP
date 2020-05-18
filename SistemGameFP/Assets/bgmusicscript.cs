using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmusicscript : MonoBehaviour
{
   public AudioSource _audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioClip clip;
    public AudioClip clip3;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        audioSource3 = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
    public void PlayDoor()
    {
        audioSource2.PlayOneShot(clip);
    }
    public void PlayWin()
    {
        audioSource3.PlayOneShot(clip3);
    }

}
