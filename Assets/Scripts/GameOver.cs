using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _newCamera;
    [SerializeField] private GameObject _background;

    public void ShowGameOver()
    {
        _background.SetActive(true);
        _newCamera.SetActive(true);
        _player.SetActive(false);
    }
}
