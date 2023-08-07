using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] ToastType toastType;
    [SerializeField] Direction direction;
    [SerializeField] TMP_InputField input;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ThrowToast);
    }

    private void ThrowToast()
    {
        switch (toastType)
        {
            case ToastType.Small:
                Toastify.ThrowSmallToast(input.text, direction);
                break;
            case ToastType.Medium:
                Toastify.ThrowMediumToast(input.text, direction);
                break;
            case ToastType.Large:
                Toastify.ThrowLargeToast(input.text, direction);
                break;
        }
    }
}
