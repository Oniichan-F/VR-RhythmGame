using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestPlay : MonoBehaviour
{
    private MusicManager musicManager;

    private void Start()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            RhythmGameManager.Instance.isPaused ^= true;
            musicManager.Toggle();
        }

        if(OVRInput.GetDown(OVRInput.Button.Two)) {
            RhythmGameManager.Instance.isPaused ^= true;
            musicManager.Toggle();         
        }
    }
}
