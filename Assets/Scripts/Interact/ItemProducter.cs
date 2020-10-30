using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemProducter : MonoBehaviour
{
    [SerializeField] protected float _productTime;
    [SerializeField] protected float _lastTime;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] protected AudioSource _audio;
    //Уфф..

    public virtual void Producting()
    {
        _lastTime += Time.deltaTime;
        if (_productTime <= _lastTime)
        {
            Instantiate(_template, _spawnPoint.transform.position, _template.transform.rotation);
            _lastTime = 0;
        }
        if (_audio.isPlaying == false)
            _audio.Play();
    }

    public void ResetTime()
    {
        _lastTime = 0;
        _audio.Stop();
    }

    public float LeftTimeNormalize()
    {
        return _lastTime / _productTime;
    }


}
