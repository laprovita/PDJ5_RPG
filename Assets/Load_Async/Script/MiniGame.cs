using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MiniGame : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] int count;
    [SerializeField] bool onOff = true;
    [SerializeField] TMP_Text time_txt;

    private IEnumerator CountIEnumerator()
    {
        yield return null;

        while (!onOff)
        {
            time += Time.deltaTime;
            time_txt.text = time.ToString();
            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(CountIEnumerator());
    }
}
