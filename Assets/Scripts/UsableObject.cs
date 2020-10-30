using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObject : MonoBehaviour
{
    public FoodItem Item =>_item;
    [SerializeField] private FoodItem _item;

}
