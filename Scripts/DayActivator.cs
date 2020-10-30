using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayActivator : MonoBehaviour
{
    [SerializeField] private int _currentDay = 1;
    [SerializeField] private List<Day> _days;
    [SerializeField] private Journal _journal;

    public void ActivateNextDay()
    {
        _currentDay++;
        if (_currentDay < _days.Count && _days[_currentDay] != null)
        {
            _days[_currentDay].ActivateDay();
            _days[_currentDay].UnlockPages(_journal);
        }

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            ActivateNextDay();
        }
    }//*/
}
