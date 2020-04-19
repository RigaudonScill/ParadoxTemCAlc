using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTag : MonoBehaviour
{
    public string s;

    public void OptionPressed()
    {
        GetComponentInParent<DDLSearch>().OptionSelected(s);
    }
}
