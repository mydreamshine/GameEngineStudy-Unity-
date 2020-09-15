using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButtonUI : MonoBehaviour
{
    public void Cliked()
    {
        EventManager.Emit("game_started", null);
    }
}
