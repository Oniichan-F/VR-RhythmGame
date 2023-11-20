using System;
using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.Utilities;
using UnityEngine;

namespace General
{
    namespace ChartProtocol
    {
        [Serializable] public class ChartData
        {
            public float BPM;
            public int LPB;
            public float offset;
            public int numNotes;
            public NoteData[] noteData;
        }

        [Serializable] public class NoteData
        {
            public int type;
            public int[] lanes;
            public float timing;
            public string lr;
            public bool pair;
            public int[] options;
            public NoteData[] children;
        }

        [Serializable] public class BPMGuideFileData
        {
            public float BPM;
            public int LPB;
            public float offset;
            public BPMGuideData[] BPMGuideData;
        }

        [Serializable] public class BPMGuideData
        {
            public float timing;
            public int shape;
            public int color;
        }
    }
}
