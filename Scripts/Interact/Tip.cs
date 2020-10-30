using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    public string TipText => _tipText;
    [TextArea(2,10)]
    [SerializeField] private string _tipText;
}
