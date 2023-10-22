using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}
