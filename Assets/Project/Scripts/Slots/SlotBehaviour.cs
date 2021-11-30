using System;
using System.Collections;
using Project.API.Models;
using Project.Scripts.Miner;
using Project.Scripts.Save;
using Project.Scripts.UI;
using UnityEngine;

namespace Project.Scripts
{
    public class SlotBehaviour : MonoBehaviour
    {
        [SerializeField] private UI_SlotBehaviour uiSlot;

        public bool HasWater
        {
            get => _data.hasWater;
            set
            {
                _data.hasWater = value;
                uiSlot.HasWater = value;
            }
        }

        public bool HasBuff
        {
            get => _data.hasBuff;
            set
            {
                _data.hasBuff = value;
                uiSlot.HasBuff = value;
            }
        }
        
        public SlotModel Data => _data;
        
        public MinerBehaviour Miner => _miner;

        public SO_Terrain Terrain => _terrain;

        public bool MiningFinished
        {
            get
            {
                double passedTime = (DateTimeOffset.Now - _data.miningStartTime).TotalSeconds;
                return passedTime > _miner.Data.miningTime;
            }
        }

        private MinerBehaviour _miner;
        private SO_Terrain _terrain;
        private SlotModel _data;
        private double _remainingMiningTime;

        public void Init(SlotModel data)
        {
            _data = data;
            Instantiate(SlotTerrainsHelper.GetTerrainByType(_data.type).terrainPrefab, transform);
        }
        
        public void Init(SlotModel data, MinerBehaviour miner)
        {
            Init(data);
            
            _miner = miner;
            _miner.transform.SetParent(transform);
            _miner.transform.localPosition = Vector3.zero;

            uiSlot.Coins = miner.Data.coinsPerMining;

            if (MiningFinished)
            {
                FinishMining();
            }
            else
            {
                ContinueMining();
            }
        }

        public void AddMiner(MinerBehaviour miner)
        {
            _miner = miner;
            _miner.transform.SetParent(transform);
            _miner.transform.localPosition = Vector3.zero;

            _data.miner = miner.Data;
            uiSlot.Coins = miner.Data.coinsPerMining;
            
            StartMining();
        }

        public void CollectCoins()
        {
            GameDataManager.Instance.Coins += _miner.Data.coinsPerMining;
            
            StartMining();
        }

        private void StartMining()
        {
            uiSlot.SetCoinsVisibilityStatus(false);
            
            _data.miningStartTime = DateTimeOffset.Now;
            _remainingMiningTime = _miner.Data.miningTime;

            HasWater = false;
            HasBuff = false;
            
            _miner.animations.MiningAnimationStatus(true);
            StartCoroutine(MiningCoroutine());
        }

        private void ContinueMining()
        {
            double passedTime = (DateTimeOffset.Now - _data.miningStartTime).TotalSeconds;
            _remainingMiningTime = _miner.Data.miningTime - passedTime;
            
            _miner.animations.MiningAnimationStatus(true);
            StartCoroutine(MiningCoroutine());
        }

        private IEnumerator MiningCoroutine()
        {
            uiSlot.RemainingSeconds = _remainingMiningTime;
            
            WaitForSeconds waitOneSecond = new WaitForSeconds(1);
            while (_remainingMiningTime > 0)
            {
                yield return waitOneSecond;
                _remainingMiningTime--;
                uiSlot.RemainingSeconds = _remainingMiningTime;
            }
            
            FinishMining();
        }

        private void FinishMining()
        {
            _miner.animations.MiningAnimationStatus(false);
            uiSlot.SetCoinsVisibilityStatus(true);
        }
        
    }
}
