using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager MenuManager;
    
    [SerializeField] private AudioSource _source;
    [SerializeField] private Button _buttonMucsicOn;
    [SerializeField] private Button _buttonMucsicOff;
    public static int flag = 1;
    //[SerializeField] private GameObject ;

    private void Start()
    {
        Instance();
        if(flag == 0)
        {
            _source.mute = true;
            _buttonMucsicOn.gameObject.SetActive(false);
            _buttonMucsicOff.gameObject.SetActive(true);
        }
        else
        {
            _source.mute = false;
            _buttonMucsicOn.gameObject.SetActive(true);
            _buttonMucsicOff.gameObject.SetActive(false);
        }
    }

    public void MuteMusic()
    {
        flag = 0;
        _source.mute = true;
        _buttonMucsicOn.gameObject.SetActive(false);
        _buttonMucsicOff.gameObject.SetActive(true);

    }

    public void Instance()
    {
        if (MenuManager == null)
        {
            MenuManager = this;
        }
    }
    
    public void OnMusic()
    {
        flag = 1;
        _source.mute = false;
        _buttonMucsicOn.gameObject.SetActive(true);
        _buttonMucsicOff.gameObject.SetActive(false);

    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
