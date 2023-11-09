using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class NormalNote : Note
{
    [SerializeField] private Mesh[] meshes;

    [SerializeField] private List<Material> mats;
    [SerializeField] private List<Material> matsR;
    [SerializeField] private List<Material> matsL;
    [SerializeField] private List<Material> matsPair;
    [SerializeField] private List<Material> matsPairR;
    [SerializeField] private List<Material> matsPairL;


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

    public void Init(int id, int[] lanes, float time, string lr, int[] options)
    {
        base.Init(id, lanes, time, lr);
        
        this.type = (int)NOTE.TYPE.NormalNote;
        this.size = lanes.Length / 2;
        this.isPaired = options[0] == 0 ? true : false;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterials()
    {
        if(lr == "") {
            if(!isPaired) { mesh.GetComponent<MeshRenderer>().SetMaterials(mats); }
            else { mesh.GetComponent<MeshRenderer>().SetMaterials(matsPair); }
        }
        else if(lr == "R") {
            if(!isPaired) { mesh.GetComponent<MeshRenderer>().SetMaterials(matsR); }
            else { mesh.GetComponent<MeshRenderer>().SetMaterials(matsPairR); }
        }
        else if(lr == "L") {
            if(!isPaired) { mesh.GetComponent<MeshRenderer>().SetMaterials(matsL); }
            else { mesh.GetComponent<MeshRenderer>().SetMaterials(matsPairL); }
        }
    }

    protected override void Judge()
    {
        // Just
        if(Mathf.Abs(time) < JUDGE.JUST) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Just " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Just " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
                Destroy(this.gameObject);                
            }
            else if((lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) ||
                    (lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane))) {
                Debug.Log(id + ": Just " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.JUST, lanes);
                Destroy(this.gameObject);                  
            }
        }
        // Great
        else if(Mathf.Abs(time) < JUDGE.GREAT) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Great " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GREAT, lanes);
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Great " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GREAT, lanes);
                Destroy(this.gameObject);                
            }
            else if((lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) ||
                    (lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane))) {
                Debug.Log(id + ": Great " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GREAT, lanes);
                Destroy(this.gameObject);                  
            }
        }
        // Good
        else if(Mathf.Abs(time) < JUDGE.GOOD) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Good " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GOOD, lanes);
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Good " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GOOD, lanes);
                Destroy(this.gameObject);                
            }
            else if((lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) ||
                    (lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane))) {
                Debug.Log(id + ": Good " + time);
                noteEffectManager.PlaySE(type);
                noteEffectManager.GenerateJudgeEffect(type, (int)JUDGE.JUDGE_ID.GOOD, lanes);
                Destroy(this.gameObject);                  
            }
        }
        // Miss
        else {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Miss " + time);
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Miss " + time);
                Destroy(this.gameObject);                
            }
            else if((lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.rLane)) ||
                    (lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.External && lanes.Contains(oculusInputManager.lLane))) {
                Debug.Log(id + ": Miss " + time);
                Destroy(this.gameObject);                  
            }
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
