using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Data.Save.Scripts.UI
{
    using System;
    using System.IO;
    using AI;

    public class SaveButtonUI : MonoBehaviour
    {
        [SerializeField] private Player player;

        public void Save()
        {
            var timeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var fileName = $"save_file_{timeStamp}.json";

            //PlayerPrefs.SetFloat("player_position_x", transform.position.x);
            //PlayerPrefs.SetFloat("player_position_y", transform.position.y);
            //PlayerPrefs.SetFloat("player_position_z", transform.position.z);

            //PlayerPrefs.SetFloat("player_rotation_x", transform.rotation.x);
            //PlayerPrefs.SetFloat("player_rotation_y", transform.rotation.y);
            //PlayerPrefs.SetFloat("player_rotation_z", transform.rotation.z);
            //PlayerPrefs.SetFloat("player_rotation_w", transform.rotation.w);

            //var isTrue = false;
            //PlayerPrefs.SetInt("boolkey", isTrue ? 1 : 0);
            //isTrue = PlayerPrefs.GetInt("boolkey") == 1 ? true : false;

            // 운영체제마다 절대경로(root_dir)가 다르기 때문에 이를
            // 알아서 Seeking해주는 Application.persistentDataPath을 이용한다.

            // 운영체제마다 폴더 구분기호가 다르기 때문에
            // 이를 알아서 조합해주는 Path.Combine을 이용한다.
            // using을 통해 instancing 된 혹은 new 된 객체에 대해서
            // using문 안에서 알아서 close 혹은 Destroy가 된다.
            using (var streamWriter = new StreamWriter(Path.Combine(Application.persistentDataPath, fileName)))
            {
                // JsonUtility.ToJson(): [Serializable]한 오브젝트에 한해서 Json으로 변경가능
                var jsonStr = JsonUtility.ToJson(new PlayerTrasmforSaveData
                {
                    playerPosition = transform.position,
                    playerRotation = transform.rotation
                });

                streamWriter.WriteLine(jsonStr);
            }
        }
    }
}
