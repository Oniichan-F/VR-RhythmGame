using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    private float score;
    private float justCount;

    private void Start()
    {
        score = RhythmGameManager.Instance.score;
        justCount = RhythmGameManager.Instance.justCount;
        RhythmGameManager.Instance.score = 0f;
        RhythmGameManager.Instance.justCount = 0;

        if(justCount == RhythmGameManager.Instance.numNotes) {
            Debug.Log("score : 1000000");
        }
        else {
            Debug.Log("score : " + Mathf.Ceil(1000000f * score).ToString().PadLeft(7, '0'));
        }
    }
}
