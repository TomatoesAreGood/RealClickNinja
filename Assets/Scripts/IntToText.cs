using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntToText : MonoBehaviour
{
    public TextMeshProUGUI textValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(int num)
    {
        textValue.text = num.ToString();

    }

    // Update is called once per frame
    public void Update()
    {
    }
}
