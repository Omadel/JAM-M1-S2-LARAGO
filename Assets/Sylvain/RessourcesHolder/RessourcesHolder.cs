using RotaryHeart.Lib.SerializableDictionary;
using System.IO;
using UnityEngine;


public class RessourcesHolder : MonoBehaviour
{
    public static RessourcesHolder instance;

    private void Awake()
    {
        if (RessourcesHolder.instance != null)
        {
            Debug.Log("there is more than 1 ressources holder");
        }
        RessourcesHolder.instance = this;

    }

    public SerializableDictionaryBase<string, GameObject> gameObjects;
    public SerializableDictionaryBase<string, Sprite> sprites;
    public GameObject GetGO(string name)
    {
        return gameObjects[name];

    }
    public GameObject GetGO(GameObjectKey name)
    {
        return gameObjects[name.ToString()];

    }
    public GameObject GetMagGO(MagnetType name)
    {
        return gameObjects["Mag_"+name.ToString()];

    }
    public Sprite GetSprite(string name)
    {
        return sprites[name];

    }
    public Sprite GetMagSprite(MagnetType name)
    {
        return sprites["Mag_" + name.ToString()];

    }
    public void UpdateEnums()
    {
        
        string GOPath = "Assets/Scripts/EnumRessourcesHolder/GameObjectKey.cs";
        if (File.Exists(GOPath) == false)
        {
            File.Create(GOPath);
        }
        using (StreamWriter outfile = new StreamWriter(GOPath))
        {
            outfile.WriteLine("public enum GameObjectKey {");
            foreach (var item in gameObjects)
            {
                outfile.WriteLine(item.Key + ",");
            }
            outfile.WriteLine("}");

        }
        string SPath = "Assets/Scripts/EnumRessourcesHolder/SpritesKey.cs";
        if (File.Exists(SPath) == false)
        {
            File.Create(SPath);
        }
        using (StreamWriter outfile = new StreamWriter(SPath))
        {
            outfile.WriteLine("public enum SpritesKey {");
            foreach (var item in sprites)
            {
                outfile.WriteLine(item.Key + ",");
            }
            outfile.WriteLine("}");

        }
    }
}




