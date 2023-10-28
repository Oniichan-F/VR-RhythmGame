using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        string songSourceName = RhythmGameManager.Instance.songSourceName;
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + songSourceName);
        audioSource.clip = audioClip;

        audioSource.Play();
        audioSource.Pause();
    }

    public void Toggle()
    {
        if(RhythmGameManager.Instance.isPaused) {
            audioSource.Pause();
        }
        else {
            audioSource.UnPause();
        }
    }
}
