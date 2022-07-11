using System;
using TMPro;
using UnityEngine;
using Utils;

namespace UI.GameOverController
{
    [Serializable]
    public class RecordEntryUI
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _score;

        public void SetValues(string name, int score)
        {
            _name.text = name;
            UIUtils.AnimateLabelWithNumber(_score, score);
        }
    }
}