using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    namespace CONSTS
    {
        public static class JUDGE
        {
            public static readonly float THRESH = 0.10f;
            public static readonly float JUST = 0.06f;
            public static readonly float GREAT = 0.08f;
            public static readonly float GOOD = 0.10f;

            public enum JUDGE_ID : int
            {
                JUST = 0,
                GREAT = 1,
                GOOD = 2,
            }
        }
    }
}
