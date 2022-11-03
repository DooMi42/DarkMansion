using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    Money MoneyScript;

    [Header("UI")]
    public GameObject Canvas;
    public GameObject HealthImage;
    public GameObject ShopHelp;
    GameObject MoneyUI;

    [Header("Booleans")]
    public bool inShopMenu;
    bool item1 = false;
    bool inShop = false;

    [SerializeField] GameObject instantiatePos;

    [Header("Prefabs")]
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject mine;
    [SerializeField] GameObject healthPotion;
    [SerializeField] GameObject healthStim;

    void Awake()
    {
        MoneyUI = GameObject.FindGameObjectWithTag("UI");
        MoneyScript = MoneyUI.GetComponent<Money>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            ShopHelp.SetActive(true);
            inShop = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShopHelp.SetActive(false);
            inShop = false;
        }
    }

    void Update()
    {
        if (inShop && Input.GetKeyDown(KeyCode.Q)) {
            Cursor.visible = true;
            ShopHelp.SetActive(false);
            Canvas.SetActive(true);
            HealthImage.SetActive(false);
            inShopMenu = true;
        }

        if (Canvas && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitUI();
        }
    }
    public void ExitUI()
    {
        Canvas.SetActive(false);
        HealthImage.SetActive(true);
        Cursor.visible = false;
        inShopMenu = false;
    }


    public void Shotgun()
    {
        if (MoneyScript.money >= 10)
        {
            MoneyScript.money -= 10;
            Instantiate(shotgun, instantiatePos.transform.position, transform.rotation);
        }
    }

    public void Mine()
    {
        if (MoneyScript.money >= 8)
        {
            MoneyScript.money -= 8;
            Instantiate(mine, instantiatePos.transform.position, transform.rotation);

        }
    }

    public void HealthPotion()
    {
        if(MoneyScript.money >= 40)
        {
           MoneyScript.money -= 40;
           Instantiate(healthPotion, instantiatePos.transform.position, transform.rotation);
        }
    }

    public void HealthStim()
    {
        if(MoneyScript.money >= 50)
        {
            MoneyScript.money -= 50;
            Instantiate(healthStim, instantiatePos.transform.position, transform.rotation);
        }
    }
}
