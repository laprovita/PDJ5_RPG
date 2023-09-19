using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    [Header("Inventário e Listas")]
    public List<Item_Scriptable> inventory;
    [SerializeField] private List<int> idList;
    [SerializeField] private List<CellInventory> cellList;

    public List<Item_Scriptable> allItens;

    [Header("Referencias")]
    [SerializeField] CellInventory baseCell;
    [SerializeField] Transform contentInventory;
    [SerializeField] GameObject panel_Inventory;
    [SerializeField] Status_Player status_Player;


    [SerializeField] private TMP_Text txt_Info;

    Item_Scriptable itemRef;

    public void SetNewNameForItem(Item_Scriptable item)
    {
        itemRef = item;
    }

    public void GetItemReference(string name)
    {
        itemRef.ItemName = name;
    }

    public void AddItem(Item_Scriptable item)
    {
        if (item != null) //Verifica se esta add um item vázio a lista (envelope de proteção);
        { 
            if (!inventory.Contains(item)) //Verifica se a lista NÃO possui um item igual a esse;
            {
                AddVisualItemInInventory(item);
            }

            else //Caso a lista JÁ POSSUA um item igual a esse;
            {
                AddCountInExistingItem(item);
            }
            allItens.Add(item);
            status_Player.WeightCalculate();
        }
    }

    private void AddVisualItemInInventory(Item_Scriptable item)
    {
        inventory.Add(item);

        CellInventory refCell = Instantiate(baseCell, contentInventory).GetComponent<CellInventory>();
        refCell.SetValue(item);
        refCell.btn_Info.onClick.AddListener(() => { this.SetItemInformation(item); });

        cellList.Add(refCell);
        idList.Add(item.ID);
    }
    private void AddCountInExistingItem(Item_Scriptable item)
    {
        foreach (CellInventory cell in cellList)
        {
            if (cell.ID_Reference == item.ID)
            {
                cell.AddItem(item);
                break;
            }
        }
    }


    public void RemoveItem(Item_Scriptable item)
    {
        if (item != null) //Verifico se estou tentando remover um item vázio da minha lista (envelope de proteção);
        {
            if (idList.Contains(item.ID)) //Verifico se a minha lista de IDs possue essa ID;
            {
                int count = 0;

                foreach (CellInventory cell in cellList) //Verificar quantos elementos desse item eu possuo;
                {
                    if (cell.ID_Reference == item.ID)
                    {
                        count++;

                        if (count > 1)
                        {
                            RemoveCountInExistingItem(item, cell);//Remoção unitária do item no inventário;
                            break;
                        }

                        else
                        {
                            RemoveItemFromInventory(item, cell);//Remoção unitária do item no inventário;
                        }

                    }
                }
            }
            allItens.Remove(item);
            status_Player.WeightCalculate();
        }
    }

    private void RemoveItemFromInventory(Item_Scriptable item, CellInventory cell)
    {
        inventory.Remove(item);
        cellList.Remove(cell);
        idList.Remove(item.ID);
        Destroy(cell.gameObject);
    }
    private void RemoveCountInExistingItem(Item_Scriptable item, CellInventory cell)
    {
        cell.RemoveItem(item);
    }


    private void ConstructInventory()
    {
        foreach (Item_Scriptable item in inventory)
        {

            if (!idList.Contains(item.ID)) //A lista não possui um ID desse item;
            {
                CellInventory refCell = Instantiate(baseCell, contentInventory).GetComponent<CellInventory>();
                refCell.SetValue(item);
                refCell.btn_Info.onClick.AddListener(() => { this.SetItemInformation(item); });
                idList.Add(item.ID);
                cellList.Add(refCell);
                
            }

            else //A lista já possui um ID desse item;
            {
                foreach (CellInventory cell in cellList)
                {
                    if (cell.ID_Reference == item.ID)
                    {
                        cell.AddItem(item);
                    }
                }
            }
        }
        status_Player.WeightCalculate();
    }


    public void SetItemInformation(Item_Scriptable item)
    {
        Debug.Log("Setando as informações do item:" + item.name);
        txt_Info.text = item.Description;
    }

    private void Start()
    {
        ConstructInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel_Inventory.SetActive(!panel_Inventory.activeSelf);
        }
    }
}
