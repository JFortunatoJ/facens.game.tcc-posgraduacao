using System;
using Project.Scripts.Enums;
using Random = UnityEngine.Random;

namespace Project.API.Models
{
    [Serializable]
    public class MinerModel
    {
        public string id;
        public MinerGender gender;
        public bool hasBeard;
        public bool hasHair;
        public HatModel hat;
        public string clothesMaterialId;
        public string beardMaterialId;
        public string hairMaterialId;
        public int miningTime;
        public int coinsPerMining;

        public static MinerModel RandomMiner()
        {
            MinerModel miner = new MinerModel();
            
            miner.id = Guid.NewGuid().ToString();
            miner.gender = Random.value < 0.5f ? MinerGender.Male : MinerGender.Female;
            miner.clothesMaterialId = MinerMaterialsHelper.GetRandomMaterialId();

            if (miner.gender == MinerGender.Male)
            {
                miner.hasBeard = Random.value < 0.5f;
                miner.beardMaterialId = MinerMaterialsHelper.GetRandomMaterialId();
            }

            miner.hasHair = Random.value < 0.5f;
            miner.hairMaterialId = MinerMaterialsHelper.GetRandomMaterialId();

            if (Random.value < 0.5f)
            {
                miner.hat = new HatModel();
                miner.hat.SetRandomData();
            }

            //miner.miningTime = Random.Range(1800, 3600);
            miner.miningTime = Random.Range(5, 15);
            miner.coinsPerMining = Random.Range(10, 100);

            return miner;
        }
    }
}