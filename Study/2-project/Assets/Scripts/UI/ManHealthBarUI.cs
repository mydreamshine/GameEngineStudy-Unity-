using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManHealthBarUI : MonoBehaviour
{
    private Slider _slider;
    public ManController man;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        gameObject.SetActive(false);

        EventManager.Subscribe("game_started", OnGameStart);
        EventManager.Subscribe("game_ended", OnGameEnded);
    }

    private void OnGameStart(object obj)
    {
        gameObject.SetActive(true);
    }
    
    private void OnGameEnded(object obj)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = man.Health / man.maxHealth;
    }
}
