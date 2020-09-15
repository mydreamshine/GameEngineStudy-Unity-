using System;
using UnityEngine;
using UnityEngine.UI;

namespace Timer.Scripts
{
    public class TimerRecordTextUI : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            var text = string.Empty;
            foreach (var record in Timer.Instance.RecordTimes)
            {
                var timeSpan = new TimeSpan(0, 0,0,0, (int)(record * 1000));
                text += $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}";
                text += Environment.NewLine;
            }

            _text.text = text;
        }
    }
}
