using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


namespace General
{
    namespace Coordinate
    {
        public struct Polar
        {
            // From r & theta
            public Polar(float r, float theta) {
                this.r     = r;
                this.theta = theta;
            }

            // From Rectangular-Coordinate-System
            public Polar(Vector3 rect) {
                float r = Mathf.Sqrt(rect.x*rect.x + rect.y*rect.y);
                float rad = Mathf.Atan2(rect.y, rect.x);
                float theta = rad * Mathf.Rad2Deg;
                // -180~180 -> 0~360
                if(theta < 0) {
                    theta = 360f + theta;
                }

                this.r = r;
                this.theta = theta;
            }

            public float r { private set; get; }
            public float theta { private set; get; }
        }
    }
}
