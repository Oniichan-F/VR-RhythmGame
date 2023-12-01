using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class TouchNote : Note
{
    [SerializeField] private Mesh[] meshes;

    [SerializeField] private List<Material> mats;

    public int size { private set; get; }

    private void Start()
    {
        SetMesh();
        SetMaterials();
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

    public void Init(int id, int[] lanes, float time, string lr, int[] options)
    {
        base.Init(id, lanes, time, lr);

        this.type = (int)NOTE.TYPE.TouchNote;
        this.size = lanes.Length / 2;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterials()
    {
        mesh.GetComponent<MeshRenderer>().SetMaterials(mats);

    }

    protected override void Judge()
    {
        void effectProcess(string lr) {
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, 0, lanes);
            noteEffectManager.VibrateImpulse(lr, 0.5f, 0.1f);
        }

        if(lr == "R" && lanes.Contains(oculusInputManager.rLane)) {
            effectProcess("R");
            scoreManager.AddScore((int)JUDGE.JUDGE_ID.JUST);
            Destroy(this.gameObject);                
        }
        else if(lr == "L" && lanes.Contains(oculusInputManager.lLane)) {
            effectProcess("L");
            scoreManager.AddScore((int)JUDGE.JUDGE_ID.JUST);
            Destroy(this.gameObject);                
        }
        else if(lr == "" && lanes.Contains(oculusInputManager.rLane)) {
            effectProcess("R");
            scoreManager.AddScore((int)JUDGE.JUDGE_ID.JUST);
            Destroy(this.gameObject);
        }
        else if(lr == "" && lanes.Contains(oculusInputManager.lLane)) {
            effectProcess("L");
            scoreManager.AddScore((int)JUDGE.JUDGE_ID.JUST);
            Destroy(this.gameObject);                  
        }
        else {
            scoreManager.AddScore(-1);
            Destroy(this.gameObject);              
        }
    }

    protected override void AutoJudge()
    {
        if(time < 0f) {
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
            scoreManager.AddScore((int)JUDGE.JUDGE_ID.JUST);
            Destroy(this.gameObject);
        }
    }
}
