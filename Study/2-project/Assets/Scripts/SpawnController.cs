using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public float spawnRate = 2.0f;
    public string spawnTargetName = "virus";
    private Coroutine _spawnRoutine;

    void Start()
    {
        EventManager.Subscribe("game_started", OnGameStart);
        EventManager.Subscribe("game_paused", OnGamePause);
        EventManager.Subscribe("game_ended", OnGameEnded);
    }

    private void OnGameStart(object obj)
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }
    
    private void OnGamePause(object obj)
    {
        StopCoroutine(_spawnRoutine);
    }
    
    private void OnGameEnded(object obj)
    {
        StopCoroutine(_spawnRoutine);
    }

    // IEnumerator: Generic Enum Interface
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            var newSpawnedObject = ObjectPoolManager.Instance.Spawn(spawnTargetName);
            newSpawnedObject.transform.position = this.transform.position;
            newSpawnedObject.transform.rotation = this.transform.rotation;
            
            // yield return []: yield를 포함하고 있는 구문({})을 [](이)가 true일 때 재개한다.
            // 보통 반복문 제어로 많이 쓰이는 기법
            // WinAPI의 WaitForEvent()와 유사하다고 보면 된다.
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
