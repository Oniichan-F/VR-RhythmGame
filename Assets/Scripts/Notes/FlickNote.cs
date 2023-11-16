using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class FlickNote : Note
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

    public void Init(int id, int[] lanes, float time, string lr, int[] options)
    {
        base.Init(id, lanes, time, lr);
        
        this.type = (int)NOTE.TYPE.FlickNote;
        this.size = lanes.Length / 2;
        this.isPaired = options[0] == 0 ? true : false;
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterial()
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
        void effectProcess(int judgeID, string lr) {
            noteEffectManager.PlaySE(type);
            noteEffectManager.GenerateJudgeEffect(type, judgeID, lanes);
            noteEffectManager.VibrateImpulse(lr, 1f, 0.5f);
        }

        // Just
        if(Mathf.Abs(time) < JUDGE.JUST) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.JUST, "R");
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.JUST, "L");
                Destroy(this.gameObject);                
            }
            else if(lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.JUST, "R");
                Destroy(this.gameObject);    
            }
            else if(lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.JUST, "L");
                Destroy(this.gameObject);                  
            }
        }
        // Great
        else if(Mathf.Abs(time) < JUDGE.GREAT) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GREAT, "R");
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GREAT, "L");
                Destroy(this.gameObject);                
            }
            else if(lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GREAT, "R");
                Destroy(this.gameObject);    
            }
            else if(lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GREAT, "L");
                Destroy(this.gameObject);                  
            }
        }
        // Good
        else if(Mathf.Abs(time) < JUDGE.GOOD) {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GOOD, "R");
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GOOD, "L");
                Destroy(this.gameObject);                
            }
            else if(lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GOOD, "R");
                Destroy(this.gameObject);    
            }
            else if(lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                effectProcess((int)JUDGE.JUDGE_ID.GOOD, "L");
                Destroy(this.gameObject);                  
            }
        }
        // Miss
        else {
            if(lr == "R" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                Destroy(this.gameObject);                
            }
            else if(lr == "L" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
                Destroy(this.gameObject);                
            }
            else if(lr == "" && oculusInputManager.rImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.rLane)) {
                Destroy(this.gameObject); 
            }
            else if(lr == "" && oculusInputManager.lImpact == (int)INPUT.IMPACT.Internal && lanes.Contains(oculusInputManager.lLane)) {
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
