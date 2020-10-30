using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : ItemInteractor
{
    [SerializeField] private GameObject _needMakeActive;

    public override void Interact(RaycastHit hit)
    {
        if (Input.GetKey(KeyCode.E))
            if (hit.transform != null && hit.transform.TryGetComponent(out Activator activator) && activator == this)
                _needMakeActive.SetActive(true);
    }


}
