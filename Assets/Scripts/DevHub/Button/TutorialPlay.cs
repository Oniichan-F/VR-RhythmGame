using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPlay : MonoBehaviour
{
    private DevHubManager devHubManager;
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickTutorialPlayButton);
        }

        devHubManager = GameObject.Find("DevHubManager").GetComponent<DevHubManager>();
    }

    public void OnClickTutorialPlayButton() 
    {
        devHubManager.songInfo = new SongInfo(-1, 0);
        RhythmGameManager.Instance.songInfo = devHubManager.songInfo;
        RhythmGameManager.Instance.SetSongInfo();
        SceneManager.LoadScene("TutorialScene");
    }
}
