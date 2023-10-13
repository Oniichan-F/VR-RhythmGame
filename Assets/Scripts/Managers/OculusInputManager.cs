using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OculusInputManager : MonoBehaviour
{
    [SerializeField] Transform TrackingSpace;

    // Debug Area ->
    [SerializeField] TextMeshProUGUI RTouchText, LTouchText;
    // Debug Area <-

    private Vector3 rPos, lPos;
    private void Update()
    {
        Vector3 localRPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 localLPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rPos = TrackingSpace.TransformPoint(localRPos);
        lPos = TrackingSpace.TransformPoint(localLPos);

        // Debug Area ->
        //Debug.Log("rPos: " + rPos + " / lPos: " + lPos);
        RTouchText.text = "RTouch: " + rPos;
        LTouchText.text = "LTouch: " + lPos; 
        // Debug Area <-
    }
}
