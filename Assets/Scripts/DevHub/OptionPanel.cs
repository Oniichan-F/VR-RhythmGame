using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    private TextMeshProUGUI tmproScaleOffset;
    private TextMeshProUGUI tmproHeightOffset;

    private void Start()
    {
        tmproScaleOffset = transform.Find("EditStageScaleOffset").GetComponent<TextMeshProUGUI>();
        tmproHeightOffset = transform.Find("EditStageHeightOffset").GetComponent<TextMeshProUGUI>();

        tmproScaleOffset.text = OffsetManager.Instance.stageScaleOffset.ToString();
        tmproHeightOffset.text = OffsetManager.Instance.stageHeightOffset.ToString();
    }
}
