using System;
using System.Net.Mail;
using UnityEngine;

namespace Maths.Ranges
{
    [Serializable]
    public class IntRange : Range<int>
    {
        [SerializeField]
        private int _minimum;
        
        [SerializeField]
        private int _maximum;

        public override int Minimum => _minimum;
        public override int Maximum => _maximum;

        public IntRange()
        {}

        public IntRange(int minimum, int maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }
        public int Delta => Maximum - Minimum;
        
    }
}