using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisactivateByTime : MonoBehaviour
{
    [SerializeField] private float _time;

    private void OnEnable()
    {
        StartCoroutine(Disactivate());
    }

    private IEnumerator Disactivate()
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
    }
}
