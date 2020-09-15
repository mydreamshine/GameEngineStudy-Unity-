using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonBehaviour<EventManager>
{
    private IDictionary<string, List<Action<object>>> _eventDatabase;

    private void Awake()
    {
        _eventDatabase = new Dictionary<string, List<Action<object>>>();
    }
    
    /// <summary>
    /// 이벤트 구독(등록)
    /// </summary>
    /// <param name="eventName">이벤트 이름</param>
    /// <param name="subscriber">이벤트 메소드</param>
    public static void Subscribe(string eventName, Action<object> subscriber)
    {
        if (Instance._eventDatabase.ContainsKey(eventName) == false)
            Instance._eventDatabase.Add(eventName, new List<Action<object>>());
        
        Instance._eventDatabase[eventName].Add(subscriber);
    }
    
    /// <summary>
    /// 이벤트 발산(실행)
    /// </summary>
    /// <param name="eventName">이벤트 이름</param>
    /// <param name="parameter">이벤트 메소드에 전달되는 데이터</param>
    public static void Emit(string eventName, object parameter)
    {
        if (Instance._eventDatabase.ContainsKey(eventName) == false)
        {
            Debug.LogWarning($"{eventName} 존재하지 않습니다.");
            return;
        }

        foreach (var action in Instance._eventDatabase[eventName]) action(parameter);
    }
}
