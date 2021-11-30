using Project.Scripts.Enums;
using UnityEngine;

namespace Project.Scripts.Miner
{
    public class MinerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private static readonly int IsMining = Animator.StringToHash("IsMining");
        private static readonly int IsMale = Animator.StringToHash("IsMale");

        public void SetGender(MinerGender gender)
        {
            animator.SetBool(IsMale, gender == MinerGender.Male);
        }
        
        public void MiningAnimationStatus(bool status)
        {
            animator.SetBool(IsMining, status);
        }
    }
}