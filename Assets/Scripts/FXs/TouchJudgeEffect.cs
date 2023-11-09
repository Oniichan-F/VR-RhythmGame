using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJudgeEffect : JudgeEffect
{
    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (speed * Time.deltaTime));
    }
}
