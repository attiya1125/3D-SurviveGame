using System;
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

[Serializable] // Ŭ������ ����ȭ �ǰ� �����ִ°�?
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

    [Header("Equip")]
    public GameObject equipPrefabs;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
