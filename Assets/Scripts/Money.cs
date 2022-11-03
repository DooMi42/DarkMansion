using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{

    public int money = 0;
    public TextMeshProUGUI teksti;

    void Update()
    {
        teksti.text = "" + money;
    }
}