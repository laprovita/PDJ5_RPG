using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SkyllTree_Manager : MonoBehaviour
{
    public int skillPoints;
    public TMP_Text txt_Count;
    public int currentSkill;

    public List<Cell_SkyllTree> listCell;
    public List<Color> listColor;

    public void AddSkillPoints(int value)
    {
        skillPoints += value;
        txt_Count.text = skillPoints.ToString();
    }

    public void SubSkillPoints(int value)
    {
        skillPoints -= value;
        txt_Count.text = skillPoints.ToString();
        currentSkill++;
    }

    public void SetColor(Cell_SkyllTree value, int level)
    {
        listCell[level] = value;
        listColor[level] = value.colorImage.color;
    }

}
