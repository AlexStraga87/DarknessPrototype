using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconResource : MonoBehaviour
{
    [SerializeField] private PlayerParameter _parameter;
    [SerializeField] private Image _icon;
    [SerializeField] private Gradient _colorValue;

    private void OnEnable()
    {
        _parameter.ResourceChange += OnChangeValue;
    }

    private void OnDisable()
    {
        _parameter.ResourceChange -= OnChangeValue;
    }

    private void OnChangeValue(float value)
    {
        _icon.color = _colorValue.Evaluate(value / 100);
    }
}
