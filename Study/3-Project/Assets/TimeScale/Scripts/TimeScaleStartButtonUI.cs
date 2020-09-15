using KPU.Manager;
using UnityEngine;

namespace TimeScale.Scripts
{
    public class TimeScaleStartButtonUI : MonoBehaviour
    {
        public void Clicked()
        {
            EventManager.Emit("game_started", null);
        }
    }
}
