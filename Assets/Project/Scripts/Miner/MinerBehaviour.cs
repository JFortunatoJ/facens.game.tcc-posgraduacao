using Project.API.Models;
using UnityEngine;

namespace Project.Scripts.Miner
{
    /// <summary>
    /// Classe centralizadora do comportamento do minerador.
    /// </summary>
    public class MinerBehaviour : MonoBehaviour
    {
        //Componente controlador das animações.
        public MinerAnimations animations;
        //Component controlador do visual.
        public MinerVisual visual;

        //Dados do minerador.
        public MinerModel Data { get; set; }

        /// <summary>
        /// Função que inicializa o minerador.
        /// </summary>
        /// <param name="data">Dados do minerador.</param>
        public void Init(MinerModel data)
        {
            Data = data;

            animations.SetGender(data.gender);
            visual.SetupVisual(data);
            
            animations.MiningAnimationStatus(true);
        }
    }
}