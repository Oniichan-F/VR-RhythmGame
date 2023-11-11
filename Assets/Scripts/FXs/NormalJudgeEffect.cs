using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.CONSTS;
using UnityEngine.Rendering;

public class NormalJudgeEffect : JudgeEffect
{
    private float t;

    private void Start()
    {
        t = 0f;
    }

    private void Update()
    {
        float deltaScale = 0f;
        if(t < 0.1f) {
            deltaScale = speed * Time.deltaTime;
        }
        else {
            deltaScale = -1f * speed * Time.deltaTime / 1.5f;
        }
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + deltaScale);
        t += Time.deltaTime;
    }
}
