using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StageScaler : MonoBehaviour
{
    [SerializeField] Transform masterScaler;
    [SerializeField] OculusInputManager oculusInputManager;
    [SerializeField] float scaleFactor = 1.2f;


    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Four)) { // Y
            SetScaler();
        }
    }

    private void SetScaler() {
        void setScale(Vector3 rPos, Vector3 lPos) {
            float r = Mathf.Abs(rPos.x) + Mathf.Abs(lPos.x) * 100f * scaleFactor;
            masterScaler.localScale = new Vector3(r, r, r);
            OffsetManager.Instance.stageScaleOffset = r / 100f;
            Debug.Log("Set Scale: " + r);
        }

        void setHeight(Vector3 rPos, Vector3 lPos) {
            float h = (rPos.y + lPos.y) / 2f;
            masterScaler.position = new Vector3(masterScaler.position.x, h, masterScaler.position.z);
            OffsetManager.Instance.stageHeightOffset = h;
            Debug.Log("Set Height: " + h);
        }

        Vector3 rPos = oculusInputManager.rPos;
        Vector3 lPos = oculusInputManager.lPos;
        setScale(rPos, lPos);
        setHeight(rPos, lPos);
    }
}
