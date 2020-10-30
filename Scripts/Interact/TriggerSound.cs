using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audios;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _chance = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (Random.Range(0, 100) > _chance)
            return;
        if (_audios.Count > 0)
            _audioSource.PlayOneShot(_audios[Random.Range(0, _audios.Count)]);
    }
}
