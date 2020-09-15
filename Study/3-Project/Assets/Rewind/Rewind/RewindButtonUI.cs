using System;
using KPU.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Rewind.Rewind
{
    public class RewindButtonUI : MonoBehaviour
    {
        private Text _text;
        private bool _isRewinding;

        private void Awake()
        {
            _text = GetComponentInChildren<Text>();
        }

        private void Start()
        {
            EventManager.On("rewind", OnRewind);
            EventManager.On("play", OnPlay);
        }

        private void OnPlay(object obj)
        {
            _text.text = "rewind";
            _isRewinding = false;
        }

        private void OnRewind(object obj)
        {
            _text.text = "play";
            _isRewinding = true;
        }

        public void Clicked()
        {
            var eventName = _isRewinding ? "play" : "rewind";
            EventManager.Emit(eventName, null);;
        }
    }
}
