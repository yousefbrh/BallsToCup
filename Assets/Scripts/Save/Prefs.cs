using UnityEngine;

namespace DefaultNamespace
{
    public class Prefs
    {
        public static int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 1);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }
}