using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food_", menuName = "Item/Food", order = 2)]
public class FoodItem : ScriptableObject
{
    public float Food => _food;
    public float Water => _water;
    public float Toilet => _toilet;
    public float Health => _health;
    public float Sleep => _sleep;

    [SerializeField] private float _food;
    [SerializeField] private float _water;
    [SerializeField] private float _toilet;
    [SerializeField] private float _health;
    [SerializeField] private float _sleep;
}
