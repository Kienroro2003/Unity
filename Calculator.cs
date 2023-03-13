using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Calculator : MonoBehaviour
{ 
    public Text inputField;
    public void ButtonPressed()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        if (buttonValue.Equals("C"))
        {
            inputField.text = "";
        }
        else
        {
            inputField.text += buttonValue;
        }
    }
}
