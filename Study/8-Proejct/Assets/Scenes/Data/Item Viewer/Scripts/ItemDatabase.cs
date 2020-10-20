using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Data.Scripts
{
    [CreateAssetMenu(fileName ="item_database", menuName ="KPU/아이템 데이터베이스 만들기.")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private List<ItemData> itemDatList;
        public List<ItemData> ItemDataList => itemDatList;
    }
}
