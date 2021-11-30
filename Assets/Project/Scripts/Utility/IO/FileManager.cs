using Liga.IO.Event;
using System;

namespace Liga.IO
{
    public static class FileManager
    {
        private static IFileManager fileManagerInstance;

        private static void CheckFileBehaviourInstance()
        {
            if (fileManagerInstance != null) return;
            fileManagerInstance = new PCFileBehaviour();
        }

        public static void LoadFile<T>(string name, Action<T> callback)
        {
            CheckFileBehaviourInstance();

            FileManagerEvent.Trigger(FileManagerProcessType.Read);
            fileManagerInstance.LoadFile<T>(name, callback);
        }

        /// <summary>
        /// Listener File manager Events to handle warns
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="name"></param>
        public static void SaveFile<T>(T file, string name)
        {
            CheckFileBehaviourInstance();

            FileManagerEvent.Trigger(FileManagerProcessType.Write);
            fileManagerInstance.SaveFile<T>(file, name);
        }

        public static bool FileExists(string name)
        {
            CheckFileBehaviourInstance();
            bool fileExists = fileManagerInstance.FileExists(name);
            return fileExists;
        }
    }
}