using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Events;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class NoteEffectManager : MonoBehaviour
{
    [SerializeField] private AudioClip hitStandard;
    [SerializeField] private AudioClip hitWeak;
    [SerializeField] private AudioClip hitStrong;
    [SerializeField] private AudioClip hitLong;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySE(int id)
    {
        switch(id) {
            case 1: // Normal
                audioSource.PlayOneShot(hitStandard);
                break;
            case 2: // Touch
                audioSource.PlayOneShot(hitWeak);
                break;
            case 3: // Flick
                audioSource.PlayOneShot(hitStrong);
                break;
            case 10: // Long
                audioSource.PlayOneShot(hitStandard);
                break;
            case 12: // LongChild
                audioSource.PlayOneShot(hitWeak);
                break;
            default:
                break;                              
        }
    }
}
