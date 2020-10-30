using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private PlayerParameter _health;
    [SerializeField] private List<PlayerParameter> _parameters;
    [SerializeField] private GameOver _gameOver;

    public void TakeDamage(float value)
    {
        _health.ChangeValue(-value);
        if (_health.Value <= 0)
            _gameOver.ShowGameOver();
    }

    private void OnEnable()
    {
        foreach (var parameter in _parameters)
        {
            parameter.ResourceChange += OnChangeValue;
        }
        
    }

    private void OnDisable()
    {
        foreach (var parameter in _parameters)
        {
            parameter.ResourceChange += OnChangeValue;
        }
    }

    private void OnChangeValue(float value)
    {
        if (value < 0)
        {
            TakeDamage(-value);
        }
    }
}

