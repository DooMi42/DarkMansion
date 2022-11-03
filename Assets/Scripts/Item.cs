using System.ComponentModel.Design;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Active Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isActiveItem = true;
    public int cooldown;
    public int activeTime;
    public int power;
    public int id;
}
