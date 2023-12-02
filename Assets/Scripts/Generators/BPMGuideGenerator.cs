using System.Collections;
using System.Collections.Generic;
using General.ChartProtocol;
using UnityEditor.Rendering;
using UnityEngine;

public class BPMGuideGenerator : MonoBehaviour
{
    [SerializeField] GameObject BPMGuidePrefab;
    [SerializeField] GameObject MasterScaler;

    private BPMGuideFileData fileData;
    private float BPM;
    private float LPB;
    private float chartOffset;
    private float noteSpeed;

    private void OnEnable()
    {
        BPM = RhythmGameManager.Instance.BPM;
        LPB = RhythmGameManager.Instance.LPB;
        noteSpeed = RhythmGameManager.Instance.noteSpeed;
        chartOffset = RhythmGameManager.Instance.chartOffset;

        LoadData();
        Generate();
    }

    private void LoadData()
    {
        string jsonFileName = Resources.Load<TextAsset>("Charts/" + RhythmGameManager.Instance.songBPMGuideName).ToString();
        fileData = JsonUtility.FromJson<BPMGuideFileData>(jsonFileName);
    }

    private void Generate()
    {
        float calcTime(float t) {
            float interval = 60f / (BPM * LPB);
            float beatsec  = interval * LPB;
            float time = (beatsec * t / LPB) + chartOffset * 0.01f;
            return time;
        }

        GameObject BPMGuideParent = MasterScaler.transform.Find("BPMGuides").gameObject;

        foreach(BPMGuideData data in fileData.BPMGuideData) {
            float speed = noteSpeed * data.speed;
            float timing = data.timing;
            float time = calcTime(timing);
            float pos = time * speed;
            int shape = data.shape;
            float[] color = data.color;

            GameObject BPMGuideObj = Instantiate(
                BPMGuidePrefab,
                BPMGuideParent.transform
            );
            BPMGuideObj.GetComponent<BPMGuide>().Init(speed:speed, shape:shape, color:color, time:time, pos:pos);
        }
    }
}
