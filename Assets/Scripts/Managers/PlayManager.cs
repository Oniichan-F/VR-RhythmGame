using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    private GameSceneMainUI gameSceneMainUI;
    private MusicManager musicManager;
    private float endTimer;

    private void Start()
    {
        gameSceneMainUI = GameObject.Find("MainUI").GetComponent<GameSceneMainUI>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        endTimer = 60f * RhythmGameManager.Instance.endTiming / (RhythmGameManager.Instance.BPM * RhythmGameManager.Instance.LPB);
    }

    private void Update()
    {
        if(RhythmGameManager.Instance.isStart) {
            if(OVRInput.GetDown(OVRInput.Button.Two)) {
                RhythmGameManager.Instance.isPaused ^= true;
                musicManager.Toggle();         
            }

            if(!RhythmGameManager.Instance.isPaused) {
                endTimer -= Time.deltaTime;

                if(endTimer < 0f) {
                    RhythmGameManager.Instance.isStart = false;
                    RhythmGameManager.Instance.isPaused = true;
                    SceneManager.LoadScene("DevHub");
                }
            }
        }
    }

    public void Play()
    {
        StartCoroutine(gameSceneMainUI.PanelCoroutine());

        RhythmGameManager.Instance.isStart = true;
        RhythmGameManager.Instance.isPaused = false;
        musicManager.Toggle();
    }
}
