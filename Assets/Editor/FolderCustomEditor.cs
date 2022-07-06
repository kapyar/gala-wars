using System.IO;
using UnityEditor;
using UnityEngine;

public class FolderCustomEditor : Editor
{
    [MenuItem("Tools/Open data dir")]
    public static void OpenDataDir()
    {
#if UNITY_EDITOR_WIN
            var fullPath = Directory.GetParent(Application.persistentDataPath).FullName + "/" + Application.productName;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = fullPath,
                UseShellExecute = true,
                Verb = "open"
            });
#elif UNITY_EDITOR_OSX
        var path = Directory.GetParent(Application.persistentDataPath).FullName + "/" + Application.productName;
        EditorUtility.RevealInFinder(path);
#else
        Log.Info(Application.persistentDataPath);

#endif
    }
}