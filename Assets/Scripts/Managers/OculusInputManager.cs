using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OculusInputManager : MonoBehaviour
{
    [SerializeField] Transform TrackingSpace;
    
    // パネルの基礎反応感度
    [SerializeField] float baseThresh = 0.6f;
    // 反対側パネルの反応感度緩和補正
    [SerializeField] float oppositeCorrection = 0.5f;

    // Debug Area ->
    [SerializeField] TextMeshProUGUI RTouchText, LTouchText;
    // Debug Area <-

    public Vector3 rPos { private set; get; }
    public Vector3 lPos { private set; get; }
    public Vector3 modRPos { private set; get; }
    public Vector3 modLPos { private set; get; }
    public int rLane { private set; get; }
    public int lLane { private set; get; }

    private struct Polar
    {
        public Polar(float r, float theta) {
            this.r     = r;
            this.theta = theta;
        }

        public float r { private set; get; }
        public float theta { private set; get; }
    }

    private void Update()
    {
        // Check Pause
        if(OVRInput.GetDown(OVRInput.Button.Two)) {
            RhythmGameManager.Instance.isPaused ^= true;
        }

        // Original Position
        Vector3 localRPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 localLPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rPos = TrackingSpace.TransformPoint(localRPos);
        lPos = TrackingSpace.TransformPoint(localLPos);

        // Modified Position
        modRPos = rPos / OffsetManager.Instance.stageScaleOffset;
        modRPos = new Vector3(modRPos.x, modRPos.y-OffsetManager.Instance.stageHeightOffset, modRPos.z);
        modLPos = lPos / OffsetManager.Instance.stageScaleOffset;
        modLPos = new Vector3(modLPos.x, modLPos.y-OffsetManager.Instance.stageHeightOffset, modLPos.z);

        // Convert to Polar Coordinate
        Polar rPolar = RectToPolar(modRPos);
        Polar lPolar = RectToPolar(modLPos);

        // Calc Lane
        rLane = CalcLane(rPolar, lr:"R");
        lLane = CalcLane(lPolar, lr:"L");

        // Debug Area ->
        //Debug.Log("rPos: " + rPos + " / lPos: " + lPos);
        RTouchText.text = "RTouch: r=" + rPolar.r + " /  Θ=" + rPolar.theta + " (" + rLane + ")";
        LTouchText.text = "LTouch: r=" + lPolar.r + " /  Θ=" + lPolar.theta + " (" + lLane + ")"; 
        // Debug Area <-
    }

    private Polar RectToPolar(Vector3 rect)
    {
        float r   = Mathf.Sqrt(rect.x*rect.x + rect.y*rect.y);
        float rad = Mathf.Atan2(rect.y, rect.x);
        float deg = rad * Mathf.Rad2Deg;
        if(deg < 0) {
            deg = 360f + deg;
        }

        Polar polar = new Polar(r, deg);
        return polar;
    }

    private int CalcLane(Polar polar, string lr)
    {
        int lane = -1;

        // R Touch
        if(lr == "R") {
            // right side
            if((0f <= polar.theta && polar.theta <= 90f) || (270f <= polar.theta && polar.theta <= 360f)) {
                if(baseThresh < polar.r) {
                    lane = (int)(polar.theta / 11.25f);
                    return lane;                    
                }
            }
            // left side
            else {
                if(baseThresh*oppositeCorrection < polar.r) {
                    lane = (int)(polar.theta / 11.25f);
                    return lane;                    
                }
            }
        }

        // L Touch
        if(lr == "L") {
            // right side
            if((0f <= polar.theta && polar.theta <= 90f) || (270f <= polar.theta && polar.theta <= 360f)) {
                if(baseThresh*oppositeCorrection < polar.r) {
                    lane = (int)(polar.theta / 11.25f);
                    return lane;                    
                }
            }
            // left side
            else {
                if(baseThresh < polar.r) {
                    lane = (int)(polar.theta / 11.25f);
                    return lane;                    
                }
            }           
        }

        return lane;
    }
}
