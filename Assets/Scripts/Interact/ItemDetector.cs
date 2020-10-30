using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    [SerializeField] private List<ItemInteractor> _interactors;
    private Camera _camera;  

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        /*if (Physics.Raycast(ray, out hit, 3))
        {
            for (int i = 0; i < _interactors.Count; i++)
            {
                _interactors[i].Interact(hit);
            } 
        }*/
        Physics.Raycast(ray, out hit, 5);
        for (int i = 0; i < _interactors.Count; i++)
        {
            _interactors[i].Interact(hit);
        }
    }
}
