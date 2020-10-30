using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivatorByTime : ItemProducter
{
    // Убрать дублирвоание и повторы
    [SerializeField] private GameObject _needActivate;

    public override void Producting()
    {
        _lastTime += Time.deltaTime;
        if (_productTime <= _lastTime)
        {
            _needActivate.SetActive(true);
            _lastTime = 0;
        }
        if (_audio.isPlaying == false)
            _audio.Play();
    }




}
