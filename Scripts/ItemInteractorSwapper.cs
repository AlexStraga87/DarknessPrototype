using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractorSwapper : MonoBehaviour
{
    [SerializeField] private Item _needItem;
    [SerializeField] private GameObject _templateSwap;
    [SerializeField] private AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out ItemType item))
        {
            if (item.CurrentItem == _needItem)
            {
                if (_templateSwap != null) Instantiate(_templateSwap, transform.position, transform.rotation);
                transform.position = Vector3.back * 1000;
 
                if (_audio)
                {
                    _audio.Play();
                }
                Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                if (rigidbody)
                    rigidbody.mass = 100;
                Destroy(gameObject, 5);
            }
        }
    }
}
