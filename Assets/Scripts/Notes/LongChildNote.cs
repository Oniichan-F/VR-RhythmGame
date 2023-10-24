using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongChildNote : Note
{
    [SerializeField] private Mesh[] meshes;

    private LongNote parent;
    public bool isVisible;

    private void Start()
    {
        SetMesh();
        SetVisibility();
    }

    private void Update()
    {
        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        CheckDestory();
        UpdatePosition();
        UpdateTime();
    }

    public void Init(int id, int[] lanes, float time, LongNote parent)
    {
        this.id     = id;
        this.lanes  = lanes;
        this.time   = time;
        this.parent = parent;

        this.size = lanes.Length / 2;
        this.speed    = RhythmGameManager.Instance.noteSpeed;
        mesh = transform.Find("Mesh").gameObject;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetVisibility()
    {
        if(isVisible) {
            mesh.GetComponent<Renderer>().enabled = true;
        }
        else {
            mesh.GetComponent<Renderer>().enabled = false;
        }
    }
}
