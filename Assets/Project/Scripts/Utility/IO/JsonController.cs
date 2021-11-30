using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Liga.IO
{
    public class JsonController  
    {
        static private  IJsonUtility jsonUtility;

        static private void SetInstace()
        {
            jsonUtility = new JsonUtility();
        }

        static public string Serialize<T>(T data)
        {
            if (jsonUtility == null) SetInstace();

            return jsonUtility.Serialize<T>(data);
        }

        static public T Deserialize<T>(string data)
        {
            if (jsonUtility == null) SetInstace();

            return jsonUtility.Deserialize<T>(data);
        }
    }
}