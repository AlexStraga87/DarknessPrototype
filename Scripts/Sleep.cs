using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Sleep : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private FirstPersonController _controller;
    [SerializeField] private DayActivator _dayActivator;
    [SerializeField] private FoodItem _sleep;
    [SerializeField] private ItemUser _itemUser;

    private void OnEnable()
    {
        StartCoroutine(Sleeping());
    }

    private IEnumerator Sleeping()
    {
        _controller.enabled = false;
        Color color = _image.color;
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        for (int i = 0; i < 20; i++)
        {
            color.a = i * 0.05f;
            _image.color = color;
            yield return wait;
        }
        _dayActivator.ActivateNextDay();
        yield return new WaitForSeconds(1f);
        _itemUser.UseItem(_sleep);

        for (int i = 0; i < 20; i++)
        {
            color.a = 1 - i * 0.05f;
            _image.color = color;
            yield return wait;
        }
        _controller.enabled = true;       
        gameObject.SetActive(false);
    }
}
