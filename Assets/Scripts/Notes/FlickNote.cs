using System.Collections;
using System.Collections.Generic;
using General.CONSTS;
using UnityEngine;

public class FlickNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private List<Material> matsPair;

    public bool isHead;

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
        
        if(!RhythmGameManager.Instance.isAutoMode) {

        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();        
    }

    public void Init(int id, int[] lanes, float time, string lr, bool isPaired, bool isHead)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;
        this.isHead = isHead;

        this.type   = (int)NOTE.TYPE.FlickNote;
        this.seType = (int)SE.NOTE_SE.HitStrong;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterial()
    {
        if(isPaired) {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsPair);
        }
    }
}
