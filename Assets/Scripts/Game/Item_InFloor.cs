using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_InFloor : MonoBehaviour
{
    public Item_Scriptable item;

    [Header("Referencia dos componentes")]
    [SerializeField] Image icon;
    [SerializeField] Transform positionObject;

    private void Start()
    {
        SetValueInItem();
    }

    private void SetValueInItem()
    {
        if (item != null)
        {
            icon.sprite = item.Icon;
            if (positionObject.childCount == 0)
            {
                GameObject refObject = Instantiate(item.refItemObject, positionObject.position, positionObject.rotation, positionObject);
            }
        }
    }
}
