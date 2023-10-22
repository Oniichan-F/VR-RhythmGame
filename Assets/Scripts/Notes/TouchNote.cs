using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchNote : Note
{
    [SerializeField] private Mesh[] meshes;


    private void Start()
    {
        SetMesh();
    }

    private void Update()
    {

    }

    public override void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }
}
