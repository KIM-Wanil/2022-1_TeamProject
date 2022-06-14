using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject SettingPanel;
    //AudioSource audioSource;
    //public AudioClip audioClick;
    void Start()
    {
        //this.audioSource = GetComponent<AudioSource>();
    }
    public void Menu_button()
    {
        Time.timeScale = 0; //게임 일시정지
        MenuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }
    public void Setting_button()
    {
        SettingPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void Ok_button()
    {
        SettingPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void click_sound()
    {
        //audioSource.clip = audioClick;
        //audioSource.Play();
    }
}

