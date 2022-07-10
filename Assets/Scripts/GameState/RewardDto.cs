using System;
using Currency;
using UnityEngine;

namespace GameConfig
{
    [Serializable]
    public class RewardDto
    {
        public CurrencyType Type;

        [Range(0, 1)] public float Probability;
        public int From;
        public int To;
    }
}