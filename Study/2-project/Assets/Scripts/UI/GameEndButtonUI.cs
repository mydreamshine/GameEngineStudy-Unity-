using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndButtonUI : MonoBehaviour
{
    public void Cliked()
    {
        EventManager.Emit("game_ended", null);
    }
}
