using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OffsetManager : MonoBehaviour
{
    private static OffsetManager instance;
    public static OffsetManager Instance => instance;

    // Stage Offset
    public float stageScaleOffset;
    public float stageHeightOffset;

    // RhythmGame Offset
    public float playerNoteSpeed;
    public float playerChartOffset;
    public float playerGenerationDepth;

    private void Awake()
    {
        // if(instance && this != instance) {
        //     Destroy(this.gameObject);
        // }

        // instance = this;

        // stageScaleOffset  = 1f;
        // stageHeightOffset = 1f;

        // DontDestroyOnLoad(this);

        if(instance == null) {
            instance = this;

            stageScaleOffset  = 1f;
            stageHeightOffset = 1f;

            playerNoteSpeed       = 3f;
            playerChartOffset     = 0f;
            playerGenerationDepth = 30f;

            DontDestroyOnLoad(this);           
        }
    }
}
