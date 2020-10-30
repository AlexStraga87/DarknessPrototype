using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAfterSpawn : MonoBehaviour
{
    [SerializeField] private FoodItem _foodItem;

    private void Start()
    {
        //Костыли
        ItemUser itemUser = FindObjectOfType(typeof(ItemUser)) as ItemUser;
        itemUser.UseItem(_foodItem);
        Destroy(gameObject);
    }

}
