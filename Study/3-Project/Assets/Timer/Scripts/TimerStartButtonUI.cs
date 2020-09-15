using System;
using KPU.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Timer.Scripts
{
    public class TimerStartButtonUI : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
        }

        private void Start()
        {
            EventManager.On("timer_start", OnTimerStart);
            EventManager.On("timer_stop", OnTimerStop);
            EventManager.On("timer_reset", OnTimerReset);
        }

        private void OnTimerReset(object obj)
        {
            _text.text = "Start";
        }
        
        private void OnTimerStop(object obj)
        {
            _text.text = "Resume";
        }
        
        private void OnTimerStart(object obj)
        {
            _text.text = "Stop";
        }

        public void Clicked()
        {
            var eventName = Timer.Instance.Active ? "timer_stop" : "timer_start";
            EventManager.Emit(eventName, null);
        }
    }
}
