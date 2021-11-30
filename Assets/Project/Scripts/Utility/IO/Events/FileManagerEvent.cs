using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liga.IO.Event
{
    public enum FileManagerProcessType
    {
        Read, Write, Completed
    }

    public struct FileManagerEvent
    {
        public FileManagerProcessType fileManagerType;

        public FileManagerEvent(FileManagerProcessType e)
        {
            fileManagerType = e;
        }

        static FileManagerEvent fileManagerEvent;

        public static void Trigger(FileManagerProcessType e)
        {
            fileManagerEvent.fileManagerType = e;
            //Todo trigger event here
        }
    }
}