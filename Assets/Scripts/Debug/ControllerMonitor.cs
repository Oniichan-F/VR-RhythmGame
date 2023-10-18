using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControllerMonitor : MonoBehaviour
{
    private OculusInputManager oculusInputManager;
    private TextMeshProUGUI rText, lText;


    private void Start()
    {
        oculusInputManager = GameObject.Find("InputManager").GetComponent<OculusInputManager>();
        rText = transform.Find("Text_RTouch").GetComponent<TextMeshProUGUI>();
        lText = transform.Find("Text_LTouch").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        rText.text = "RTouch: r=" + oculusInputManager.polarRPos.r + 
                          " / Θ=" + oculusInputManager.polarRPos.theta + 
                          " / lane=" + oculusInputManager.rLane;
        lText.text = "LTouch: r=" + oculusInputManager.polarLPos.r + 
                          " / Θ=" + oculusInputManager.polarLPos.theta + 
                          " / lane=" + oculusInputManager.lLane;
    }
}
