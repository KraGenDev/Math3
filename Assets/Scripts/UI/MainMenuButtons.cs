using System;
using AppsFlyerSDK;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _data;
    [SerializeField] private Button _menu;
    [SerializeField] private GameObject _playScreen;
    [SerializeField] private GameObject _dataScreen;
    [SerializeField] private GameObject _menuScreen;

    private void Start()
    {
        _play.onClick.AddListener(Play);
        _data.onClick.AddListener(Data);
        _menu.onClick.AddListener(Menu);
    }

    private void Play()
    {
        _playScreen.SetActive(true);
        _menuScreen.SetActive(false);
        _dataScreen.SetActive(false);
    }

    private void Data()
    {
        _playScreen.SetActive(false);
        _dataScreen.SetActive(!_dataScreen.activeSelf);
        _menuScreen.SetActive(true);
        AppsFlyer.getConversionData(gameObject.name);
    }

    private void Menu()
    {
        _playScreen.SetActive(false);
        _dataScreen.SetActive(false);
        _menuScreen.SetActive(true);
    }
}
