using Liga.IO.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liga.IO
{
    public class PCFileBehaviour : IFileManager
    {
        public bool FileExists(string name)
        {
            return PlayerPrefs.HasKey(name);
        }

        public void LoadFile<T>(string name, Action<T> callback)
        {
            string data = "";
            T deserialized = default(T);

            if (FileExists(name))
            {
                data = PlayerPrefs.GetString(name);
                deserialized = JsonController.Deserialize<T>(data);
            }

            FileManagerEvent.Trigger(FileManagerProcessType.Completed);

            callback?.Invoke(deserialized);
        }

        public void SaveFile<T>(T data, string name)
        {
            var saveResult = true;
            try
            {
                var serialized = JsonController.Serialize<T>(data);
                PlayerPrefs.SetString(name, serialized);
                PlayerPrefs.Save();
                
                Debug.Log("Save Success!");
            }
            catch (Exception e)
            {
                Debug.LogError("Fail to " + e.Message);
                saveResult = false;
            }

            FileManagerEvent.Trigger(FileManagerProcessType.Completed);
        }
    }
}