using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpenButtonUI : MonoBehaviour
{
    private void Start()
    {
        EventManager.Subscribe("game_started", OnGameStart);
        EventManager.Subscribe("game_paused", OnGamePause);
        EventManager.Subscribe("game_ended", OnGameEnded);
        
        gameObject.SetActive(false);
    }

    public void Clicked()
    {
        EventManager.Emit("game_paused", null);
    }
    
    private void OnGameStart(object obj) => gameObject.SetActive(true);

    private void OnGamePause(object obj) => gameObject.SetActive(false);

    private void OnGameEnded(object obj) => gameObject.SetActive(false);
}
