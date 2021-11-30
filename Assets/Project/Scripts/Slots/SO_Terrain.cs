using Project.Scripts.Enums;
using UnityEngine;

[CreateAssetMenu]
public class SO_Terrain : ScriptableObject
{
    public TerrainType TerrainType;
    public GameObject terrainPrefab;
}
