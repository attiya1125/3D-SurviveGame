using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData itemData;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityTxt;
    private Outline outline;

    public UIInventory inventory;

    public GameObject optionUI;

    public int index;
    public bool equipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = itemData.icon;
        quantityTxt.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if(outline != null)
        {
            outline.enabled = equipped;
        }
    }

    public void Clear()
    {
        itemData = null;
        icon.gameObject.SetActive(false);
        quantityTxt.text = string.Empty;
    }

    public void OnClickBtn()
    {
        optionUI.SetActive(true);
        inventory.SelectItem(index);
    }
}
