using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipShower : ItemInteractor
{
    [SerializeField] private TMP_Text _textField;

    public override void Interact(RaycastHit hit)
    {
        _textField.text = "";
        if (hit.transform != null && hit.transform.TryGetComponent(out Tip tip))
        {
            _textField.text = tip.TipText;
        }
    }

}
