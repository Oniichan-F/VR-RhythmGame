using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class StageScaler : MonoBehaviour
{
    [SerializeField] float scaleFactor = 1.0f;
    [SerializeField] OculusInputManager oculusInputManager;
    [SerializeField] Button finishButton;
    [SerializeField] Image gauge;

    private Transform masterScaler;
    private GameObject blind;

    private bool isFirst = true;
    private float triggerCount = 0f;


    private void Start()
    {
        masterScaler = GameObject.Find("MasterScaler").transform;
        blind = GameObject.Find("Blind");
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)) {
            triggerCount += Time.deltaTime;
            gauge.fillAmount = triggerCount / 3f;

            if(triggerCount > 3f) {
                SetScaler();

                if(isFirst) {
                    Destroy(blind.gameObject);
                    finishButton.interactable = true;
                    isFirst = false;
                }

                triggerCount = -100f;       
            }
        }
        else {
            triggerCount = 0f;
            gauge.fillAmount = 0f;
        }
    }

    private void SetScaler() {
        void setScale(Vector3 rPos, Vector3 lPos) {
            float r = Mathf.Abs(rPos.x) + Mathf.Abs(lPos.x) * 100f * scaleFactor;
            masterScaler.localScale = new Vector3(r, r, masterScaler.localScale.z);
            OffsetManager.Instance.stageScaleOffset = r / 100f;
            Debug.Log("Set Scale: " + r);
        }

        void setHeight(Vector3 rPos, Vector3 lPos) {
            float h = (rPos.y + lPos.y) / 2f;
            masterScaler.position = new Vector3(masterScaler.position.x, h, masterScaler.position.z);
            OffsetManager.Instance.stageHeightOffset = h;
            Debug.Log("Set Height: " + h);
        }

        Vector3 rPos = oculusInputManager.globalRPos;
        Vector3 lPos = oculusInputManager.globalLPos;
        setScale(rPos, lPos);
        setHeight(rPos, lPos);
    }
}
