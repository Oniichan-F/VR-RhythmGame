using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
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
        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        CheckDestory();

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

    public override void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;

        this.type   = (int)NOTE.TYPE.TouchNote;
        this.seType = (int)SE.NOTE_SE.HitWeak;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    protected override void Judge()
    {
        if(OVRInput.Get(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
            Debug.Log(id + ": Just(R) " + time);
            noteEffectManager.PlaySE(seType);
            Destroy(this.gameObject);
        }
        else if(OVRInput.Get(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
            Debug.Log(id + ": Just(L) " + time);
            noteEffectManager.PlaySE(seType);
            Destroy(this.gameObject);
        }
        else {
            Debug.Log(id + ": Miss");
            Destroy(this.gameObject);
        }
    }
}
