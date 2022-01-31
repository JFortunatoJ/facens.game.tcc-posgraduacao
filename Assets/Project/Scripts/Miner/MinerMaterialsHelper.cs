using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Componente responsável por armazenar todos os materiais do minerador.
/// </summary>
public class MinerMaterialsHelper : MonoBehaviour
{
    private static MinerMaterialsHelper _instance;
    
    public List<MaterialData> materialsList;

    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// Busca um material pelo seu id.
    /// </summary>
    /// <param name="id">Id do material.</param>
    /// <returns></returns>
    public static Material GetMaterialById(string id)
    {
        return _instance.materialsList.Find(material => material.id.Equals(id)).material;
    }

    /// <summary>
    /// Retorna um material aleatório.
    /// </summary>
    /// <returns></returns>
    public static string GetRandomMaterialId()
    {
        return _instance.materialsList[Random.Range(0, _instance.materialsList.Count)].id;
    }
}

/// <summary>
/// Dados do material.
/// </summary>
[Serializable]
public class MaterialData
{
    //Id do material.
    public string id;
    //Asset do material.
    public Material material;
}
