using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
   internal static Action OnBackButtonWasClicked;
    public void BackButtonClick()
    {
        OnBackButtonWasClicked();
    }
}
