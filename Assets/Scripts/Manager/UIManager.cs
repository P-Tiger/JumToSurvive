using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager _UIManager;
    [SerializeField] private Text textScore;
    [SerializeField] private Text endScore;
    [SerializeField] private Text bestScore;
    [SerializeField] private GameObject _panelDied;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject PanelPause;
    [SerializeField] private GameObject PanelAboutCoins;
    [SerializeField] private Text ScoreCoinsCollect;
    [SerializeField] private GameObject PanelCongratulations;
    [SerializeField] private GameObject TutorialPanel;
    // Start is called before the first frame update
    void Awake()
    {
        textScore.text = "0";
        MakeInstance();
        if (PlayerController.flap_Score)
        {
            TutorialPanel.SetActive(false);
        }
    }

    void MakeInstance()
    {
        if (_UIManager == null)
        {
            _UIManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = PlayerController.Score.ToString();
    }

    #region event Show Panel
    public void ShowPanelDied()
    {
        endScore.text = textScore.text;
        if (PlayerController.Score > GameManger.instance.GetHightScore())
        {
            GameManger.instance.SetHightScore(PlayerController.Score);
        }
        bestScore.text = GameManger.instance.GetHightScore().ToString();
        pauseButton.gameObject.SetActive(false);
        _panelDied.gameObject.SetActive(true);
    }

    public void showPanelAboutCoins()
    {
        ScoreCoinsCollect.text = PlayerController.Coins.ToString();
        PanelAboutCoins.SetActive(true);
        _panelDied.SetActive(false);
    }

    public void ShowPanelCongratulations()
    {
        PanelCongratulations.SetActive(true);
    }
    #endregion

    #region Event Button
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
    }

    public void onPanelPause()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        PanelPause.gameObject.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        PanelPause.gameObject.SetActive(false);
    }

    public void back()
    {
        PanelAboutCoins.SetActive(false);
        _panelDied.SetActive(true);
    }

    public void continue_Play()
    {
        PanelCongratulations.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
  
    public void TaptoPlay()
    {
        Time.timeScale = 1;
        TutorialPanel.SetActive(false);
    }
    #endregion
}
