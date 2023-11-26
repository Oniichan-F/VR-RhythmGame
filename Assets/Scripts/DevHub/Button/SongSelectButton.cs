using System.Collections;
using System.Collections.Generic;
using General;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectButton : MonoBehaviour
{
    [SerializeField] private string songName;
    private Button button;
    private PlayerPanel playerPanel;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickSongSelectButton);
        }

        playerPanel = GameObject.Find("Player").transform.Find("PlayerPanel").GetComponent<PlayerPanel>();  
    }

    public void OnClickSongSelectButton()
    {
        Debug.Log(songName);

        SongInfo songInfo = new SongInfo("test", "test", 1.0f, "test");;
        if(songName == "INTERNET_OVERDOSE") {
            songInfo = new SongInfo("INTERNET_OVERDOSE", "Aiobahn feat.KOTOKO", 163.0f, "Oniichan");
        }
        else if(songName == "INTERNET_YAMERO") {
            songInfo = new SongInfo("INTERNET_YAMERO", "Aiobahn feat.KOTOKO", 185.0f, "Oniichan");
        }
        else if(songName == "Loli_GOD_Requiem") {
            songInfo = new SongInfo("Loli_GOD_Requiem", "IOSYS feat.UiShigure", 1.0f, "Oniichan");
        }

        playerPanel.UpdatePlayerPanel(songInfo);
    }
}
