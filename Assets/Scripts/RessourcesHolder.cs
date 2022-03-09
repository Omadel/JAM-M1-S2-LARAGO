using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System.IO;
using System.Text;

public class RessourcesHolder:MonoBehaviour
{
    public static RessourcesHolder instance;

    private void Awake()
    {
        if(RessourcesHolder.instance!=null)
        {
            Debug.Log("there is more than 1 ressources holder");
        }
        RessourcesHolder.instance = this;

    }
    public SerializableDictionaryBase<string, GameObject> gameObjects;
    public GameObject GetGO(string name)
    {
        return gameObjects[name];

    }
    public GameObject GetGO(GameObjectKey name)
    {
        return gameObjects[name.ToString()];

    }
    public void UpdateEnumGO()
    {
        string path = "Assets/EnumRessourcesHolder/GameObjectKey.cs";
        if(File.Exists(path)==false)
        {
            File.Create(path);
        }
        using(StreamWriter outfile=new StreamWriter(path))
        {
            outfile.WriteLine("public enum GameObjectKey {");
            foreach (var item in gameObjects)
            {
                outfile.WriteLine(item.Key+",");
            }
            outfile.WriteLine("}");

        }
    }
} 



