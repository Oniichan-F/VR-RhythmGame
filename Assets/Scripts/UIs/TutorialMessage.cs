using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessage : MonoBehaviour
{
    private TextMeshProUGUI tmproMessage;
    private Image image;
    private float time;
    private int step;

    private void Start()
    {
        tmproMessage = transform.Find("Message").GetComponent<TextMeshProUGUI>();
        image = gameObject.GetComponent<Image>();

        time = 0f;
        step = 0;
    }

    private void Update()
    {
        float calcTime(float t) {
            float interval = 60f / (RhythmGameManager.Instance.BPM * RhythmGameManager.Instance.LPB);
            float beatsec  = interval * RhythmGameManager.Instance.LPB;
            float time = (beatsec * t / RhythmGameManager.Instance.LPB) + RhythmGameManager.Instance.chartOffset * 0.01f;
            return time;
        }

        if(RhythmGameManager.Instance.isPaused) {
            return;
        }

        if(step == 0 && time > calcTime(1*16)) {
            tmproMessage.text = "チュートリアルへようこそ";
            step++;
        }
        else if(step == 1 && time > calcTime(3*16)) {
            tmproMessage.text = "パネルが反応するか確認してね";
            step++;            
        }


        else if(step == 2 && time > calcTime(5*16)) {
            tmproMessage.text = "まずはノーマルノーツ";
            step++;            
        }
        else if(step == 3 && time > calcTime(7*16)) {
            tmproMessage.text = "タイミングよくコントローラで叩けばOK";
            step++;            
        }
        else if(step == 4 && time > calcTime(9*16)) {
            tmproMessage.text = "色がついているノーツは左右指定があるよ\n赤 ＝ 右\n青 ＝ 左";
            step++;            
        }
        else if(step == 5 && time > calcTime(11*16)) {
            tmproMessage.text = "やってみよう";
            step++;            
        }
        else if(step == 6 && time > calcTime(11*16 + 4)) {
            tmproMessage.text = "やってみよう\n３";
            step++;            
        }
        else if(step == 7 && time > calcTime(11*16 + 8)) {
            tmproMessage.text = "やってみよう\n２";
            step++;            
        }
        else if(step == 8 && time > calcTime(11*16 + 12)) {
            tmproMessage.text = "やってみよう\n１";
            step++;            
        }
        else if(step == 9 && time > calcTime(12*16)) {
            tmproMessage.text = "";
            image.enabled =false;
            step++;            
        }


        else if(step == 10 && time > calcTime(21*16)) {
            image.enabled = true;
            tmproMessage.text = "次はタッチノーツ";
            step++;            
        }
        else if(step == 11 && time > calcTime(23*16)) {
            tmproMessage.text = "コントローラで触れるだけでOK";
            step++;            
        }
        else if(step == 12 && time > calcTime(25*16)) {
            tmproMessage.text = "左右の指定はないよ";
            step++;            
        }
        else if(step == 13 && time > calcTime(27*16)) {
            tmproMessage.text = "やってみよう";
            step++;            
        }
        else if(step == 14 && time > calcTime(27*16 + 4)) {
            tmproMessage.text = "やってみよう\n３";
            step++;            
        }
        else if(step == 15 && time > calcTime(27*16 + 8)) {
            tmproMessage.text = "やってみよう\n２";
            step++;            
        }
        else if(step == 16 && time > calcTime(27*16 + 12)) {
            tmproMessage.text = "やってみよう\n１";
            step++;            
        }
        else if(step == 17 && time > calcTime(28*16)) {
            tmproMessage.text = "";
            image.enabled = false;
            step++;            
        }


        else if(step == 18 && time > calcTime(37*16)) {
            image.enabled = true;
            tmproMessage.text = "次はフリックノーツ";
            step++;            
        }
        else if(step == 19 && time > calcTime(39*16)) {
            tmproMessage.text = "タイミングよく中心に向かってフリック";
            step++;            
        }
        else if(step == 20 && time > calcTime(41*16)) {
            tmproMessage.text = "色がついているノーツは左右指定があるよ\n赤 ＝ 右\n青 ＝ 左";
            step++;            
        }
        else if(step == 21 && time > calcTime(43*16)) {
            tmproMessage.text = "やってみよう";
            step++;            
        }
        else if(step == 22 && time > calcTime(43*16 + 4)) {
            tmproMessage.text = "やってみよう\n３";
            step++;            
        }
        else if(step == 23 && time > calcTime(43*16 + 8)) {
            tmproMessage.text = "やってみよう\n２";
            step++;            
        }
        else if(step == 24 && time > calcTime(43*16 + 12)) {
            tmproMessage.text = "やってみよう\n１";
            step++;            
        }
        else if(step == 25 && time > calcTime(44*16)) {
            tmproMessage.text = "";
            image.enabled = false;
            step++;            
        }


        else if(step == 26 && time > calcTime(53*16)) {
            image.enabled = true;
            tmproMessage.text = "次はロングノーツ";
            step++;            
        }
        else if(step == 27 && time > calcTime(55*16)) {
            tmproMessage.text = "コントローラでノーツをなぞろう";
            step++;            
        }
        else if(step == 28 && time > calcTime(57*16)) {
            tmproMessage.text = "色がついているノーツは左右指定があるよ\n赤 ＝ 右\n青 ＝ 左";
            step++;            
        }
        else if(step == 29 && time > calcTime(59*16)) {
            tmproMessage.text = "やってみよう";
            step++;            
        }
        else if(step == 30 && time > calcTime(59*16 + 4)) {
            tmproMessage.text = "やってみよう\n３";
            step++;            
        }
        else if(step == 31 && time > calcTime(59*16 + 8)) {
            tmproMessage.text = "やってみよう\n２";
            step++;            
        }
        else if(step == 32 && time > calcTime(59*16 + 12)) {
            tmproMessage.text = "やってみよう\n１";
            step++;            
        }
        else if(step == 33 && time > calcTime(60*16)) {
            tmproMessage.text = "";
            image.enabled = false;
            step++;            
        }


        else if(step == 34 && time > calcTime(69*16)) {
            image.enabled = true;
            tmproMessage.text = "最後に組み合わせてみよう";
            step++;            
        }
        else if(step == 35 && time > calcTime(71*16 + 4)) {
            tmproMessage.text = "やってみよう\n３";
            step++;            
        }
        else if(step == 36 && time > calcTime(71*16 + 8)) {
            tmproMessage.text = "やってみよう\n２";
            step++;            
        }
        else if(step == 37 && time > calcTime(71*16 + 12)) {
            tmproMessage.text = "やってみよう\n１";
            step++;            
        }
        else if(step == 38 && time > calcTime(72*16)) {
            tmproMessage.text = "";
            image.enabled = false;
            step++;            
        }

        time += Time.deltaTime;
    }
}
