using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class FlickNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private List<Material> matsPair;

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
        if(isPaired) {
            mesh.GetComponent<MeshRenderer>().SetMaterials(matsPair);
        }
    }

    protected override void Judge()
    {
        if(Mathf.Abs(time) < JUDGE.JUST) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Just(R) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Just(L) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
        }
        else if(Mathf.Abs(time) < JUDGE.GREAT) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Great(R) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Great(L) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
        }
        else if(Mathf.Abs(time) < JUDGE.GOOD) {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Good(R) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Good(L) " + time);
                noteEffectManager.PlaySE(type);
                Destroy(this.gameObject);
            }
        }
        else {
            if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                Debug.Log(id + ": Miss(R) " + time);
                Destroy(this.gameObject);
            }
            else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                Debug.Log(id + ": Miss(L) " + time);
                Destroy(this.gameObject);
            }
        }
    }
}
