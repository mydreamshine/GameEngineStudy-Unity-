using KPU.Manager;
using UnityEngine;

namespace Timer.Scripts
{
    public class TimerResetButtonUI : MonoBehaviour
    {
        public void Clicked()
        {
            EventManager.Emit("timer_reset", null);
        }
    }
}
