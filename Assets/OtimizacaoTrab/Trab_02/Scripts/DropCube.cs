using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropCube : MonoBehaviour
{
    [Header("Variaveis de Movimentacao")]
    public float speedMovement;
    public float maxDistance;
    public int controllerDirection = 1;

    [Header("Variaveis dos cubos")]
    public Material baseMaterial;

    [Header ("Piscina")]
    public GameObject cubePrefab;
    public int poolSize = 10;
    public Transform aim;

    private List<GameObject> objectPool = new List<GameObject>();


    #region Metodos Privados
    private void Movement()
    {
        if(transform.position.x < -maxDistance)
        {
            controllerDirection = 1;
        }
        else if (transform.position.x > maxDistance)
        {
            controllerDirection = -1;
        }

        transform.Translate(controllerDirection * speedMovement * Time.deltaTime, 0, 0);
    }

    private void CreatePool()// Preencha a piscina com objetos do prefab;
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(cubePrefab);
            newObj.SetActive(false);
            objectPool.Add(newObj);
        }
    }

    private GameObject GetObjectFromPool()// Procura um objeto inativo na piscina e retorna.
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeSelf)
            {
                obj.transform.position = transform.Find("Aim").position;
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(cubePrefab);// Se n�o houver objetos inativos, crie um novo
        objectPool.Add(newObj);
        return newObj;
    }

    #endregion

    #region Chamadas
    private void Update()
    { 
        Movement();
    }

    private void Start()
    {
        CreatePool();
        StartCoroutine(ActivateCubes());
    }
    #endregion

    IEnumerator ActivateCubes()
    {
        float cooldown = Random.Range(3, 8);
        yield return new WaitForSeconds(cooldown);

        GameObject refObject = GetObjectFromPool();
        Debug.Log("Objeto ativo: " + refObject.name);

        StartCoroutine(ActivateCubes());
    }
}
