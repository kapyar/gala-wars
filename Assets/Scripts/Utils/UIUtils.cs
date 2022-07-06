using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Utils
{
    public static class UIUtils
    {
        private const float CoinsSpeed = 10f;

        public static float GetCoinTweenDuration(int from, int to)
        {
            var duration = Mathf.Abs(to - from) / CoinsSpeed;
            duration = Mathf.Clamp01(duration);
            return duration;
        }

        public static void AnimateLabelWithNumber(TextMeshProUGUI target, int value)
        {
            DOTween.To(() => double.Parse(target.text),
                x => { target.text = x.ToString("N0"); },
                value, UIUtils.GetCoinTweenDuration(0, value));
        }
    }
}