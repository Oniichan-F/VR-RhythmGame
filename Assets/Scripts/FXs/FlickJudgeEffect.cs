using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickJudgeEffect : JudgeEffect
{
    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z*60f);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
    }
}
