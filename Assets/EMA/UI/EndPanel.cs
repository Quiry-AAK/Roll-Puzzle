using DG.Tweening;
using EMA.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EMA.UI
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private Text multiplierTxt;
        [SerializeField] private Text coinTxt;
        [Space][SerializeField] private RectTransform[] panels;
        [SerializeField] private RectTransform[] buttons;


        private int finalCoinAmount;

        private int coinTxtValue = 0;

        public void AppearPanel()
        {
            finalCoinAmount = EmaStatic.FinalMultiplier * EmaStatic.CoinAmount;
            
            if(PlayerPrefs.HasKey(PlayerPrefsEnum.Coin.ToString()))
                PlayerPrefs.SetInt(PlayerPrefsEnum.Coin.ToString(), PlayerPrefs.GetInt(PlayerPrefsEnum.Coin.ToString()) + finalCoinAmount + EmaStatic.CoinAmount);
            else 
                PlayerPrefs.SetInt(PlayerPrefsEnum.Coin.ToString(), finalCoinAmount);

            multiplierTxt.text = "X" + EmaStatic.FinalMultiplier;
            
            Invoke("AppearPanelCore", 1f);
        }

        private void AppearPanelCore()
        {
            AppearPanelsInOrder();
        }

        private void AppearPanelsInOrder()
        {
            gameObject.SetActive(true);
            float delay = 0f;

            foreach (var _panel in panels) {
                delay += .3f;
                _panel.localScale = Vector3.zero;
                _panel.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack).SetDelay(delay);
            }

            DOTween.To(() => coinTxtValue, x => coinTxtValue = x, finalCoinAmount, 2f).
                SetEase(Ease.OutQuad).SetDelay(.3f).OnUpdate(AssignValue).OnComplete(AppearButtonsInOrder);
        }

        private void AssignValue()
        {
            coinTxt.text = coinTxtValue.ToString();
        }

        private void AppearButtonsInOrder()
        {
            float delay = 0f;
            foreach (var _button in buttons) {
                delay += .3f;
                _button.gameObject.SetActive(true);
                _button.localScale = Vector3.zero;
                _button.DOScale(Vector3.one, .5f).SetEase(Ease.OutBack).SetDelay(delay);
            }
        }
        
        public void GoNextLevel()
        {
            PlayerPrefs.SetInt(PlayerPrefsEnum.Level.ToString(), SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
