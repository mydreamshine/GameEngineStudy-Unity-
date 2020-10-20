using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scenes.Data.Scripts.UI
{
    public class ItemGroupDisplayUI : MonoBehaviour
    {
        [SerializeField] private ItemDatabase itemDatabase;
        [SerializeField] private GameObject itemUIPrefab;

        // Start is called before the first frame update
        void Start()
        {
            foreach(var itemData in itemDatabase.ItemDataList)
            {
                var go = Instantiate(itemUIPrefab, this.transform);
                var itemDisplayUI = go.GetComponent<ItemDisplayUI>();
                itemDisplayUI.itemName = itemData.itemName;
                itemDisplayUI.itemDescription = itemData.itmeDesc;
                itemDisplayUI.itemIconSprite = itemData.itemIcon;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}