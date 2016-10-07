using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public string Name;
    public string Description;
    public ItemType Type;

    public float Weight;
    public float Value;

    public enum ItemType
    {
        Weapon,
        Armor,
        Food,
        Potion,
        Misc,
        Quest
    }
}
