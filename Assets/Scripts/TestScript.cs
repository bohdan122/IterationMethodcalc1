using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private string input;

    [SerializeField] InputField iField;

    public void ReadStringInput(string s) {
        
        input = s;

        Debug.Log(input);

    }
}
