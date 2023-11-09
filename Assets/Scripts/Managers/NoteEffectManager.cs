using System.Collections;
using System.Collections.Generic;
using General.CONSTS;
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

    [SerializeField] private GameObject normalJudgeEffectPrefab;
    [SerializeField] private GameObject touchJudgeEffectPrefab;

    private AudioSource audioSource;
    private GameObject judgeEffectsParent;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        judgeEffectsParent = GameObject.Find("MasterScaler").transform.Find("JudgeEffects").gameObject;
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

    public void GenerateJudgeEffect(int noteType, int judgeID, int[] lanes)
    {
        if(noteType == (int)NOTE.TYPE.NormalNote) {
            GameObject judgeEffect = Instantiate(
                normalJudgeEffectPrefab,
                judgeEffectsParent.transform
            );
            judgeEffect.GetComponent<NormalJudgeEffect>().Init(judgeID, lanes);
            Destroy(judgeEffect, 0.25f);
        }
        else if(noteType == (int)NOTE.TYPE.TouchNote) {
            GameObject judgeEffect = Instantiate(
                touchJudgeEffectPrefab,
                judgeEffectsParent.transform
            );
            judgeEffect.GetComponent<TouchJudgeEffect>().Init(judgeID, lanes);
            Destroy(judgeEffect, 0.2f);            
        }
    }
}
