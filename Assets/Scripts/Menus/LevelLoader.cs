using UnityEngine;

namespace LaraGoLike
{
    internal enum Scene : int { Loader, MainMenu}
    public class LevelLoader : Etienne.SceneLoader
    {
        protected override void Awake()
        {
            base.Awake();
            Save.InitSave();
        }
    }
}
