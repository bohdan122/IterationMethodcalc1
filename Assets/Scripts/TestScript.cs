using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private string input;

    [SerializeField] int location_x;
    [SerializeField] int location_y;

    [SerializeField] GameObject MainCamera;

    public void Send_number_to_cflculstor_pls_die(string s) {
        
        input = s;
        Calculator calc = MainCamera.GetComponent<Calculator>();
        calc.Getnumber(location_x, location_y, Double.Parse(s));

    }
}
