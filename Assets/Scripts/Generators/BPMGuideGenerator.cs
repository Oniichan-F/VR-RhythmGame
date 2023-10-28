using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMGuideGenerator : MonoBehaviour
{
    [SerializeField] GameObject BPMGuide;
    [SerializeField] GameObject MasterScaler;

    private float BPM;
    private int LPB;
    private int maxBeatNum;

    private float noteSpeed;
    private float chartOffset;

    private void OnEnable()
    {
        BPM = RhythmGameManager.Instance.BPM;
        LPB = RhythmGameManager.Instance.LPB;
        noteSpeed = RhythmGameManager.Instance.noteSpeed;
        chartOffset = RhythmGameManager.Instance.chartOffset;
        maxBeatNum = RhythmGameManager.Instance.maxBeatNum;

        Generate();
    }

    private void Generate()
    {
        float calcPosition(int i) {
            float interval = 60f / (BPM * LPB);
            float beatsec  = interval * LPB;
            float time = (beatsec * i / LPB) + chartOffset * 0.01f;
            float pos = time * noteSpeed;
            return pos;
        }

        GameObject BPMGuideParent = MasterScaler.transform.Find("BPMGuides").gameObject;

        for(int i=16; i<maxBeatNum*16; i+=16) {
            float pos = calcPosition(i);
            GameObject BPMGuideObj = Instantiate(
                BPMGuide,
                BPMGuideParent.transform
            );
            BPMGuideObj.transform.position = new Vector3(
                BPMGuideObj.transform.position.x, BPMGuideObj.transform.position.y, pos
            );
        }
    }
}
