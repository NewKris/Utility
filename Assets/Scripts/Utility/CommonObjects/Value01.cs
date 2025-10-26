using System;
using UnityEngine;

namespace NewKris.Utility.CommonObjects {
    [Serializable]
    public partial struct Value01 {
        [SerializeField, Range(0, 1)] private float value;

        public float Value {
            get => value;
            set => this.value = Mathf.Clamp01(value);
        }
        
        public Value01(float startValue = 0) {
            value = Mathf.Clamp01(startValue);
        }
    }

    public partial struct Value01 {
        public static Value01 operator +(Value01 a, Value01 b) {
            return new Value01(a.Value + b.Value);
        }

        public static Value01 operator -(Value01 a, Value01 b) {
            return new Value01(a.Value - b.Value);
        }

        public static Value01 operator *(Value01 a, Value01 b) {
            return new Value01(a.Value * b.Value);
        }

        public static Value01 operator /(Value01 a, Value01 b) {
            if (b.Value == 0) {
                throw new DivideByZeroException();
            }
            
            return new Value01(a.Value / b.Value);
        }

        public static Value01 operator %(Value01 a, Value01 b) {
            return new Value01(a.Value % b.Value);
        }
    }
}