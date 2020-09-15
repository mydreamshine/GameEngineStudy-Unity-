using System;
using System.Collections.Generic;
using KPU;
using KPU.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Timer.Scripts
{
    public class Timer : SingletonBehaviour<Timer>
    {
        private float _time;
        private bool _active;
        private IList<float> _recordTimes;
        
        public float CurrentTime => _time;
        public bool Active => _active;
        public IList<float> RecordTimes => _recordTimes;

        private void Awake()
        {
            _recordTimes = new List<float>();
            _active = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            EventManager.On("timer_start", OnTimerStart);
            EventManager.On("timer_stop", OnTimerStop);
            EventManager.On("timer_reset", OnTimerReset);
            EventManager.On("timer_record", OnTimerRecord);
        }

        private void OnTimerRecord(object obj)
        {
            if (_recordTimes.Count > 5)
                _recordTimes.RemoveAt(0);
            _recordTimes.Add(_time);
        }

        private void OnTimerReset(object obj)
        {
            _active = false;
            _time = 0.0f;
            _recordTimes.Clear();
        }

        private void OnTimerStop(object obj)
        {
            _active = false;
        }

        private void OnTimerStart(object obj)
        {
            _active = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(_active)
                _time += Time.deltaTime;
        }
    }
}
