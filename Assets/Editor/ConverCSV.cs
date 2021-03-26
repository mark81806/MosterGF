using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;


public class ConverCSV : Editor
{

    private static string CSVPath = @"C:\Users\mark8\whogoopo\Assets\Resources\Data";
    [MenuItem("Mark/test")]
    static void conversetest() 
    {
        Debug.Log("a");
        string [] a =  Directory.GetFiles(CSVPath);
        Debug.Log(a[0]);
        Debug.Log( Path.GetExtension(a[0]));
        Debug.Log( GetEncoding(a[0]));
        Debug.Log( File.ReadAllText(a[0],new UTF8Encoding(false))[0]);
    }
    private static Encoding GetEncoding(string filename)
    {
        // This is a direct quote from MSDN:  
        // The CurrentEncoding value can be different after the first
        // call to any Read method of StreamReader, since encoding
        // autodetection is not done until the first call to a Read method.

        using (var reader = new StreamReader(filename, Encoding.Default, true))
        {
            if (reader.Peek() >= 0) // you need this!
                reader.Read();

            return reader.CurrentEncoding;
        }
    }
}
