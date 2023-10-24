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
            case 0:
                audioSource.PlayOneShot(hitStandard);
                break;
            case 1:
                audioSource.PlayOneShot(hitWeak);
                break;
            case 2:
                audioSource.PlayOneShot(hitStrong);
                break;
            case 3:
                audioSource.PlayOneShot(hitLong);
                break;
            default:
                break;                              
        }
    }
}
