using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionTag : MonoBehaviour
{
    public string s;

    public void OptionPressed()
    {
        GetComponentInParent<DDLSearch>().OptionSelected(s);
    }

    public void SetColor(Color color)
    {
        this.GetComponent<Image>().color = color;
    }
}
