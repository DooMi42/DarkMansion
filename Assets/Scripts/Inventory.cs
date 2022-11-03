using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Instance
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instanceof inventory found!");
            return;
        }
        Instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

    public List<GameObject> lastObject = new List<GameObject>();

    public int space = 1;

    public GameObject equippedActiveItem = null;

    public GameObject lastEquipment = null;

    public GameObject player;

    private int i;
    public bool hasEquipped = false;


    public void Add (Item item)
    {
        if (item.isActiveItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Itemit vaihdettu");
                lastObject.Add(equippedActiveItem);
                items.Remove(items[0]);
                items.Add(item);
                SwitchItem();
                return ;
            }
            hasEquipped = true;
            items.Add(item);
            lastObject.Add(equippedActiveItem);
        }
        
    }

    public void Remove(Item item)
    {
        items.Remove (item);
    }

    public void SwitchItem()
    {
        if (items.Count >= space)
        {
            lastObject[i].transform.position = player.transform.position;
            lastObject[i].SetActive(true);
            i++;
        }
        
    }

}
