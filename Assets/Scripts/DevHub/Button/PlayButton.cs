using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private DevHubManager devHubManager;
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickPlayButton);
        }

        devHubManager = GameObject.Find("DevHubManager").GetComponent<DevHubManager>();
        
    }

    public void OnClickPlayButton()
    {
        RhythmGameManager.Instance.songInfo = devHubManager.songInfo;
        RhythmGameManager.Instance.SetSongInfo();
        Debug.Log("Play : " + RhythmGameManager.Instance.songSourceName);

        if(RhythmGameManager.Instance.songSourceName != "null") {
            SceneManager.LoadScene("GameSceneTemplate00");
        }
        else {
            Debug.Log("not selected");
        }
    }
}
