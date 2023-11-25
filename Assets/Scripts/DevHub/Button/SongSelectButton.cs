using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectButton : MonoBehaviour
{
    [SerializeField] private string songName;
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickSongSelectButton);
        }       
    }

    public void OnClickSongSelectButton()
    {
        Debug.Log(songName);
    }
}
