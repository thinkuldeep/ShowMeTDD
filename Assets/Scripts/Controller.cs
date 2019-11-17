using System;
using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEditor.Experimental.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] private InputField FieldA;
    [SerializeField] private InputField FieldB;
    [SerializeField] private Text Result;
    private IService _service;

    private void Start()
    {
        _service = new CalculatorService();
    }

    public void ButtonClickHandler()
    {
        int a, b;
        Int32.TryParse(FieldA.text, out a);
        Int32.TryParse(FieldB.text, out b);
        Result.text = _service.Sum(a, b).ToString();
    }
}
