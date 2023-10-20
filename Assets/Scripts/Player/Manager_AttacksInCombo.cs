using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_AttacksInCombo : MonoBehaviour
{
    [SerializeField] ComboManager comboManager;
    [SerializeField] List<int> listOfAttacks;
    [SerializeField] List<Attack_Base_Scriptable> listOfAttack;
    
    [SerializeField] GameObject cellSlot_Default;
    [SerializeField] Transform content;
    Button reasda;
    [SerializeField] int countSlots;
    public void AddSkill(Attack_Base_Scriptable attack_Base)
    {

    }

    public void RemoveSkill() 
    { 
    
    }

    public void AddSlotSkill()
    {
        if (countSlots < 6)
        {
            TMP_InputField refButton = Instantiate(cellSlot_Default, content).GetComponentInChildren<TMP_InputField>();
            refButton.onValueChanged.AddListener(delegate { SetMyAttacksInComboManager(); });
            countSlots++;
        }
    }
    
    public void RemoveSlotSkill()
    {
        countSlots--;
        Destroy(content.GetChild(countSlots).gameObject);
    }

    public void SetMyAttacksInComboManager()
    {
        Debug.Log("Add mais um item ao combo.");
        
        
        for(int x = 0; x < countSlots; x++)
        {
            comboManager.attackBase_Scriptable[x] = listOfAttack[int.Parse(content.GetChild(x).GetComponentInChildren<TMP_InputField>().text.ToString())];
            //comboManager.attackBase_Scriptable[x] = Convert.ToInt32(content.GetChild(x).GetComponentInChildren<TMP_InputField>().text.ToString());
        }
    }
}
