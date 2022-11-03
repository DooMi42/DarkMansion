using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public Item item;
    float cooldownTime;
    float activeTime;
    public int itemId;

    public GameObject mine;

    public GameObject player;

    public GameObject pelletPrefab;
    public ParticleSystem potionDrink;
    public GameObject cooldown;


    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ItemChooser();
                    state = AbilityState.active;
                    activeTime = item.activeTime;

                    
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    Debug.Log("Ability state active");
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Ability state active");
                    state = AbilityState.cooldown;
                    cooldownTime = item.cooldown;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    Debug.Log("Ability state cooldown");
                    cooldownTime -= Time.deltaTime;
                    cooldown.SetActive(true);
                }
                else
                {
                    Debug.Log("Ability state cooldown");
                    state = AbilityState.ready;
                }
                break;
        }
        if (Inventory.Instance.items.Count > 0)
        {
            item = Inventory.Instance.items[0];
        }

        if (cooldownTime > 0 && Inventory.Instance.hasEquipped == true)
        {
            cooldown.SetActive(true);
        }
        else
        {
            cooldown.SetActive(false);
        }
    }

    enum AbilityState
    {
        ready,
        active,
        cooldown,
    }

    

    AbilityState state = AbilityState.ready;

    public void ItemChooser()
    {
        itemId = item.id;
        switch (itemId)
        {
            case 0:
                HealthPotion();
                Debug.Log("Case 0 aktivoitu");
                break;
            case 1:
                Mine();
                break;
            case 2:
                Shotgun();
                break;
        }
    }

    public void HealthPotion()
    {
        for (int i = 0; i < item.power; i++)
        {
            Debug.Log("Healthpotion metodi aktivoitu");
            potionDrink.Play();
            Health.instance.PlayerHealed();
        }
    }

    public void Mine()
    {
        Debug.Log("Miina!");
        Instantiate(mine, player.transform.position, player.transform.rotation);
    }

    public void Shotgun()
    {
        Debug.Log("Ampui");
        Instantiate(pelletPrefab, player.transform.position, player.transform.rotation * Quaternion.Euler(0, 0, 10));
        Instantiate(pelletPrefab, player.transform.position, player.transform.rotation * Quaternion.Euler(0, 0, 5));
        Instantiate(pelletPrefab, player.transform.position, player.transform.rotation * Quaternion.Euler(0, 0, 0));
        Instantiate(pelletPrefab, player.transform.position, player.transform.rotation * Quaternion.Euler(0, 0, -5));
        Instantiate(pelletPrefab, player.transform.position, player.transform.rotation * Quaternion.Euler(0, 0, -10));

    }
}