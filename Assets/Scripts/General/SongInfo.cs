using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    public struct SongInfo
    {
        public SongInfo(string songName, string composer, float bpm, string chartDesigner) {
            this.songName = songName;
            this.composer = composer;
            this.bpm = bpm;
            this.chartDesigner = chartDesigner;
        }

        public string songName;
        public string composer;
        public float bpm;
        public string chartDesigner;
    }
}