﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            _instance = FindObjectOfType<T>();
            if(_instance == null)
            {
                var newInstance = new GameObject(typeof(T).Name);
                _instance = newInstance.AddComponent<T>();
            }
            return _instance;
        }
    }
}
