using System.Collections;
using System.Collections.Generic;
using General.CONSTS;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score { private set; get; }
    public int combo { private set; get; }
    public int justCount { private set; get; }
    public int greatCount { private set; get; }
    public int goodCount { private set; get; }
    public int missCount { private set; get; }

    public int earlyCount { private set; get; }
    public int lateCount { private set; get; }

    private ScorePanel scorePanel;

    private void Start()
    {
        scorePanel = GameObject.Find("ScorePanel").GetComponent<ScorePanel>();

        score = 0f;
        combo = 0;
        justCount  = 0;
        greatCount = 0;
        goodCount  = 0;
        missCount  = 0;
    }

    public void AddScore(int judgeID)
    {
        if(judgeID == (int)JUDGE.JUDGE_ID.JUST) {
            score += 1f / RhythmGameManager.Instance.numNotes;
            combo += 1;
            justCount += 1;
        }
        else if(judgeID == (int)JUDGE.JUDGE_ID.GREAT) {
            score += 0.75f * (1f / RhythmGameManager.Instance.numNotes);
            combo += 1;
            greatCount += 1;
        }
        else if(judgeID == (int)JUDGE.JUDGE_ID.GOOD) {
            score += 0.5f * (1f / RhythmGameManager.Instance.numNotes);
            combo += 1;
            goodCount += 1;
        }
        else {
            combo = 0;
            missCount += 1;
        }

        scorePanel.UpdateText(score, combo, justCount);
    }

    public void AddEarlyLate(float time) {
        if(time > 0f) {
            earlyCount += 1;
        }
        else {
            lateCount += 1;
        }

        scorePanel.UpdateEarlyLate(time);
    }
}
