using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BPMGuide : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = 0f;    
    }

    private void Update()
    {
        if(RhythmGameManager.Instance.isPaused) {
            speed = 0f;
        }
        else {
            speed = RhythmGameManager.Instance.noteSpeed;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed*Time.deltaTime));
    }
}
