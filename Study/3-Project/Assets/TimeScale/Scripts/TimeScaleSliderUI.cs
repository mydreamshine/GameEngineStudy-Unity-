using System;
using UnityEngine;

namespace TimeScale.Scripts
{
    public class TimeScaleSliderUI : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0.0f;
        }

        public void OnValueChanged(float value)
        {
            Time.timeScale = value;
        }
    }
}
