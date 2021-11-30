using System;
using System.Collections.Generic;
using Project.API.Models;
using Project.Scripts;
using Project.Scripts.Enums;
using Project.Scripts.Inventory;
using Project.Scripts.Miner;
using Project.Scripts.Save;
using Project.Scripts.UI;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    private static SlotsManager _instance;

    [SerializeField] private MinerBehaviour minerPrefab;
    [Space] [SerializeField] private List<SlotBehaviour> slots;
    [Space] [SerializeField] private UI_SlotInteractions inventory;

    private static UI_SlotBehaviour _currentSlot;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        inventory.onItemSelected = OnItemSelected;

        SetupSlots();
    }

    private void OnItemSelected(ItemModel item)
    {
        if (_currentSlot == null) return;

        So_Item data = ItemsHelper.GetItemById(item.itemId);
        switch (data.type)
        {
            case ItemType.Miner:
                if (AddNewMiner())
                {
                    SpendItem(item);
                }

                break;
            case ItemType.Water:
                if (AddWater())
                {
                    SpendItem(item);
                }

                break;
            case ItemType.StrengthBuff:
                if (AddBuff())
                {
                    SpendItem(item);
                }

                break;
        }
    }

    private void SpendItem(ItemModel item)
    {
        GameDataManager.Instance.RemoveItem(item.itemId);
        inventory.Refresh();

        _currentSlot.IsSelected = false;
        _currentSlot = null;
    }

    private void SetupSlots()
    {
        List<SlotModel> playerSlots = GameDataManager.Instance.Profile.slots;
        for (int i = 0; i < playerSlots.Count; i++)
        {
            if (playerSlots[i].miner == null)
            {
                slots[i].Init(playerSlots[i]);
            }
            else
            {
                SlotBehaviour slot = GetAvailableSlot();
                if (slot == null)
                {
                    Debug.LogError("Não há mais slots disponíveis");
                    return;
                }

                MinerBehaviour newMiner = Instantiate(minerPrefab);
                newMiner.Init(playerSlots[i].miner);
                slot.Init(playerSlots[i], newMiner);
            }
        }
    }

    private bool AddNewMiner()
    {
        if (_currentSlot.slot.Miner != null)
        {
            Debug.LogError("Esse slot já está ocupado!");
            return false;
        }

        MinerModel randomMiner = MinerModel.RandomMiner();
        MinerBehaviour newMiner = Instantiate(_instance.minerPrefab);
        newMiner.Init(randomMiner);
        _currentSlot.slot.AddMiner(newMiner);

        inventory.Hide();

        return true;
    }

    private bool AddWater()
    {
        if (_currentSlot.HasWater)
        {
            Debug.LogError("Esse slot já contém água!");
            return false;
        }

        inventory.Hide();

        _currentSlot.slot.HasWater = true;

        return true;
    }

    private bool AddBuff()
    {
        if (_currentSlot.HasBuff)
        {
            Debug.LogError("Esse slot já contém buff!");
            return false;
        }

        _currentSlot.slot.HasBuff = true;

        inventory.Hide();

        return true;
    }

    public static void CollectCoins()
    {
        if (_currentSlot == null || _currentSlot.slot.Miner == null || !_currentSlot.slot.MiningFinished) return;

        _currentSlot.slot.CollectCoins();

        _currentSlot.IsSelected = false;
        _currentSlot = null;
        
        _instance.inventory.Hide();
    }

    public static void SelectSlot(UI_SlotBehaviour slot)
    {
        if (_currentSlot == slot)
        {
            _currentSlot.IsSelected = false;
            _currentSlot = null;

            _instance.inventory.Hide();
            return;
        }

        if (_currentSlot != null)
        {
            _currentSlot.IsSelected = false;
        }

        _currentSlot = slot;
        _currentSlot.IsSelected = true;


        _instance.inventory.Show(_currentSlot.slot.Miner != null && _currentSlot.slot.MiningFinished);
    }

    private SlotBehaviour GetAvailableSlot()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].Miner == null) return slots[i];
        }

        return null;
    }
}