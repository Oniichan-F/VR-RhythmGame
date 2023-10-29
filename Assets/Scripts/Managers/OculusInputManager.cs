using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using General.Coordinate;


public class OculusInputManager : MonoBehaviour
{
    [SerializeField] Transform TrackingSpace;
    
    // パネルの基礎反応感度
    [SerializeField] float baseThresh = 0.6f;
    // 反対側パネルの反応感度緩和補正
    [SerializeField] float oppositeCorrection = 0.5f;


    public Vector3 globalRPos { private set; get; }
    public Vector3 globalLPos { private set; get; }
    public Vector3 personalRPos { private set; get; }
    public Vector3 personalLPos { private set; get; }
    public Polar polarRPos { private set; get; }
    public Polar polarLPos { private set; get; }
    public int rLane { private set; get; }
    public int lLane { private set; get; }


    private void Update()
    {
        // Local Position -> Global Position
        Vector3 localRPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 localLPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        globalRPos = TrackingSpace.TransformPoint(localRPos);
        globalLPos = TrackingSpace.TransformPoint(localLPos);

        // Global Position -> Personal Position
        personalRPos = globalRPos / OffsetManager.Instance.stageScaleOffset;
        personalRPos = new Vector3(personalRPos.x, personalRPos.y-OffsetManager.Instance.stageHeightOffset, personalRPos.z);
        personalLPos = globalLPos / OffsetManager.Instance.stageScaleOffset;
        personalLPos = new Vector3(personalLPos.x, personalLPos.y-OffsetManager.Instance.stageHeightOffset, personalLPos.z);

        // Personal Position -> Polar Position
        polarRPos = new Polar(personalRPos);
        polarLPos = new Polar(personalLPos);

        // Polar Positon -> Lane
        rLane = CalcLane(polarRPos, lr:"R");
        lLane = CalcLane(polarLPos, lr:"L");   
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
