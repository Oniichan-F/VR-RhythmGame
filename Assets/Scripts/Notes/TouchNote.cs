using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class TouchNote : Note
{
    [SerializeField] private Mesh[] meshes;

    [SerializeField] private List<Material> mats;
    [SerializeField] private List<Material> matsPair;

    public int size { private set; get; }
    public bool isPaired { private set; get; }

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
        this.isPaired = options[0] == 0 ? true : false;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterials()
    {
        if(!isPaired) {
            mesh.GetComponent<MeshRenderer>().SetMaterials(mats);
        }
        else {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsPair);
        }
    }

    protected override void Judge()
    {
        if(lr == "R" && lanes.Contains(oculusInputManager.rLane)) {
            Debug.Log(id + ": Just " + time);
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
            Destroy(this.gameObject);                
        }
        else if(lr == "L" && lanes.Contains(oculusInputManager.lLane)) {
            Debug.Log(id + ": Just " + time);
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
            Destroy(this.gameObject);                
        }
        else if((lr == "" && lanes.Contains(oculusInputManager.rLane)) ||
                (lr == "" && lanes.Contains(oculusInputManager.lLane))) {
            Debug.Log(id + ": Just " + time);
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
            Destroy(this.gameObject);                  
        }
        else {
            Debug.Log(id + ": Lost " + time);
            Destroy(this.gameObject);              
        }
    }

    protected override void AutoJudge()
    {
        if(time < 0f) {
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
            Destroy(this.gameObject);
        }
    }
}
