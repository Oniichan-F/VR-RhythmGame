using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BPMGuide : MonoBehaviour
{
    [SerializeField] Mesh[] shapes;
    [SerializeField] Material[] colors;

    public float speed { private set; get; }
    public float time { private set; get; }
    private int shape;
    private int color;

    private void Start()
    {
        speed = RhythmGameManager.Instance.noteSpeed;    
    }

    private void Update()
    {
        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed*Time.deltaTime));
        time -= Time.deltaTime;
    }

    public void Init(int shape, int color, float time, float pos)
    {
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
        GetComponent<MeshRenderer>().material = colors[color];
    }
}
