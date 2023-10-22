using System.Collections;
using System.Collections.Generic;
using Deform;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LongNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private List<Material> matR;
    [SerializeField] private List<Material> matL;

    public bool isHead { private set; get; }
    public int[] startLanes { private set; get; }
    public int[] endLanes { private set; get; }
    public float startTime { private set; get; }
    public float endTime { private set; get; }
    public float length { private set; get; }

    private TwistDeformer twistDeformer;
    private int rotDirection; // 1=CCW, -1=CW
    private int numRotation;


    private void Start()
    {
        SetMesh();
        SetLR();
        twistDeformer = mesh.transform.Find("Twist").GetComponent<TwistDeformer>();
        Twist();
    }

    private void Update()
    {

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

        this.rotDirection = options[0];
        this.numRotation  = options[1];

        if(options[2] == 0) { this.isHead = true; }
        else { this.isHead = false; }

        transform.localScale = new Vector3(1f, 1f, length*speed*1.25f);
    }

    protected override void SetMesh()
    {
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
    }

    private void SetLR()
    {
        if(lr == "R") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matR);
        }
        else if(lr == "L") {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matL);
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
}
