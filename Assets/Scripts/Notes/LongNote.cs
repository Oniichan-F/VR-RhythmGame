using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Deform;
using General.CONSTS;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LongNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private List<Material> matsR;
    [SerializeField] private List<Material> matsL;
    [SerializeField] private List<Material> matsLostR;
    [SerializeField] private List<Material> matsLostL;

    public int[] startLanes { private set; get; }
    public int[] endLanes { private set; get; }
    public float startTime { private set; get; }
    public float endTime { private set; get; }
    public int size { private set; get; }
    public float length { private set; get; }

    public int state;

    private TwistDeformer twistDeformer;
    private int rotDirection; // 1=CCW, -1=CW
    private int numRotation;


    private void Start()
    {
        SetMesh();
        SetMaterial();
        twistDeformer = mesh.transform.Find("Twist").GetComponent<TwistDeformer>();
        Twist();
    }

    private void Update()
    {
        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        CheckDestory();

        if(!RhythmGameManager.Instance.isAutoMode) {
            if(startTime < 0f) {
                Judge();
            }
        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();
    }

    public void Init(int id, string lr, int[] startLanes, int[] endLanes, float startTime, float endTime, float length, int[] options)
    {
        base.Init(id, null, 0f, lr);
        
        this.type   = (int)NOTE.TYPE.LongNote;
        this.startLanes = startLanes;
        this.endLanes   = endLanes;
        this.startTime  = startTime;
        this.endTime    = endTime;
        this.length     = length;
        this.size       = startLanes.Length / 2;

        this.rotDirection = options[0];
        this.numRotation  = options[1];

        this.state = (int)LONGNOTE.STATE.inActive;

        transform.localScale = new Vector3(1f, 1f, length*speed*1.25f*(60f/RhythmGameManager.Instance.BPM));
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetMaterial()
    {
        if(lr == "R") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsR);
        }
        else if(lr == "L") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsL);
        }
    }

    private void Twist()
    {
        int rot = 0;
        if(rotDirection == 1) {
            rot = Mathf.Abs(endLanes[0] - startLanes[0]);
        }
        else if(rotDirection == -1) {
            if(startLanes[0] < endLanes[0]) {
                rot = Mathf.Abs((32 - endLanes[0]) + startLanes[0]);
            }
            else if(startLanes[0] > endLanes[0]) {
                rot = Mathf.Abs((32 - startLanes[0]) + endLanes[0]);
            }
        }
        else {
            Debug.Log("rotDirection is unexpected");
        }

        twistDeformer.EndAngle = (-rot * 11.25f - (numRotation * 360f)) * rotDirection;
    }

    protected override void UpdateTime()
    {
        startTime -= Time.deltaTime;
        endTime -= Time.deltaTime;
    }

    protected override void CheckDestory()
    {
        if(startTime < -JUDGE.THRESH) {
            if(state == (int)LONGNOTE.STATE.inActive) {
                state = (int)LONGNOTE.STATE.Lost;
                SetLostMaterials();
            }   
        }

        if(endTime < -0.1f) {
            Destroy(this.gameObject);
        }
    }

    protected override void Judge()
    {
        if(state == (int)LONGNOTE.STATE.inActive) {
            if(lr == "R" && startLanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Hold Enter");
                noteEffectManager.PlaySE(type);
                state = (int)LONGNOTE.STATE.Active;               
            }
            else if(lr == "L" && startLanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Hold Enter");
                noteEffectManager.PlaySE(type);
                state = (int)LONGNOTE.STATE.Active;          
            }
            else if((lr == "" && startLanes.Contains(oculusInputManager.rLane)) ||
                    (lr == "" && startLanes.Contains(oculusInputManager.lLane))) {
                Debug.Log(id + ": Hold Enter");
                noteEffectManager.PlaySE(type);
                state = (int)LONGNOTE.STATE.Active;                
            }
        }
    }

    protected override void AutoJudge()
    {
        if(state == (int)LONGNOTE.STATE.inActive) {
            if(startTime < 0f) {
                noteEffectManager.PlaySE(type);
                state = (int)LONGNOTE.STATE.Active;
            }
        }
    }

    public void SetLostMaterials()
    {
        if(lr == "R") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsLostR);
        }
        else if(lr == "L") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsLostL);
        }
    }
}
