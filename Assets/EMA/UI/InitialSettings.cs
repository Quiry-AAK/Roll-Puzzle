using EMA.Utils;
using UnityEngine;

namespace EMA.UI
{
    public class InitialSettings : MonoBehaviour
    {
        public Vector2 resolution = new Vector2(720f, 1280f);
        public Camera cam;
        private void Start()
        {
            int screenWidth = 0;
            int screenHeight = 0;
            if (!PlayerPrefs.HasKey(PlayerPrefsEnum.ScreenHeight.ToString()) && !PlayerPrefs.HasKey(PlayerPrefsEnum.ScreenWidth
                    .ToString())) {
                screenWidth = (int)(Screen.width / 1.5f);
                screenHeight = (int)(Screen.height / 1.5f);
                PlayerPrefs.SetInt(PlayerPrefsEnum.ScreenHeight.ToString(), screenHeight);
                PlayerPrefs.SetInt(PlayerPrefsEnum.ScreenWidth.ToString(), screenWidth);
            }
            Screen.SetResolution(PlayerPrefs.GetInt(PlayerPrefsEnum.ScreenWidth.ToString()), PlayerPrefs.GetInt(PlayerPrefsEnum.ScreenHeight.ToString()), true);
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = 60;
            
            EmaStatic.ResetValues();
        }
    }
}
