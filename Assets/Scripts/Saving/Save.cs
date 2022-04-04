using UnityEngine;

namespace LaraGoLike
{
    public static class Save
    {
        public static bool HasPlayed
        {
            get => PlayerPrefs.GetInt("HasPlayed", 0) == 1;
            set => PlayerPrefs.SetInt("HasPlayed", value ? 1 : 0);
        }

        public static int GetLastLevelCompleted()
        {
            return PlayerPrefs.GetInt("LastLevelCompleted",0);
        }

        public static void SetLevelCompleted(int index)
        {
            if(GetLastLevelCompleted() >= index) return;
            PlayerPrefs.SetInt("LastLevelCompleted", index);
        }
    }
}
