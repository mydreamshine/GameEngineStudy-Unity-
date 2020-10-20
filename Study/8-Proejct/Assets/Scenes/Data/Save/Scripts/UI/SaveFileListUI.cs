using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Scenes.Data.Save.Scripts;

public class SaveFileListUI : MonoBehaviour
{
    [SerializeField] private GameObject listItemUIPrefab;

    private void OnEnable()
    {
        var fileList = Directory.GetFiles(Application.persistentDataPath);

        foreach (string filePath in fileList)
        {
            var go = Instantiate(listItemUIPrefab, transform);
        }
    }
}
