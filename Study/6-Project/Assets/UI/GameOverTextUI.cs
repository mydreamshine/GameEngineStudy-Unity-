using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KPU.Manager;

public class GameOverTextUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.On("game_over", OnGameOver);
        gameObject.SetActive(false);
    }

    private void OnGameOver(object obj)
    {
        gameObject.SetActive(true);
    }
}
