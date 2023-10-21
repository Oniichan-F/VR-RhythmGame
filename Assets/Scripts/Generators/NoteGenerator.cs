using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using General.ChartProtocol;
using General.CONSTS;
using Unity.VisualScripting;
using System.Xml;

public class NoteGenerator : MonoBehaviour
{
    [SerializeField] GameObject normalNotePrefab;
    [SerializeField] GameObject tourchNotePrefab;
    [SerializeField] GameObject masterScaler;

    private ChartData chartData;
    private float BPM;
    private float LPB;
    private float chartOffset;
    private float noteSpeed;


    private void OnEnable()
    {
        LoadChart();
        Generate();
    }

    private void LoadChart()
    {
        string jsonFileName = Resources.Load<TextAsset>("Charts/" + RhythmGameManager.Instance.songChartName).ToString();
        chartData = JsonUtility.FromJson<ChartData>(jsonFileName);
        Debug.Log(chartData.BPM);
        RhythmGameManager.Instance.BPM = chartData.BPM;
        RhythmGameManager.Instance.LPB = chartData.LPB;
        RhythmGameManager.Instance.baseChartOffset = chartData.offset;
        RhythmGameManager.Instance.SetOffsets();
    }

    private void Generate()
    {
        float calcTime(NoteData noteData)
        {
            float timing = noteData.timing;
            float interval = 60f / (BPM * LPB);
            float beatsec  = interval * LPB;
            float time = (beatsec * timing / LPB) + chartOffset * 0.01f;

            return time;        
        }

        BPM = RhythmGameManager.Instance.BPM;
        LPB = RhythmGameManager.Instance.LPB;
        chartOffset = RhythmGameManager.Instance.chartOffset;
        noteSpeed   = RhythmGameManager.Instance.noteSpeed;

        GameObject notesParent = masterScaler.transform.Find("Notes").gameObject;

        int id = 0;
        foreach(NoteData noteData in chartData.noteData) {
            // NormalNote
            if(noteData.type == (int)NOTE.TYPE.NormalNote) {
                int[] lanes   = noteData.lanes;
                string lr     = noteData.lr;
                bool isPaired = noteData.pair;
                float time    = calcTime(noteData);
                float pos     = time * noteSpeed;
                float rot     = LANE.ANGLES[lanes[0]];

                GameObject normalNoteObj = Instantiate(
                    normalNotePrefab,
                    notesParent.transform
                );

                NormalNote normalNote = normalNoteObj.GetComponent<NormalNote>();
                normalNote.Init(id:id, lanes:lanes, time:time, lr:lr, isPaired:isPaired);
                normalNote.SetPosition(pos);
                normalNote.SetRotation(rot);
            }
            // TouchNote
            else if(noteData.type == (int)NOTE.TYPE.TouchNote) {
                int[] lanes   = noteData.lanes;
                string lr     = noteData.lr;
                bool isPaired = noteData.pair;
                float time    = calcTime(noteData);
                float pos     = time * noteSpeed;
                float rot     = LANE.ANGLES[lanes[0]];

                GameObject touchNoteObj = Instantiate(
                    tourchNotePrefab,
                    notesParent.transform
                );

                TouchNote touchNote = touchNoteObj.GetComponent<TouchNote>();
                touchNote.Init(id:id, lanes:lanes, time:time, lr:lr, isPaired:isPaired);
                touchNote.SetPosition(pos);
                touchNote.SetRotation(rot);
            }

            id++;
        }
    }
}
