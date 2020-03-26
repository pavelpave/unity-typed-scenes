﻿using System.IO;
using UnityEditor;

namespace IJunior.TypedScene
{
    public class TypedSceneStorage
    {
        public static void Save(string className, string sourceCode)
        {
            var path = TypedSceneSettings.SavingDirectory + className + TypedSceneSettings.ClassExtension;
            Directory.CreateDirectory(TypedSceneSettings.SavingDirectory);
            File.WriteAllText(path, sourceCode);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }

        public static void Delete(string className)
        {
            var path = TypedSceneSettings.SavingDirectory + className + TypedSceneSettings.ClassExtension;

            if (File.Exists(path))
            {
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }

            //var assets = AssetDatabase.FindAssets(className);

            //foreach(var asset in assets)
            //{
            //    var path = AssetDatabase.GUIDToAssetPath(asset);
            //    if (Path.GetFileName(path) == className + TypedSceneSettings.ClassExtension)
            //    {
            //        AssetDatabase.DeleteAsset(path);
            //        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            //    }
            //}
        }
    } 
}