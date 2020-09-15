using KPU.Manager;
using UnityEngine;

namespace Timer.Scripts
{
    public class TimerRecordButtonUI : MonoBehaviour
    {
        public void Clicked()
        {
            EventManager.Emit("timer_record", null);
        }
    }
}
