using System.Collections.Generic;
using Project.Scripts.Enums;
using UnityEngine;

public class SlotTerrainsHelper : MonoBehaviour
{
    private static SlotTerrainsHelper _instance;
    
    [SerializeField] private List<SO_Terrain> terrains;

    private void Awake()
    {
        _instance = this;
    }

    public static SO_Terrain GetTerrainByType(TerrainType type)
    {
        return _instance.terrains.Find(terrain => terrain.TerrainType == type);
    }
}
