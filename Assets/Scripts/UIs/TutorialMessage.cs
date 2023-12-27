using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    private TextMeshProUGUI tmproMessage;
    private float time;
    private int step;

    private void Start()
    {
        tmproMessage = transform.Find("Message").GetComponent<TextMeshProUGUI>();
        time = 0f;
        step = 0;
    }

    private void Update()
    {
        float calcTime(float t) {
            float interval = 60f / (RhythmGameManager.Instance.BPM * RhythmGameManager.Instance.LPB);
            float beatsec  = interval * RhythmGameManager.Instance.LPB;
            float time = (beatsec * t / RhythmGameManager.Instance.LPB) + RhythmGameManager.Instance.chartOffset * 0.01f;
            return time;
        }

        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        if(step == 0 && time > calcTime(1)) {
            tmproMessage.text = "チュートリアルへようこそ";
            step++;
        }
        else if(step == 1 && time > calcTime(3)) {
            tmproMessage.text = "パネルが反応するか確認してね";
            step++;            
        }
    }
}
