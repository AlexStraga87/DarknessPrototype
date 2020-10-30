using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private TMP_Text _text;

    public void OnClick()
    {
        _text.text = "Загрузка";
        StartCoroutine(LoadScene());
        gameObject.transform.position = Vector3.up * 10000;
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(_sceneName);
    }
}
