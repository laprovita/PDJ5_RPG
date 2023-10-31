using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInAttackManager : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            Inventory_Item inventory_Item = eventData.pointerDrag.GetComponent<Inventory_Item>();
            inventory_Item.parentAfterDrag = transform;
        }
    }
}
