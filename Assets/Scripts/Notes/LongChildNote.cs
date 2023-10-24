using System.Collections;
using System.Collections.Generic;
using General.CONSTS;
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

        if(!RhythmGameManager.Instance.isAutoMode) {

        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();
    }

    public void Init(int id, int[] lanes, float time, LongNote parent)
    {
        base.Init(id, lanes, time, "", false);
        this.parent = parent;

        this.size = lanes.Length / 2;
        this.speed    = RhythmGameManager.Instance.noteSpeed;
        mesh = transform.Find("Mesh").gameObject;

        this.type   = (int)NOTE.TYPE.LongMid;
        this.seType = (int)SE.NOTE_SE.HitWeak;
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

    protected override void AutoJudge()
    {
        if(parent.state == (int)LONGNOTE.STATE.Active) {
            if(time < 0f) {
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
        }
    }
}
