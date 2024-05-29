using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // ä�� ������ �������� ����
{
    Equipable,
    Resource,
    Consumable
}

public enum ConsumableType // ���� �� �ִ� ������ Ÿ��
{
    Health,
    Hunger
}

[SerializeField]
public class ItemDataConsumable
{
    public ConsumableType consumableType;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrfab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStack;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefabs;
}
