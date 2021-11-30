using Project.API.Models;
using Project.Scripts.Enums;
using UnityEngine;

namespace Project.Scripts.Miner
{
    public class MinerBehaviour : MonoBehaviour
    {
        public MinerAnimations animations;
        public MinerVisual visual;

        public MinerModel Data { get; set; }

        public void Init(MinerModel data)
        {
            Data = data;

            animations.SetGender(data.gender);
            visual.SetupVisual(data);
            
            animations.MiningAnimationStatus(true);
        }
    }
}