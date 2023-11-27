using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log(devHubManager.songName);
    }
}
