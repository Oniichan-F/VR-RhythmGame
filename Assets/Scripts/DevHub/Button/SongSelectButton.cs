using System.Collections;
using System.Collections.Generic;
using General;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectButton : MonoBehaviour
{
    [SerializeField] private int songID;
    [SerializeField] private int chartID;

    private Button button;
    private DevHubManager devHubManager;
    private PlayerPanel playerPanel;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickSongSelectButton);
        }

        devHubManager = GameObject.Find("DevHubManager").GetComponent<DevHubManager>();
        playerPanel = GameObject.Find("Player").transform.Find("PlayerPanel").GetComponent<PlayerPanel>();  
    }

    public void OnClickSongSelectButton()
    {
        devHubManager.songInfo = new SongInfo(songID, chartID);
        Debug.Log(devHubManager.songInfo.songID + " : " + devHubManager.songInfo.songDisplayName);

        playerPanel.UpdatePlayerPanel(devHubManager.songInfo);
    }
}
