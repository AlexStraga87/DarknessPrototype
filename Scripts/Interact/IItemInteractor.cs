using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInteractor : MonoBehaviour 
{
    public abstract void Interact(RaycastHit hit);
}
