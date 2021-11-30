using System;
using Project.Scripts.Enums;

namespace Project.API.Models
{
    [Serializable]
    public class SlotModel
    {
        public string id;
        public TerrainType type;
        public MinerModel miner;
        public bool hasWater;
        public bool hasBuff;
        public DateTimeOffset miningStartTime;

        public SlotModel(TerrainType type)
        {
            this.type = type;
            miner = null;
            hasWater = false;
            hasBuff = false;
            miningStartTime = DateTimeOffset.MaxValue;
        }
    }
}
