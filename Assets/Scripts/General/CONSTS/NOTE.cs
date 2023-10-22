using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General
{
    namespace CONSTS
    {
        public static class NOTE
        {
            public enum TYPE : int
            {
                NormalNote = 1,
                TouchNote = 2,

                LongNote = 10,
                LongEnd = 11,
                LongMid = 12,
            }
        }
    }
}