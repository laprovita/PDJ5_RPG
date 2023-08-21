using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class IntListContainer
{
    public List<string> stringDialogue;
    public List<int> indexAvatar;
}

public class SimpleDialogueSystem : MonoBehaviour
{

    [Header("Referencia dos componentes")]
    [SerializeField] TextMeshProUGUI text_Dialogue;
    [SerializeField] Image avatarDialogue;
    [SerializeField] GameObject canvas;

    [Header("Variaveis do sistema")]
    [SerializeField] List<IntListContainer> dialogueLinesList = new List<IntListContainer>();
    [SerializeField] List<Sprite> avatarList;

    private int indexLine;
    private int indexDialogue;

    void OnEnable()
    {
        StartDialogue();
    }

    void StartDialogue()
    {
        indexLine = 0;
        text_Dialogue.text = "";
        StartCoroutine(ConstructLine());
    }

    void NextLine()
    {
        if(indexLine < dialogueLinesList[indexDialogue].stringDialogue.Count -1)
        {
            indexLine++;
            text_Dialogue.text = string.Empty;
            StartCoroutine(ConstructLine());
        }

        else
        {
            indexDialogue++;
            canvas.SetActive(false);
            //Setar os próximos passos caso precise.
        }
    }


    public void CompleteDialogue()
    {
        if(text_Dialogue.text == dialogueLinesList[indexDialogue].stringDialogue[indexLine])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            text_Dialogue.text = "";
            text_Dialogue.text = dialogueLinesList[indexDialogue].stringDialogue[indexLine];
        }
    }


    IEnumerator ConstructLine()
    {
        avatarDialogue.sprite = avatarList[dialogueLinesList[indexDialogue].indexAvatar[indexLine]];
        foreach(char c in dialogueLinesList[indexDialogue].stringDialogue[indexLine].ToCharArray())
        {
            text_Dialogue.text += c;
            yield return new WaitForSecondsRealtime(0.02f);
        }
    }


}
