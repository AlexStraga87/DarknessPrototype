using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTable : MonoBehaviour
{
    [SerializeField] private List<FoodItem> _items;
    [SerializeField] private GameObject _productTemplate;
    [SerializeField] private Transform _productSpawnPoint;
    [SerializeField] private AudioSource _audio;
    private List<bool> _itemsHave = new List<bool>();
    private bool _isBusy = false;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _itemsHave.Add(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isBusy)
            return;
        if (other.TryGetComponent(out UsableObject usableObject))
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i] == usableObject.Item)
                {
                    if (_itemsHave[i] == false)
                    {
                        _itemsHave[i] = true;
                        Destroy(usableObject.gameObject);
                        TryProduceProduct();
                    }
                }
            }
        }
    }

    private void TryProduceProduct()
    {
        bool isAllHave = true;
        foreach (var ishave in _itemsHave)
        {
            if (ishave == false)
            {
                isAllHave = false;
                break;
            }
        }
        if (isAllHave)
        {
            _isBusy = true;
            StartCoroutine(Cook());
        }
    }

    private IEnumerator Cook()
    {
        _audio.Play();
        yield return new WaitForSeconds(10);
        Instantiate(_productTemplate, _productSpawnPoint.transform.position, Quaternion.identity);
        for (int i = 0; i < _itemsHave.Count; i++)
        {
            _itemsHave[i] = false;
        }
        _isBusy = false;
        _audio.Stop();
    }
}
