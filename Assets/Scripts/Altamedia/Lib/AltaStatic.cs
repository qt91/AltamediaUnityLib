using UnityEngine;
using System.Collections;
using System;
using System.IO;

public static class AltaStatic {


    /* Write from path file and Generic Object 
     */
    public static void Write<T>(T overview, string fileName, string filePath = null)
    {
        if (filePath == null)
        {
            filePath = Application.streamingAssetsPath;
        }
        string file = System.IO.Path.Combine(filePath, fileName);

        if (string.IsNullOrEmpty(file))
            throw new Exception("File Not Empty");
        System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        if (!File.Exists(file))
        {
            using (Stream s = File.Open(file, FileMode.OpenOrCreate))
            {
                writer.Serialize(s, overview);
            }
        }
        else
        {
            using (Stream s = File.Open(file, FileMode.Truncate))
            {
                writer.Serialize(s, overview);
            }
        }
    }

    public static T Read<T>(string fileName, string filePath = null)
    {
        if (filePath == null)
        {
            filePath = Application.streamingAssetsPath;
        }
        string file = System.IO.Path.Combine(filePath, fileName);
        
        if (!File.Exists(file))
        {
            T NewObject = (T)Activator.CreateInstance(typeof(T));
            Write(NewObject,file);
            return NewObject;
        }
        else
        {
            try
            {
                using (Stream s = File.Open(file, FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    return (T)reader.Deserialize(s);
                }
            }
            catch (Exception ex)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }

        }
    }
}
