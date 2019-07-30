using System;
using System.Net.Mail;
using UnityEngine;

namespace Maths.Ranges
{
    [Serializable]
    public class FloatRange : Range<float>
    {
        [SerializeField]
        private float _minimum;
        
        [SerializeField]
        private float _maximum;

        public override float Minimum => _minimum;
        public override float Maximum => _maximum;

        public FloatRange()
        {}

        public FloatRange(float minimum, float maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }
        public float Delta => Maximum - Minimum;
        
    }
}