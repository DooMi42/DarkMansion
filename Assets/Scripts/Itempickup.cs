using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itempickup : MonoBehaviour
{
    public bool triggerEntered = false;
    public Image itemIcon0;
    public GameObject lastItem;

    public Item item;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            Debug.Log("Picking " + item.name);
            Inventory.Instance.equippedActiveItem = gameObject;
            gameObject.SetActive(false);
            Inventory.Instance.Add(item);
            if(Inventory.Instance.items.Count >= Inventory.Instance.space)
            {
                lastItem = gameObject;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerEntered = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerEntered = false;
        }
    }


}


