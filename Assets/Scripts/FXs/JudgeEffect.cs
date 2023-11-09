using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.CONSTS;
using UnityEngine.Rendering;

public class JudgeEffect : MonoBehaviour
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private Material[] mats;
    [SerializeField] private float speed = 20f;

    private GameObject mesh;
    private int judgeID;
    private int[] lanes;
    private int size;

    private void Start()
    {
        mesh = transform.Find("Mesh").gameObject;
        mesh.GetComponent<MeshFilter>().mesh = meshes[size-1];
        mesh.GetComponent<MeshRenderer>().material = mats[judgeID];
    }

    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (speed * Time.deltaTime));
    }

    public void Init(int judgeID, int[] lanes)
    {
        this.judgeID = judgeID;
        this.lanes = lanes;
        this.size = lanes.Length / 2;

        transform.rotation = Quaternion.Euler(0f, 0f, LANE.ANGLES[lanes[0]]);
    }
}
