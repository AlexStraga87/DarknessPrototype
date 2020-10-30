using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page_", menuName = "JournalPage/JournalPage", order = 1)]
public class JournalPage : ScriptableObject
{
    public string Text => _text;
    [SerializeField]
    [TextArea(20, 30)] private string _text;

}
