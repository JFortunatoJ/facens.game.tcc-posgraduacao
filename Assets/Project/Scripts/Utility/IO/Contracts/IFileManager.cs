using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liga.IO
{

    public interface IFileManager
    {
        void SaveFile<T>(T data, string name);
        void LoadFile<T>(string name, Action<T> callback);
        bool FileExists(string name);
    }
}