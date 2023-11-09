using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.CONSTS;

public class JudgeEffect : MonoBehaviour
{
    [SerializeField] protected Mesh[] meshes;
    [SerializeField] protected Material[] mats;
    [SerializeField] protected float speed = 20f;

    protected GameObject mesh;
    protected int judgeID;
    protected int size;

    public void Init(int judgeID, int[] lanes)
    {
        this.judgeID = judgeID;
        this.size = lanes.Length / 2;

        transform.rotation = Quaternion.Euler(0f, 0f, LANE.ANGLES[lanes[0]]);

        mesh = transform.Find("Mesh").gameObject;
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
        mesh.GetComponent<MeshRenderer>().material = mats[judgeID];
    }
}
