using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using Unity.VisualScripting;
using UnityEngine;

public class LongChildNote : Note
{
    [SerializeField] private bool isVisible;
    [SerializeField] private Mesh[] meshes;
    
    private LongNote parent;
    public int size { private set; get; }


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
        CheckState();

        if(!RhythmGameManager.Instance.isAutoMode) {
            if(time < 0f) {
                Judge();
            }
        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();
    }

    public void Init(int id, int[] lanes, float time, string lr, LongNote parent)
    {
        base.Init(id, lanes, time, lr);
        
        this.type = (int)NOTE.TYPE.LongChild;
        this.size = lanes.Length / 2;
        this.parent = parent;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void CheckState()
    {
        if(parent.state == (int)LONGNOTE.STATE.Lost) {
            Destroy(this.gameObject);
        }
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

    protected override void Judge()
    {
        if(lanes.Contains(oculusInputManager.rLane) || lanes.Contains(oculusInputManager.lLane)) {
            Debug.Log(id + ": Hold ");
            noteEffectManager.PlaySE(type);
            Destroy(this.gameObject);
        }
        else {
            Debug.Log(id + ": Miss ");
            parent.state = (int)LONGNOTE.STATE.Lost;
            parent.SetLostMaterials();
            parent.StopVibration();
            Destroy(this.gameObject);
        }
    }

    protected override void AutoJudge()
    {
        if(parent.state == (int)LONGNOTE.STATE.Active) {
            if(time < 0f) {
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
        }
    }
}
