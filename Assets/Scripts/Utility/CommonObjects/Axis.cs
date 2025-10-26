using System;
using UnityEngine;

namespace NewKris.Utility.CommonObjects {
    [Serializable]
    public partial struct Axis {
        [SerializeField, Range(-1, 1)] private float value;

        public float Value {
            get => value;
            set => this.value = Mathf.Clamp(value, -1, 1);
        }
        
        public Axis(float startValue = 0) {
            value = Mathf.Clamp(startValue, -1, 1);
        }

        public void MoveTowards(float toValue, float maxDelta) {
            Value = Mathf.MoveTowards(Value, toValue, maxDelta);
        }

        public float Magnitude() {
            return Mathf.Abs(Value);
        }
    }
    
    public partial struct Axis {
        public static float operator +(Axis a, Axis b) {
            return a.Value + b.Value;
        }

        public static float operator -(Axis a, Axis b) {
            return a.Value - b.Value;
        }
        
        public static float operator *(Axis a, Axis b) {
            return a.Value * b.Value;
        }

        public static float operator /(Axis a, Axis b) {
            if (b.Value == 0) {
                throw new DivideByZeroException();
            }
            
            return a.Value / b.Value;
        }

        public static float operator %(Axis a, Axis b) {
            return a.Value % b.Value;
        }
    }
}