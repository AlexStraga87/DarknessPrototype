using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public bool IsActive { private set; get; }
    [SerializeField] private List<GameObjectActivationNotifier> _lightNotifiers;
    [SerializeField] private float _damage = 1;
    private List<bool> _lightActivated = new List<bool>();

    private void Awake()
    {
        for (int i = 0; i < _lightNotifiers.Count; i++)
        {
            _lightActivated.Add(false);
        }
    }

    private void OnEnable()
    {
        foreach (var lightNotifier in _lightNotifiers)
        {
            lightNotifier.ActiveChanged += OnActivationNotifierChanged;
        }
        CheckActive();
    }

    private void OnDisable()
    {
        foreach (var lightNotifier in _lightNotifiers)
        {
            lightNotifier.ActiveChanged -= OnActivationNotifierChanged;
        }
    }

    private void CheckActive()
    {
        IsActive = true;
        foreach (var lightNotifier in _lightNotifiers)
        {
            OnActivationNotifierChanged(lightNotifier, lightNotifier.gameObject.activeSelf);
        }
    }

    private void OnActivationNotifierChanged(GameObjectActivationNotifier notifier, bool isActive)
    {
        for (int i = 0; i < _lightNotifiers.Count; i++)
        {
            if (_lightNotifiers[i] == notifier)
            {
                _lightActivated[i] = isActive;
                break;
            }
        }

        IsActive = true;
        for (int i = 0; i < _lightActivated.Count; i++)
        {
            if (_lightActivated[i] == true)
            {
                IsActive = false;
                break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsActive)
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage * Time.deltaTime);
        }
    }


}
