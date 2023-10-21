using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int id { private set; get; }
    public int[] lanes { private set; get; }
    public int size { private set; get; }
    public float time { private set; get; }
    public float speed { private set; get; }
    public string lr { private set; get; }
    public bool isPaired { private set; get; }

    protected GameObject mesh;


    public virtual void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        this.id       = id;
        this.lanes    = lanes;
        this.size     = lanes.Length / 2;
        this.time     = time;
        this.lr       = lr;
        this.isPaired = isPaired;
        this.speed    = RhythmGameManager.Instance.noteSpeed;

        mesh = transform.Find("Mesh").gameObject;
    }

    protected virtual void SetMesh()
    {

    }

    protected virtual void UpdateTime()
    {
        time -= Time.deltaTime;
    }

    protected virtual void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed*Time.deltaTime));
    }

    protected virtual void Judge()
    {

    }

    public void SetPosition(float pos)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, pos);
    }

    public void SetRotation(float rot)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
    }
}
