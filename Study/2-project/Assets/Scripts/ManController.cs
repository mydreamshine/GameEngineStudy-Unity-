using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public string missleName = "missile";
    public float maxHealth = 10.0f;
    private float _health;
    // Health => _health
    // c++의 using Health = _health와 같은 개념
    public float Health => _health;

    public float shootRate = 0.5f;

    private Coroutine _shootRoutine;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        
        EventManager.Subscribe("game_started", OnGameStart);
        EventManager.Subscribe("game_paused", OnGamePause);
        EventManager.Subscribe("game_ended", OnGameEnded);
    }

    private void OnEnable()
    {
        _health = maxHealth;
    }

    private void OnGameStart(object obj)
    {
        if (gameObject.activeInHierarchy == false)
            gameObject.SetActive(true);

        _shootRoutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            var newSpawnedObject = ObjectPoolManager.Instance.Spawn(missleName);
            newSpawnedObject.transform.position = this.transform.position + Vector3.right * 1.0f;
            newSpawnedObject.transform.rotation = this.transform.rotation;
            
            yield return new WaitForSeconds(shootRate);
        }
    }

    private void OnGamePause(object obj)
    {
        StopCoroutine(_shootRoutine);
    }
    
    private void OnGameEnded(object obj)
    {
        gameObject.SetActive(false);
        
        StopCoroutine(_shootRoutine);
    }

    public void Damage(float damage)
    {
        _health -= damage;
        
        if(_health < 0.0f) EventManager.Emit("game_ended", null);
    }
}
