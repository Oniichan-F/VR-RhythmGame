using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BPMGuide : MonoBehaviour
{
    [SerializeField] Mesh[] shapes;

    public float speed { private set; get; }
    public float time { private set; get; }
    private int shape;
    private float[] color;

    private void Start()
    {
        SetShape();
        SetColor();
    }

    private void Update()
    {
        CheckDestory();

        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed*Time.deltaTime));
        time -= Time.deltaTime;
    }

    public void Init(float speed, int shape, float[] color, float time, float pos)
    {
        this.speed = speed;
        this.shape = shape;
        this.color = color;
        this.time  = time;

        transform.position = new Vector3(transform.position.x, transform.position.y, pos);
    }

    private void CheckDestory()
    {
        if(time < -1f) {
            Destroy(this.gameObject);
        }
    }

    private void SetShape()
    {
        GetComponent<MeshFilter>().mesh = shapes[shape];
    }

    private void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(color[0], color[1], color[2], color[3]);
    }
}
