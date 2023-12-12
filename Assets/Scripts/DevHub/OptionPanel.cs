using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{
    private TextMeshProUGUI tmproScaleOffset;
    private TextMeshProUGUI tmproHeightOffset;

    private TextMeshProUGUI tmproNoteSpeedOffset;
    private TextMeshProUGUI tmproChartOffset;
    private TextMeshProUGUI tmproGenerationDepthOffset;


    private void Start()
    {
        tmproScaleOffset = transform.Find("EditStageScaleOffset").GetComponent<TextMeshProUGUI>();
        tmproHeightOffset = transform.Find("EditStageHeightOffset").GetComponent<TextMeshProUGUI>();
        tmproNoteSpeedOffset = transform.Find("EditNoteSpeedOffset").GetComponent<TextMeshProUGUI>();
        tmproChartOffset = transform.Find("EditChartOffset").GetComponent<TextMeshProUGUI>();
        tmproGenerationDepthOffset = transform.Find("EditGenerationDepthOffset").GetComponent<TextMeshProUGUI>();

        tmproScaleOffset.text = OffsetManager.Instance.stageScaleOffset.ToString("f4");
        tmproHeightOffset.text = OffsetManager.Instance.stageHeightOffset.ToString("f4");
        tmproNoteSpeedOffset.text = OffsetManager.Instance.playerNoteSpeed.ToString("f1");
        tmproChartOffset.text = OffsetManager.Instance.playerChartOffset.ToString("f1");
        tmproGenerationDepthOffset.text = OffsetManager.Instance.playerGenerationDepth.ToString("f0");
    }

    public void AddNoteSpeedOffset()
    {
        if(OffsetManager.Instance.playerNoteSpeed < 4.91f) {
            OffsetManager.Instance.playerNoteSpeed += 0.1f;
            UpdateNoteSpeedOffset();
        }
    }

    public void SubNoteSpeedOffset()
    {
        if(OffsetManager.Instance.playerNoteSpeed > 1.1f) {
            OffsetManager.Instance.playerNoteSpeed -= 0.1f;
            UpdateNoteSpeedOffset();
        }
    }

    private void UpdateNoteSpeedOffset()
    {
        tmproNoteSpeedOffset.text = OffsetManager.Instance.playerNoteSpeed.ToString("f1");
    }

    public void AddChartOffset()
    {
        if(OffsetManager.Instance.playerChartOffset < 10f) {
            OffsetManager.Instance.playerChartOffset += 0.1f;
            UpdateChartOffset();
        }
    }

    public void SubChartOffset()
    {
        if(OffsetManager.Instance.playerChartOffset > -10f) {
            OffsetManager.Instance.playerChartOffset -= 0.1f;
            UpdateChartOffset();
        }
    }

    public void UpdateChartOffset()
    {
        tmproChartOffset.text = OffsetManager.Instance.playerChartOffset.ToString("f1");
    }

    public void AddGenerationDepthOffset()
    {
        if(OffsetManager.Instance.playerGenerationDepth < 50f) {
            OffsetManager.Instance.playerGenerationDepth += 1f;
            UpdateGenerationDepthOffset();
        }
    }

    public void SubGenerationDepthOffset()
    {
        if(OffsetManager.Instance.playerGenerationDepth > 25f) {
            OffsetManager.Instance.playerGenerationDepth -= 1f;
            UpdateGenerationDepthOffset();
        }
    }

    public void UpdateGenerationDepthOffset()
    {
        tmproGenerationDepthOffset.text = OffsetManager.Instance.playerGenerationDepth.ToString("f0");
    }
}
