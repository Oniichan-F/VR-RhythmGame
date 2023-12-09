using System.Collections;
using System.Collections.Generic;
using General;
using TMPro;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    private TextMeshProUGUI composer;
    private TextMeshProUGUI bpm;
    private TextMeshProUGUI chartDesigner;

    private void Start()
    {
        composer = transform.Find("SongInfo").transform.Find("EditComposer").GetComponent<TextMeshProUGUI>();
        bpm = transform.Find("SongInfo").transform.Find("EditBPM").GetComponent<TextMeshProUGUI>();
        chartDesigner = transform.Find("SongInfo").transform.Find("EditChartDesigner").GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePlayerPanel(SongInfo songInfo) {
        composer.text = songInfo.composer;
        bpm.text = songInfo.BPM.ToString();
        chartDesigner.text = songInfo.chartDesigner;
    }
}
