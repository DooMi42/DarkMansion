using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{

    public GameObject MoneyUI;
    public Money MoneyScript;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MoneyScript.money = MoneyScript.money + 1;
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        MoneyUI = GameObject.FindGameObjectWithTag("UI");
        MoneyScript = MoneyUI.GetComponent<Money>();
    }

    void Update()
    {
        
    }
}
