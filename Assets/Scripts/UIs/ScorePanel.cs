using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI tmproScore;
    TextMeshProUGUI tmproCombo;

    private void Start()
    {
        tmproScore = transform.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        tmproCombo = transform.Find("Text_Combo").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(float score, int combo, int justCount)
    {
        if(justCount == RhythmGameManager.Instance.numNotes) {
            tmproScore.text = "1000000";
        }
        else {
            tmproScore.text = Mathf.Ceil(1000000f * score).ToString().PadLeft(7, '0');
        }

        tmproCombo.text = combo.ToString();
    }
}
