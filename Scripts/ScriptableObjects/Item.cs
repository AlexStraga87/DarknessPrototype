using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Item/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private string _Name;
}
