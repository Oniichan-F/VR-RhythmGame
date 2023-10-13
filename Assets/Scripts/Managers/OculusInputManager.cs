using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusInputManager : MonoBehaviour
{
    [SerializeField] Transform TrackingSpace;

    private Vector3 rPos, lPos;
    private void Update()
    {
        Vector3 localRPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 localLPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rPos = TrackingSpace.TransformPoint(localRPos);
        lPos = TrackingSpace.TransformPoint(localLPos);

        Debug.Log("rPos: " + rPos + " / lPos: " + lPos);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10,10,100,20), rPos.ToString());
    }
}
