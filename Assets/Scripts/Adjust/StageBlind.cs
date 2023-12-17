using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlind : MonoBehaviour
{
    private void Start()
    {
        float z = OffsetManager.Instance.playerGenerationDepth;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
