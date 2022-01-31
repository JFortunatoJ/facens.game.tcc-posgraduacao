using Project.Scripts.Enums;
using UnityEngine;

namespace Project.Scripts.Miner
{
    /// <summary>
    /// Classe responsável por controlar as animações do minerador.
    /// </summary>
    public class MinerAnimations : MonoBehaviour
    {
        //Componente que controla a máquina de estados das animações.
        [SerializeField] private Animator animator;

        //Id do estado da animação de mineração.
        private static readonly int IsMining = Animator.StringToHash("IsMining");
        //Id do estado de animação do gênero do minerador
        private static readonly int IsMale = Animator.StringToHash("IsMale");

        /// <summary>
        /// Define o gênero.
        /// </summary>
        /// <param name="gender">Gênero</param>
        public void SetGender(MinerGender gender)
        {
            animator.SetBool(IsMale, gender == MinerGender.Male);
        }
        
        /// <summary>
        /// Ativa ou desativa a animação de mineração.
        /// </summary>
        /// <param name="status">Status da animação.</param>
        public void MiningAnimationStatus(bool status)
        {
            animator.SetBool(IsMining, status);
        }
    }
}