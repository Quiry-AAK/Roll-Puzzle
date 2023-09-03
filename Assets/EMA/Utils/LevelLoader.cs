using EMA.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EMA.Utils
{
    public class LevelLoader : MonoBehaviour
    {
        private void Start()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsEnum.Level.ToString())) {
                SceneManager.LoadScene(PlayerPrefs.GetInt(PlayerPrefsEnum.Level.ToString()));
            }

            else {
                SceneManager.LoadScene(1);
            }
        }
    }
}
