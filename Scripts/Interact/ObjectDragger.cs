using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : ItemInteractor
{
    private float _distance = 1.3f;
    private Rigidbody _dragingObject;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public override void Interact(RaycastHit hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.transform != null && hit.transform.TryGetComponent(out DragedObject dragedObject))
            {
                _dragingObject = dragedObject.GetComponent<Rigidbody>();
                //_distance = Vector3.Distance(transform.position, dragedObject.transform.position);
            }
        }
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            _dragingObject = null;
        }

        if (_dragingObject)
        {
            if (_dragingObject.mass == 100) // жуткий костыль
            {
                _dragingObject = null; 
                return;
            }
            _dragingObject.angularVelocity = Vector3.zero;
            _dragingObject.velocity = (-_dragingObject.transform.position + ray.GetPoint(_distance)) * 10f;

        }
    }


}
