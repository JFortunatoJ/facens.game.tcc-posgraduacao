using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Liga.IO
{

    public interface IJsonUtility 
    {
        T Deserialize<T>(string data);

        string Serialize<T>(T data);
    }
}