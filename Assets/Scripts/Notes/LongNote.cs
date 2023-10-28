using System.Collections;
using System.Collections.Generic;
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

    public bool isHead { private set; get; }
    public int[] startLanes { private set; get; }
    public int[] endLanes { private set; get; }
    public float startTime { private set; get; }
    public float endTime { private set; get; }
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

        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();
    }

    public void Init(int id, string lr, int[] startLanes, int[] endLanes, float startTime, float endTime, float length, int[] options)
    {
        base.Init(id, null, 0f, lr, false);
        this.startLanes = startLanes;
        this.endLanes   = endLanes;
        this.startTime  = startTime;
        this.endTime    = endTime;
        this.length     = length;
        this.size       = startLanes.Length / 2;

        this.rotDirection = options[1];
        this.numRotation  = options[2];

        this.isHead = (options[0] == 0) ? true : false;
        this.state = (int)LONGNOTE.STATE.inActive;

        transform.localScale = new Vector3(1f, 1f, length*speed*1.25f*(60f/RhythmGameManager.Instance.BPM));

        this.type   = (int)NOTE.TYPE.LongNote;
        this.seType = (int)SE.NOTE_SE.HitStandard; // TEST
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
        if(endTime < -1f) {
            Destroy(this.gameObject);
        }
    }

    protected override void AutoJudge()
    {
        if(state == (int)LONGNOTE.STATE.inActive) {
            if(isHead) {
                if(startTime < 0f) {
                    noteEffectManager.PlaySE(seType);
                    state = (int)LONGNOTE.STATE.Active;
                }
            }
        }
    }
}
