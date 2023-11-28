using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class _LoadingBar : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text text_Porcent;

    [Header("Header")]
    [SerializeField] float time;
    [SerializeField] int count;
    [SerializeField] bool onOff = true;
    [SerializeField] TMP_Text time_txt;
    [SerializeField] TMP_Text count_txt;

    private IEnumerator LoadScene_LoadingBar(string scene)
    {
        yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            progressBar.value = Mathf.Clamp01(asyncLoad.progress / 0.9F) * 100;
            text_Porcent.text = Mathf.Clamp01(asyncLoad.progress / 0.9F) * 100 + "%";

            if (!onOff)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    asyncLoad.allowSceneActivation = true;
                    AsyncOperation asyncLoad_02 = SceneManager.LoadSceneAsync("Scene_02", LoadSceneMode.Additive);
                }

                time += Time.deltaTime;
                time_txt.text = time.ToString();
            }
            yield return null;
        }
    }

    public void StartScene(string scene)
    {
        StartCoroutine(LoadScene_LoadingBar(scene));
    }

    public void AddCount()
    {
        count++;
        count_txt.text = count.ToString();
    }

    private void Update()
    {
        if (!onOff)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                AddCount();
            }
        }
    }
}
