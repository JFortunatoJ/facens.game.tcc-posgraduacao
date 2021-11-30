using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;


namespace Liga.IO
{
    public class JsonUtility : IJsonUtility
    {
        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
