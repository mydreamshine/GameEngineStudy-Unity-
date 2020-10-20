using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Scenes.Data.Save.Scripts;
using Scenes.AI;

public class SaveFileListItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fileNameText;

    public string FileName()
    {
        set
            {
            fileNameText.text = value;
        }
    }   

    public void LoadSaveFile()
    {
        //transform.position = new Vector3(
        //    PlayerPrefs.GetFloat("player_position_x"),
        //    PlayerPrefs.GetFloat("player_position_y"),
        //    PlayerPrefs.GetFloat("player_position_z")
        //    );

        //transform.rotation = new Quaternion(
        //    PlayerPrefs.GetFloat("player_rotation_x"),
        //    PlayerPrefs.GetFloat("player_rotation_y"),
        //    PlayerPrefs.GetFloat("player_rotation_z"),
        //    PlayerPrefs.GetFloat("player_rotation_w")
        //    );

        using (var streamReader = new StreamReader(Path.Combine(Application.persistentDataPath, fileNameText.text)))
        {
            var playerTransformSaveData = JsonUtility.FromJson<PlayerTrasmforSaveData>(streamReader.ReadToEnd());
            var player = FindObjectOfType<Player>();

            player.transform.position = playerTransformSaveData.playerPosition;
            player.transform.rotation = playerTransformSaveData.playerRotation;

        }
    }
}
