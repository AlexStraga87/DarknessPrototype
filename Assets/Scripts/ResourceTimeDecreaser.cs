using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTimeDecreaser : MonoBehaviour
{
    [SerializeField] private float _tickTime = 5;
    [SerializeField] private List<PlayerParameter> _parameters;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(_tickTime);
        yield return wait;

        foreach (var parameter in _parameters)
        {
            parameter.DecreaseValueByTime();
        }

        StartCoroutine(Timer());
    }


}
