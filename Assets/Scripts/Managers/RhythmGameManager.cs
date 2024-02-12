using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    private static RhythmGameManager instance;
    public static RhythmGameManager Instance => instance;

    // Song Info
    public SongInfo songInfo;
    public string songDisplayName;
    public string songSourceName;
    public string songChartName;
    public float BPM;
    public int LPB;

    public int numNotes;
    public float baseChartOffset;
    public int endTiming;

    public float noteSpeed { private set; get; }
    public float chartOffset { private set; get; }

    // Game State
    public bool isAutoMode;
    public bool isStart;
    public bool isPaused;

    // Score
    public float score;
    public int justCount;


    private void Awake()
    {
        // if(instance && this != instance) {
        //     Destroy(this.gameObject);
        // }

        // isAutoMode = false;
        // isPaused   = true;

        // instance = this;

        // DontDestroyOnLoad(this);

        if(instance == null) {
            instance = this;

            isAutoMode = false;
            isStart    = false;
            isPaused   = true;

            DontDestroyOnLoad(this); 
        }
    }

    public void SetOffsets()
    {
        noteSpeed   = 10f * OffsetManager.Instance.playerNoteSpeed;
        chartOffset = baseChartOffset + OffsetManager.Instance.playerChartOffset;
    }

    public void SetSongInfo()
    {
        songDisplayName = songInfo.songDisplayName;
        songSourceName  = songInfo.songSourceName;
        songChartName   = songInfo.songChartName;
        BPM = songInfo.BPM;
        LPB = songInfo.LPB;
    }
}
