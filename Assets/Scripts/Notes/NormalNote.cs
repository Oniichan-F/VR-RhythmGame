using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private Material matPair;

    private void Start()
    {
        SetMesh();
        SetMaterial();
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

    public override void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterial()
    {
        if(isPaired) {
            mesh.GetComponent<MeshRenderer>().material = matPair;
        }
    }
}
