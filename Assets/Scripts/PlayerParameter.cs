using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerParameter : MonoBehaviour
{
    public float Value => _value;
    [SerializeField] private string _parameterName;
    [SerializeField] private float _decreaseByTime;
    private float _value = 100;
    public event UnityAction<float> ResourceChange;

    public void DecreaseValueByTime()
    {
        ChangeValue(-_decreaseByTime);
    }

    public void ChangeValue(float value)
    {
        _value += value;
        if (_value < -_decreaseByTime)
            _value = -_decreaseByTime;
        ResourceChange?.Invoke(_value);
        if (_value < 0) _value = 0;
        if (_value > 100) _value = 100;
    }

}
