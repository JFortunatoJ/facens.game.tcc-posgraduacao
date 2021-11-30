using System;
using Project.Scripts.Enums;

namespace Project.API.Models
{
    [Serializable]
    public class HatModel
    {
        public string id;
        public HatType type;
        public string materialId;

        public void SetRandomData()
        {
            id = Guid.NewGuid().ToString();
            type = UnityEngine.Random.value < 0.5f ? HatType.Cowboy : HatType.Hunter;
            materialId = MinerMaterialsHelper.GetRandomMaterialId();
        }
    }
}
