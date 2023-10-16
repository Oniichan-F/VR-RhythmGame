using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OffsetManager : MonoBehaviour
{
    private static OffsetManager instance;
    public static OffsetManager Instance => instance;

    public float stageScaleOffset;
    public float stageHeightOffset;

    private void Awake()
    {
        if(instance && this != instance) {
            Destroy(this.gameObject);
        }

        instance = this;

        stageScaleOffset  = 1f;
        stageHeightOffset = 1f;

        DontDestroyOnLoad(this);
    }
}
