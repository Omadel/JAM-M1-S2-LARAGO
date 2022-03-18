using System.Collections.Generic;
using System.IO;
using UnityEngine;

[DefaultExecutionOrder(-1)] 
public class RessourcesHolder : MonoBehaviour
{

    public List<Object> gameObjects;
    private static Dictionary<string, Object> Objects = new Dictionary<string, Object>();
    private void Awake()
    {
        creatDico(gameObjects);
    }
    public void creatDico(List<Object> list)
    {
        Objects = new Dictionary<string, Object>();
        foreach (Object item in list)
        {
            string key = "";
            if (item is GameObject)
            {
                key += "go";
            }
            if (item is Sprite||item is Texture2D)
            {
                key += "s";
            }
            key += "_" + item.name;
            Objects.Add(key, item);
        }
    }
    public static Object GetRessources(ObjectKey name)
    {
        return Objects[name.ToString()];
    }
    public static Object GetRessources(string name)
    {
        return Objects[name];
    }
    public void UpdateEnums()
    {

        creatDico(gameObjects);
        string GOPath = "Assets/Scripts/EnumRessourcesHolder/ObjectKey.cs";
        if (File.Exists(GOPath) == false)
        {
            File.Create(GOPath);
        }
        using (StreamWriter outfile = new StreamWriter(GOPath))
        {
            outfile.WriteLine("public enum ObjectKey {");
            foreach (KeyValuePair<string, Object> item in Objects)
            {
                outfile.WriteLine(item.Key + ",");
            }
            outfile.WriteLine("}");

        }
    }
}




