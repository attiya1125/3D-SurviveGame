using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType // 채집 가능한 아이템의 종류
{
    Equipable,
    Resource,
    Consumable
}

public enum ConsumableType // 먹을 수 있는 아이템 타입
{
    Health,
    Hunger
}

[Serializable] // 클래스를 직렬화 되게 보여주는것?
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
    public string interaction;

    [Header("Stacking")]
    public bool canStack;
    public int maxStack;

    [Header("Equip")]
    public GameObject equipPrefabs;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
