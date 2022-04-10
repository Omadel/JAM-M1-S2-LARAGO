using UnityEngine;

namespace LaraGoLike
{
    public static class Save
    {
        public static bool HasPlayed
        {
            get => PlayerPrefs.GetInt("HasPlayed") == 1;
            set => PlayerPrefs.SetInt("HasPlayed", value ? 1 : 0);
        }

        public static int GetLastLevelCompleted()
        {
            return PlayerPrefs.GetInt("LastLevelCompleted");
        }

        public static void SetLevelCompleted(int index)
        {
            Debug.Log("Saved "+index);
            if(GetLastLevelCompleted() >= index) return;
            PlayerPrefs.SetInt("LastLevelCompleted", index);
        }

        public static void InitSave()
        {
            if (!PlayerPrefs.HasKey("HasPlayed")) PlayerPrefs.SetInt("HasPlayed",0);
            if (!PlayerPrefs.HasKey("LastLevelCompleted")) PlayerPrefs.SetInt("LastLevelCompleted",0);
            
        }
    }
}
