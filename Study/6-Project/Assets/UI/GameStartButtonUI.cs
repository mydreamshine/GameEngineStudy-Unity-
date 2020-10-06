using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameStartButtonUI : MonoBehaviour
{
    public void OnGameStart()
    {
        EventManager.Emit("game_started");
    }
}
