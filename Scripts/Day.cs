using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day: MonoBehaviour
{
    [SerializeField] private List<GameObject> _disablingGameObjects;
    [SerializeField] private List<MonoBehaviour> _disablingScripts;
    [SerializeField] private List<GameObject> _activatingGameObjects;
    [SerializeField] private List<MonoBehaviour> _activatingScripts;
    [SerializeField] private int _unlockPages;

    public void ActivateDay()
    {
        foreach (var go in _disablingGameObjects)
        {
            go.SetActive(false);
        }

        foreach (var script in _disablingScripts)
        {
            script.enabled = false;
        }

        foreach (var go in _activatingGameObjects)
        {
            go.SetActive(true);
        }

        foreach (var script in _activatingScripts)
        {
            script.enabled = true;
        }
    }

    public void UnlockPages(Journal journal)
    {
        journal.UnlockPages(_unlockPages);
    }
}
