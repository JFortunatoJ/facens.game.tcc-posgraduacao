using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinerMaterialsHelper : MonoBehaviour
{
    private static MinerMaterialsHelper _instance;
    
    public List<MaterialData> materialsList;

    private void Awake()
    {
        _instance = this;
    }

    public static Material GetMaterialById(string id)
    {
        return _instance.materialsList.Find(material => material.id.Equals(id)).material;
    }

    public static string GetRandomMaterialId()
    {
        return _instance.materialsList[Random.Range(0, _instance.materialsList.Count)].id;
    }
}

[Serializable]
public class MaterialData
{
    public string id;
    public Material material;
}
