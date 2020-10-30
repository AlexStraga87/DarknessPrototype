using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public Item CurrentItem => _item;
    [SerializeField] private Item _item;
}
