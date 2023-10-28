using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour
{
    public int id { protected set; get; }
    public int[] lanes { protected set; get; }
    public int size { protected set; get; }
    public float time { protected set; get; }
    public float speed { protected set; get; }
    public string lr { protected set; get; }
    public bool isPaired { protected set; get; }

    protected GameObject mesh;
    protected NoteEffectManager noteEffectManager;
    protected OculusInputManager oculusInputManager;
    protected int type;
    protected int seType;


    public virtual void Init(int id, int[] lanes, float time, string lr, bool isPaired)
    {
        this.id       = id;
        this.lanes    = lanes;
        this.time     = time;
        this.lr       = lr;
        this.isPaired = isPaired;
        
        this.speed    = RhythmGameManager.Instance.noteSpeed;
        mesh = transform.Find("Mesh").gameObject;
        noteEffectManager = GameObject.Find("NoteEffectManager").GetComponent<NoteEffectManager>();
        oculusInputManager = GameObject.Find("InputManager").GetComponent<OculusInputManager>();
    }

    protected virtual void SetMesh()
    {

    }

    protected virtual void UpdateTime()
    {
        time -= Time.deltaTime;
    }

    protected virtual void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed*Time.deltaTime));
    }

    protected virtual void Judge()
    {
        
    }

    protected virtual void AutoJudge()
    {
        if(time < 0f) {
            noteEffectManager.PlaySE(seType);
            Destroy(this.gameObject);
        }
    }

    protected virtual void CheckDestory()
    {
        if(time < -1f) {
            Destroy(this.gameObject);
        }
    }

    public void SetPosition(float pos)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, pos);
    }

    public void SetRotation(float rot)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rot);
    }
}
