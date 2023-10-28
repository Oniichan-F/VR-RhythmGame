using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
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

        if(!RhythmGameManager.Instance.isAutoMode) {
            if(time < JUDGE.THRESH) {
                Judge();
            }
        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();
    }

    public override void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;

        this.type   = (int)NOTE.TYPE.NormalNote;
        this.seType = (int)SE.NOTE_SE.HitStandard;
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

    protected override void Judge()
    {
        if(Mathf.Abs(time) < JUDGE.JUST) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Just(R) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Just(L) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
        }
        else if(Mathf.Abs(time) < JUDGE.GREAT) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Great(R) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Great(L) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
        }
        else if(Mathf.Abs(time) < JUDGE.GOOD) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Good(R) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Good(L) " + time);
                noteEffectManager.PlaySE(seType);
                Destroy(this.gameObject);
            }
        }
        else {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Miss(R) " + time);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Miss(L) " + time);
                Destroy(this.gameObject);
            }
        }
    }
}
