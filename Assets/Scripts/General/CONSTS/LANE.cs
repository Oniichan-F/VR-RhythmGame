using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace General
{
    namespace CONSTS
    {
        public static class LANE
        {
            public static readonly ReadOnlyCollection<float> ANGLES =
                Array.AsReadOnly(new float[] {
                    0f,    11.25f,  22.5f,  33.75f,  45f,  56.25f,  67.5f,  78.75f,
                    90f,  101.25f, 112.5f, 123.75f, 135f, 146.25f, 157.5f, 168.75f,
                    180f, 191.25f, 202.5f, 213.75f, 225f, 236.25f, 247.5f, 258.75f,
                    270f, 281.25f, 292.5f, 303.75f, 315f, 326.25f, 337.5f, 348.75f
                });
        }
    }
}