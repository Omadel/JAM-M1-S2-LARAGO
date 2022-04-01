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
    }
}
