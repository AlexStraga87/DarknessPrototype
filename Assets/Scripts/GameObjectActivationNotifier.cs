using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectActivationNotifier : MonoBehaviour
{
    public event UnityAction<GameObjectActivationNotifier, bool> ActiveChanged;

    private void OnEnable()
    {
        ActiveChanged?.Invoke(this, true);
    }

    private void OnDisable()
    {
        ActiveChanged?.Invoke(this, false);
    }
}
