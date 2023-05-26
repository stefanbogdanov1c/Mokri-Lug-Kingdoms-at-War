using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public TMP_InputField inputObject1;
    public TMP_InputField inputObject2;
    public Button button;

    void Start()
    {
        inputObject1.onValueChanged.AddListener(OnInputValueChanged);
        inputObject2.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newValue)
    {
        UpdateButtonVisibility();
    }

    private void UpdateButtonVisibility()
    {
        bool isInput1Empty = string.IsNullOrEmpty(inputObject1.text);
        bool isInput2Empty = string.IsNullOrEmpty(inputObject2.text);

        bool newButtonVisible = !isInput1Empty || !isInput2Empty;

        if (newButtonVisible==true)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }
}
