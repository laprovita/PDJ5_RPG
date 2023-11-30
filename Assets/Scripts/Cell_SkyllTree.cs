using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell_SkyllTree : MonoBehaviour
{
    public bool locked = false;
    public List<Cell_SkyllTree> List_Prior_Cell_ST;
    [SerializeField] private Image lockedImage;
    [SerializeField] private SkyllTree_Manager skillTree_Manager;


    public Image colorImage;
    [SerializeField] int levelSkill;
    public void UpSkillButton()
    {

        if (skillTree_Manager.skillPoints >= 1)
        {
            if (List_Prior_Cell_ST[0] != null)
            {
                foreach (Cell_SkyllTree valu in List_Prior_Cell_ST)
                {
                    if (valu.locked)
                    {
                        Upgrade();
                        break;
                    }
                }
            
            }
            else
            {
                Debug.Log("Celula Inicial");
                Upgrade();
            }
        }

    }

    private void Upgrade()
    {
        locked = true;
        lockedImage.gameObject.SetActive(!locked);
        skillTree_Manager.SetColor(this, levelSkill);
        skillTree_Manager.SubSkillPoints(1);
    }

    public void SetThisSkill()
    {
        skillTree_Manager.SetColor(this, levelSkill);
    }
}
