using System;
using System.Collections.Generic;
using Project.API.Models;
using Project.Scripts.Enums;
using Project.Scripts.Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        /*
        [SerializeField] private Button closeButton;
        [Space] [SerializeField] private UI_InventoryItem itemPrefab;
        [SerializeField] private Transform holder;
        [Space] [SerializeField] private Button selectItemButton;

        private static Action _callback;
        private UI_InventoryItem _currentItem;

        public static void Show(Action callback)
        {
            _callback = callback;
            SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);
        }

        public static void Hide()
        {
            SceneManager.UnloadSceneAsync("Inventory");
        }

        private void Start()
        {
            closeButton.onClick.AddListener(OnCloseButtonClick);
            selectItemButton.onClick.AddListener(OnSelectItemButtonClick);

            selectItemButton.gameObject.SetActive(false);

            List<ItemModel> playerItems = GameDataManager.Instance.Profile.items;
            for (int i = 0; i < playerItems.Count; i++)
            {
                UI_InventoryItem newItem = Instantiate(itemPrefab, holder);
                newItem.Init(playerItems[i], this);
            }
        }

        private void OnSelectItemButtonClick()
        {
            if (_currentItem.Data.type != ItemType.Miner)
            {
                return;
            }
            
            GameDataManager.Instance.RemoveItem(_currentItem.Data.id);
            SlotsManager.AddNewMiner();
            
            _callback?.Invoke();
        }

        private void OnCloseButtonClick()
        {
            _callback?.Invoke();
        }

        public void SelectItem(UI_InventoryItem item)
        {
            if (_currentItem == item)
            {
                _currentItem.IsSelected = false;
                _currentItem = null;

                selectItemButton.gameObject.SetActive(false);

                return;
            }

            if (_currentItem != null)
            {
                _currentItem.IsSelected = false;
            }

            _currentItem = item;
            _currentItem.IsSelected = true;
            
            selectItemButton.gameObject.SetActive(_currentItem.Data.type == ItemType.Miner);
        }
        */
    }
}