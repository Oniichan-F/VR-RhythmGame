using System.Collections;
using System.Collections.Generic;
using System.Linq;
using General.CONSTS;
using UnityEngine;

public class FlickNote : Note
{
    [SerializeField] private Mesh[] meshes;
    [SerializeField] private List<Material> matsPair;

    public bool isHead;
    private int judgeState;
    private int judgeLR; // L=0, R=1
    private float judgeCount = 0.3f;

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

        if(judgeState == 0) {
            CheckDestory();
        }
        
        if(!RhythmGameManager.Instance.isAutoMode) {
            if(time < (int)JUDGE.THRESH) {
                Judge();
            }
        }
        else {
            AutoJudge();
        }

        UpdatePosition();
        UpdateTime();        
    }

    public void Init(int id, int[] lanes, float time, string lr, bool isPaired, bool isHead)
    {
        base.Init(id, lanes, time, lr, isPaired);
        this.size = lanes.Length / 2;
        this.isHead = isHead;
        this.judgeState = 0;
        judgeLR = -1;

        this.type   = (int)NOTE.TYPE.FlickNote;
        this.seType = (int)SE.NOTE_SE.HitStrong;
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
        if(judgeState == 0) {
            if(isHead) {
                if(Mathf.Abs(time) < JUDGE.JUST*1.2f) {
                    if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                        judgeState = 1;
                        judgeLR = 1;
                    }
                    else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                        judgeState = 1;
                        judgeLR = 0;
                    }
                }
                else if(Mathf.Abs(time) < JUDGE.GREAT*1.2f) {
                    if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                        judgeState = 2;
                        judgeLR = 1;
                    }
                    else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                        judgeState = 2;
                        judgeLR = 0;
                    }
                }
                else if(Mathf.Abs(time) < JUDGE.GOOD*1.2f) {
                    if(OVRInput.GetDown(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                        judgeState = 3;
                        judgeLR = 1;
                    }
                    else if(OVRInput.GetDown(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                        judgeState = 3;
                        judgeLR = 0;
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
            else {
                if(time < 0f) {
                    if(OVRInput.Get(OVRInput.Button.One) && lanes.Contains(oculusInputManager.rLane)) {
                        judgeState = 1;
                        judgeLR = 1;
                    }
                    else if(OVRInput.Get(OVRInput.Button.Three) && lanes.Contains(oculusInputManager.lLane)) {
                        judgeState = 1;
                        judgeLR = 0;
                    }
                    else {
                        Debug.Log(id + ": Miss");
                        Destroy(this.gameObject);
                    }
                }               
            }
        }
        else {
            if(0f < judgeCount) {
                if(judgeLR == 1) {
                    if(oculusInputManager.rLane == -1) {
                        if(judgeState == 1) {
                            Debug.Log(id + ": Just(R) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                        else if(judgeState == 2) {
                            Debug.Log(id + ": Great(R) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                        else if(judgeState == 3) {
                            Debug.Log(id + ": Good(R) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                    }
                }
                else if(judgeLR == 0) {
                    if(oculusInputManager.lLane == -1) {
                        if(judgeState == 1) {
                            Debug.Log(id + ": Just(L) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                        else if(judgeState == 2) {
                            Debug.Log(id + ": Great(L) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                        else if(judgeState == 3) {
                            Debug.Log(id + ": Good(L) " + time);
                            noteEffectManager.PlaySE(seType);
                            Destroy(this.gameObject);
                        }
                    }
                }

                judgeCount -= Time.deltaTime;
            }
        }
    }
}
