using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    private static RhythmGameManager instance;
    public static RhythmGameManager Instance => instance;

    // Song Info
    public int songID;
    public string songDisplayName;
    public string songSourceName;
    public string songChartName;
    public float BPM;
    public int LPB;
    public int maxBeatNum;
    public float baseChartOffset;

    public float noteSpeed { private set; get; }
    public float chartOffset { private set; get; }

    // Game State
    public bool isPaused;


    private void Awake()
    {
        if(instance && this != instance) {
            Destroy(this.gameObject);
        }

        isPaused = true;

        instance = this;

        DontDestroyOnLoad(this);
    }

    public void SetOffsets()
    {
        noteSpeed   = OffsetManager.Instance.playerNoteSpeed;
        chartOffset = baseChartOffset + OffsetManager.Instance.playerChartOffset;
    }
}
