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
    [SerializeField] GameObject touchNotePrefab;
    [SerializeField] GameObject flickNotePrefab;
    [SerializeField] GameObject longNotePrefab;
    [SerializeField] GameObject longChildNotePrefab;
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
                    touchNotePrefab,
                    notesParent.transform
                );

                TouchNote touchNote = touchNoteObj.GetComponent<TouchNote>();
                touchNote.Init(id:id, lanes:lanes, time:time, lr:lr, isPaired:isPaired);
                touchNote.SetPosition(pos);
                touchNote.SetRotation(rot);
            }

            // FlickNote
            else if(noteData.type == (int)NOTE.TYPE.FlickNote) {
                int[] lanes   = noteData.lanes;
                string lr     = noteData.lr;
                bool isPaired = noteData.pair;
                bool isHead   = (noteData.options[0] == 0) ? true : false;
                float time    = calcTime(noteData);
                float pos     = time * noteSpeed;
                float rot     = LANE.ANGLES[lanes[0]];

                GameObject flickNoteObj = Instantiate(
                    flickNotePrefab,
                    notesParent.transform
                );

                FlickNote flickNote = flickNoteObj.GetComponent<FlickNote>();
                flickNote.Init(id:id, lanes:lanes, time:time, lr:lr, isPaired:isPaired, isHead:isHead);
                flickNote.SetPosition(pos);
                flickNote.SetRotation(rot);
            }

            // LongNote
            else if(noteData.type == (int)NOTE.TYPE.LongNote) {

                string lr        = noteData.lr;
                int[] startLanes = noteData.lanes;
                float startTime  = calcTime(noteData);
                int[] options    = noteData.options;
                float pos = startTime * noteSpeed;
                float rot = LANE.ANGLES[startLanes[0]];

                GameObject longNoteObj = Instantiate(
                    longNotePrefab,
                    notesParent.transform
                );

                LongNote longNote = longNoteObj.GetComponent<LongNote>();
                longNote.SetPosition(pos);
                longNote.SetRotation(rot);

                foreach(NoteData child in noteData.children) {
                    // End
                    if(child.type == (int)NOTE.TYPE.LongEnd) {
                        int[] endLanes = child.lanes;
                        float endTime  = calcTime(child);
                        float length = child.timing - noteData.timing;

                        longNote.Init(
                            id:id, lr:lr, startLanes:startLanes, endLanes:endLanes,
                            startTime:startTime, endTime:endTime, length:length, options:options
                        );
                    }

                    // Mid
                    if(child.type == (int)NOTE.TYPE.LongMid) {
                        int[] _lanes = child.lanes;
                        float _time  = calcTime(child);
                        float _pos   = _time * noteSpeed;
                        float _rot   = LANE.ANGLES[_lanes[0]];

                        GameObject longChildNoteObj = Instantiate(
                            longChildNotePrefab,
                            notesParent.transform
                        );

                        LongChildNote longChildNote = longChildNoteObj.GetComponent<LongChildNote>();
                        longChildNote.Init(id:id, lanes:_lanes, time:_time, parent:longNote);
                        longChildNote.SetPosition(_pos);
                        longChildNote.SetRotation(_rot);
                    }
                }
            }

            id++;
        }
    }
}
