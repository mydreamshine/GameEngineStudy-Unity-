using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scenes.Data.Scripts.UI
{
    using TMPro;
    using UnityEngine.UI;
    public class ItemDisplayUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI itemDescText;
        [SerializeField] private Image ItemIcon;

        public string itemName;
        public string itemDescription;
        public Sprite itemIconSprite;

        private void Update()
        {
            itemNameText.text = itemName;
            itemDescText.text = itemDescription;
            ItemIcon.sprite = itemIconSprite;
        }
    }
}
