using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private GameState _state;

    private void Awake()
    {
        _state = GameState.Initialized;
    }

    public GameState state
    {
        get { return _state; }
    }

    private void Start()
    {
        EventManager.Subscribe("game_started", OnGameStart);
        EventManager.Subscribe("game_paused", OnGamePause);
        EventManager.Subscribe("game_ended", OnGameEnded);
    }
    
    // C#에선 한 줄 짜리 메소드를 아래와 같이 표현 가능
    private void OnGameStart(object obj) => _state = GameState.Playing;

    private void OnGamePause(object obj) => _state = GameState.Pause;

    private void OnGameEnded(object obj) => _state = GameState.Ended;
}
