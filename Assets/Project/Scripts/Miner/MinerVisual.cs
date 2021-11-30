using Project.API.Models;
using Project.Scripts.Enums;
using UnityEngine;

namespace Project.Scripts.Miner
{
    public class MinerVisual : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer maleBodyMeshRenderer;
        [SerializeField] private SkinnedMeshRenderer femaleBodyMeshRenderer;
        [Space] [SerializeField] private MeshRenderer hunterHatMeshRenderer;
        [SerializeField] private MeshRenderer beardMeshRenderer;
        [Space] [SerializeField] private MeshRenderer maleHairMeshRenderer;
        [SerializeField] private MeshRenderer maleHairHatMeshRenderer;
        [SerializeField] private MeshRenderer femaleHairMeshRenderer;
        [SerializeField] private MeshRenderer femaleHairHatMeshRenderer;
        [Space] [SerializeField] private MeshRenderer maleCowboyHatMeshRenderer;
        [SerializeField] private MeshRenderer femaleCowboyHatMeshRenderer;

        public void SetupVisual(MinerModel Data)
        {
            if (Data.gender == MinerGender.Male)
            {
                maleBodyMeshRenderer.enabled = true;
                maleBodyMeshRenderer.sharedMaterial = MinerMaterialsHelper.GetMaterialById(Data.clothesMaterialId);

                if (Data.hasBeard)
                {
                    beardMeshRenderer.enabled = true;
                    beardMeshRenderer.sharedMaterial = MinerMaterialsHelper.GetMaterialById(Data.beardMaterialId);
                }

                if (Data.hat != null)
                {
                    if (Data.hat.type == HatType.Cowboy)
                    {
                        maleCowboyHatMeshRenderer.enabled = true;
                        maleCowboyHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hat.materialId);
                    }
                    else
                    {
                        hunterHatMeshRenderer.enabled = true;
                        hunterHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hat.materialId);
                    }

                    if (Data.hasHair)
                    {
                        maleHairHatMeshRenderer.enabled = true;
                        maleHairHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hairMaterialId);
                    }
                }
                else
                {
                    if (Data.hasHair)
                    {
                        maleHairMeshRenderer.enabled = true;
                        maleHairMeshRenderer.sharedMaterial = MinerMaterialsHelper.GetMaterialById(Data.hairMaterialId);
                    }
                }
            }
            else
            {
                femaleBodyMeshRenderer.enabled = true;
                femaleBodyMeshRenderer.sharedMaterial = MinerMaterialsHelper.GetMaterialById(Data.clothesMaterialId);

                if (Data.hat != null)
                {
                    if (Data.hat.type == HatType.Cowboy)
                    {
                        femaleCowboyHatMeshRenderer.enabled = true;
                        femaleCowboyHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hat.materialId);
                    }
                    else
                    {
                        hunterHatMeshRenderer.enabled = true;
                        hunterHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hat.materialId);
                    }

                    if (Data.hasHair)
                    {
                        femaleHairHatMeshRenderer.enabled = true;
                        femaleHairHatMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hairMaterialId);
                    }
                }
                else
                {
                    if (Data.hasHair)
                    {
                        femaleHairMeshRenderer.enabled = true;
                        femaleHairMeshRenderer.sharedMaterial =
                            MinerMaterialsHelper.GetMaterialById(Data.hairMaterialId);
                    }
                }
            }
        }
    }
}