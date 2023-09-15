using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellInventory : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text countIntTxt;
    public TMP_Text weightTxt;

    public GameObject infoBuff;
    public TMP_Text infoBuffTxt;

    public GameObject btn_Equip;
    public GameObject btn_Use;

    public Button btn_Info;
    public Item_Scriptable item_Scriptable { get; private set; }

    public int ID_Reference;
    public float weightInt;
    public int countInt;
    public void SetValue(Item_Scriptable item)
    {
        item_Scriptable = item;
        itemImage.sprite = item.Icon;
        itemName.text = item.Name;
        weightTxt.text = item.Weight.ToString();

        weightInt = item.Weight;
        ID_Reference = item.ID;
        infoBuffTxt.text = item.DescriptionBuff;

        if (item.type.ToString() == "Equip")
        {
            btn_Equip.SetActive(true);
        }
        else
        {
            btn_Use.SetActive(true);
        }
    }

    public void ActiveBuffInfo()
    {
        infoBuff.SetActive(true);
    }

    public void DeactivateBuffInfo() 
    {
        infoBuff.SetActive(false);
    }

    public void AddItem(Item_Scriptable item)
    {
        countInt++;
        countIntTxt.text = countInt.ToString();
        weightInt += item.Weight;
        weightTxt.text = weightInt.ToString();
    }

    public void RemoveItem(Item_Scriptable item)
    {
        countInt--;
        countIntTxt.text = countInt.ToString();
        weightInt += item.Weight;
        weightTxt.text = weightInt.ToString();
    }
}
