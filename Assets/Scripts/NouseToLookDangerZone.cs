using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NouseToLookDangerZone : ItemInteractor
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _increaseVolume;
    private sbyte volumeSing = -1;

    public override void Interact(RaycastHit hit)
    {
        if (hit.transform != null && hit.transform.TryGetComponent(out DangerZone dangerZone))
        {
            if (dangerZone.IsActive)
                volumeSing = 1;
        }
        else
        {
            volumeSing = -1;
        }                
    }

    private void Update()
    {
        ChangeVolumeOn(_increaseVolume * volumeSing * Time.deltaTime);
    }

    private void ChangeVolumeOn(float value)
    {
        _audio.volume += value;
        if (_audio.volume < _minVolume)
            _audio.volume = _minVolume;
        if (_audio.volume > _maxVolume)
            _audio.volume = _maxVolume;
    }
}
