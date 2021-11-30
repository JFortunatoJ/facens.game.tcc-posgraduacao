using Project.Scripts.Store;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{
    [SerializeField] private Button storeButton;
    [SerializeField] private Button inventoryButton;
    
    private UI_SlotInteractions _inventory;
    private SlotsManager _slotsManager;

    private void Start()
    {
        _inventory = FindObjectOfType<UI_SlotInteractions>();
        
        storeButton.onClick.AddListener(OnStoreButtonClick);
        inventoryButton.onClick.AddListener(OnInventoryButtonClick);
    }

    private void OnInventoryButtonClick()
    {
        /*
        InventoryManager.Show(() =>
        {
            InventoryManager.Hide();
        });
        */
    }

    private void OnStoreButtonClick()
    {
        StoreManager.Show(() =>
        {
            _inventory.Refresh();
            StoreManager.Hide();
        });
    }
}
