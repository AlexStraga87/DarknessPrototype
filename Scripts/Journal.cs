using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Journal : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _background;
    [SerializeField] private TMP_Text _textField1;
    [SerializeField] private TMP_Text _textField2;
    [SerializeField] private List<JournalPage> _pages;
    [SerializeField] private int _unlockedPages = 2;
    [SerializeField] private int _currentTab = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //if (!_background.activeSelf)
                SetActiveJournal(!_background.activeSelf);
        }

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActiveJournal(false);
        }
        */
        if (_background.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {                
                PrevTab();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextTab();
            }
        }
    }

    public void UnlockPages(int count)
    {
        _unlockedPages = count;
    }

    public void SetActiveJournal(bool isShow)
    {
        _background.SetActive(isShow);
        if (isShow)
        {            
            FillPages();
        }
    }

    public void NextTab()
    {
        ChangeTab(1);
        FillPages();
    }

    public void PrevTab()
    {
        ChangeTab(-1);
        FillPages();
    }

    private void ChangeTab(int tabCount)
    {
        _currentTab += tabCount;

        if (_currentTab < 0)
            _currentTab = 0;
        if (_currentTab > _unlockedPages / 2 + 1)
            _currentTab = _unlockedPages / 2 + 1;
    }

    private void FillPages()
    {
        int numPage = _currentTab * 2;
        FillPage(_textField1, numPage);
        FillPage(_textField2, numPage + 1);
        _audio.Play();
    }

    private void FillPage(TMP_Text _textField, int numPage)
    {
        _textField.text = "";
        if (numPage < _unlockedPages) _textField.text = _pages[numPage].Text;
    }

}

