using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _currentIndex;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(AnomalyController.Instance.WinIndex == _currentIndex)
        {
            AnomalyController.Instance.IsWin = true;
            AnomalyController.Instance.WinText.enabled = true;
        }
    }
}
