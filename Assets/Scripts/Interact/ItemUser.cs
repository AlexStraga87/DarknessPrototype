using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser : ItemInteractor
{
    [SerializeField] private PlayerParameter _health;
    [SerializeField] private PlayerParameter _food;
    [SerializeField] private PlayerParameter _water;
    [SerializeField] private PlayerParameter _toilet;
    [SerializeField] private PlayerParameter _sleep;

    public override void Interact(RaycastHit hit)
    {
        if (hit.transform != null && hit.transform.TryGetComponent(out UsableObject usableObject))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeParameters(usableObject.Item);
                Destroy(usableObject.gameObject);
            }
        }
    }

    public void UseItem(FoodItem foodItem)
    {
        ChangeParameters(foodItem);
    }

    private void ChangeParameters(FoodItem foodItem)
    {
        _health.ChangeValue(foodItem.Health);
        _food.ChangeValue(foodItem.Food);
        _water.ChangeValue(foodItem.Water);
        _toilet.ChangeValue(foodItem.Toilet);
        _sleep.ChangeValue(foodItem.Sleep);
    }
}
