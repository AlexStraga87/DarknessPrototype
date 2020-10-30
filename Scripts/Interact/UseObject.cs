using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseObject : ItemInteractor
{
    [SerializeField] private Image _progress;
    private Camera _camera;
    private ItemProducter _producter;

    public override void Interact(RaycastHit hit)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (hit.transform != null && hit.transform.TryGetComponent(out ItemProducter itemProducter))
            {
                if (_producter != itemProducter)
                {
                    ResetProduction();
                    _producter = itemProducter;
                }
            } 
            else
            {
                ResetProduction();
            }
            if (_producter)
            {
                _producter.Producting();
                _progress.fillAmount = _producter.LeftTimeNormalize();
            }
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            ResetProduction();
        }
    }

    private void ResetProduction()
    {
        if (_producter)
            _producter.ResetTime();
        _producter = null;
        _progress.fillAmount = 0;
    }
  
}
