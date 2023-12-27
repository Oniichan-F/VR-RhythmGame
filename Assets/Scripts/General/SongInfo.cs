using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace General
{
    public struct SongInfo
    {
        public SongInfo(int songID, int chartID) {
            this.songID = songID;
            this.chartID = chartID;

            songDisplayName = "null";
            songSourceName  = "null";
            songChartName   = "null";
            composer        = "null";
            chartDesigner   = "null";
            BPM = -1;
            LPB = -1;

            SetData();
        }

        private void SetData()
        {
            switch(songID) {
                case -1:
                    songDisplayName = "Tutorial";
                    songSourceName  = "Tutorial";
                    songChartName   = songSourceName + "_" + chartID;
                    composer        = "TheFatRat";
                    chartDesigner   = "oniichan";
                    BPM = 105;
                    LPB = 4;
                    break;

                case 1:
                    songDisplayName = "INTERNET OVERDOSE";
                    songSourceName  = "INTERNET_OVERDOSE";
                    songChartName   = songSourceName + "_" + chartID;
                    composer        = "Aiobahn feat.KOTOKO";
                    chartDesigner   = "Oniichan";
                    BPM = 163;
                    LPB = 4;
                    break;                    

                default:
                    songDisplayName = "null";
                    songSourceName  = "null";
                    songChartName   = "null";
                    composer        = "null";
                    chartDesigner   = "null";
                    BPM = -1;
                    LPB = -1;
                    break;
            }
        }

        public int songID;
        public int chartID;

        public string songDisplayName;
        public string songSourceName;
        public string songChartName;
        public string composer;
        public string chartDesigner;
        public float BPM;
        public int LPB;
    }
}