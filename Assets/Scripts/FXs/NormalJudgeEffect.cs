using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.CONSTS;
using UnityEngine.Rendering;

public class NormalJudgeEffect : JudgeEffect
{
    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (speed * Time.deltaTime));
    }
}
