using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI tmproScore;
    TextMeshProUGUI tmproCombo;
    TextMeshProUGUI tmproEarlyLate;
    Animation animComboPopup;

    private void Start()
    {
        tmproScore = transform.Find("Text_Score").GetComponent<TextMeshProUGUI>();
        tmproCombo = transform.Find("Text_Combo").GetComponent<TextMeshProUGUI>();
        tmproEarlyLate = transform.Find("Text_EarlyLate").GetComponent<TextMeshProUGUI>();
        animComboPopup = transform.Find("Text_Combo").GetComponent<Animation>();
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
        animComboPopup.Play();
    }

    public void UpdateEarlyLate(float time)
    {
        if(time > 0f) {
            tmproEarlyLate.text = "Early";
            tmproEarlyLate.color = Color.blue;
        }
        else {
            tmproEarlyLate.text = "Late";
            tmproEarlyLate.color = Color.red;
        }

        StartCoroutine(ResetEarlyLate(0.5f, () =>
         {
            tmproEarlyLate.text = "";
            tmproEarlyLate.color = Color.white;
         }
        ));
    }

    private IEnumerator ResetEarlyLate(float sec, Action action)
    {
        yield return new WaitForSeconds(sec);
        action?.Invoke();
    }
}
