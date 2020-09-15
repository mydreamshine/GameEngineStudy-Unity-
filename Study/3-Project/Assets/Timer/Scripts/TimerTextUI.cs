﻿using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Timer.Scripts
{
    public class TimerTextUI : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            var timeSpan = new TimeSpan(0, 0,0,0, (int)(Timer.Instance.CurrentTime * 1000));
            _text.text = $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}.{timeSpan.Milliseconds:000}";
        }
    }
}
