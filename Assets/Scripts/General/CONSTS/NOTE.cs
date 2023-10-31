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
                FlickNote = 3,
                // options: [isHead(0->true / 1->false)]
                

                LongNote = 10,
                // options: [isHead(0->true / 1->false), rotDir(1->CCW / -1->CW), rotNum]
                
                LongEnd = 11,
                LongChild = 12,
            }
        }

        public static class LONGNOTE
        {
            public enum STATE : int
            {
                inActive = 0,
                Active = 1,
                Lost = 2,
            }
        }
    }
}