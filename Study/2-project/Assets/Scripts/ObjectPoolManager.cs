using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : SingletonBehaviour<ObjectPoolManager>
{
    // Inner Class를 정의할 시 C#에서 자동으로 Serialize를 하지 않기 때문에
    // 아래와 같이 Serializable을 명시해준다.
    [Serializable]
    public class ObjectPoolData
    {
        public string name;
        public GameObject prefab;
    }

    // 클래스 전역 멤버는 Unity 상에서 Inspector를 통해 Script Component로 삽입할 경우
    // 해당 Component UI에서 접근 가능하다.
    public List<ObjectPoolData> prefabs;

    private IDictionary<string, List<GameObject>> _objectPool;

    private void Awake()
    {
        _objectPool = new Dictionary<string, List<GameObject>>();
    }

    public GameObject Spawn(string spawnTargetName)
    {
        if (_objectPool.ContainsKey(spawnTargetName) == false)
        {
            _objectPool.Add(spawnTargetName, new List<GameObject>());
        }

        var founded = _objectPool[spawnTargetName].FirstOrDefault(obj => !obj.activeInHierarchy);

        if (founded == null)
        {
            // FirstOrDefault: algorithm의 FindIf(lamda)와 유사
            var foundedPrefabData = prefabs.FirstOrDefault(prefabData => prefabData.name == spawnTargetName);

            if (foundedPrefabData == null)
            {
                Debug.LogWarning($"{spawnTargetName} 이라는 prefab은 존재하지 않습니다.");
                return null;
            }
            
            // Instantiate(GameObject): 해당 GameObject로 인스턴싱
            founded = Instantiate(foundedPrefabData.prefab);

            _objectPool[spawnTargetName].Add(founded);
        }
        
        founded.SetActive(true);
        
        return founded;
    }
}
