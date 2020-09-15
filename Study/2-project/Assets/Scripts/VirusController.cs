using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float maxHealth = 2.0f;
    private float _health;
    public float speed = 3.0f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _health = maxHealth;
    }

    private void Start()
    {
        EventManager.Subscribe("game_ended", OnGameEnd);
    }

    private void OnGameEnd(object obj)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity;
        if (GameManager.Instance.state == GameState.Playing) velocity = Vector2.left;
        else velocity = Vector2.zero;
        
        _rigidbody2D.velocity = velocity * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var man = other.GetComponent<ManController>();
            man.Damage(1.0f);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Missile"))
        {
            _health -= 1.0f;
            other.gameObject.SetActive(false);
            if (_health < 0.0f) gameObject.SetActive(false);
        }
    }
}
