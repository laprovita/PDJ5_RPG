using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [Header("Lista de Materials de Chapeus")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] List<Material> ListaMateriaisDeChapeus;
    [SerializeField] int indexMaterialChapeuAtual;
    [SerializeField] TMP_Text index_Chapeu;

    [Header("Lista de Texturas")]
    [SerializeField] SkinnedMeshRenderer meshRenderer_Person;
    [SerializeField] List<Sprite> ListaTexturas;
    [SerializeField] int indexTexturaAtual;
    [SerializeField] TMP_Text index_Textura;

    [Header("Lista de Objetos (armars)")]
    [SerializeField] List<GameObject> ListaArmas;
    [SerializeField] int indexArmaAtual;
    [SerializeField] TMP_Text index_Arma;

    [Header("Lista de Meshs Escudo")]
    [SerializeField] MeshFilter meshFilterEscudo;
    [SerializeField] List<Mesh> ListaMeshsEscudo;
    [SerializeField] int indexEscudoAtual;
    [SerializeField] TMP_Text index_Escudo;


    [Header("Lista de Mochilas (Instantiate)")]
    [SerializeField] List<GameObject> ListaDeMochilas_Instantiate;
    [SerializeField] Transform position_Mochila;
    [SerializeField] int indexMochila;
    [SerializeField] TMP_Text index_Mochila;


    #region Private

    public void SetHat(int index)
    {
        indexMaterialChapeuAtual += index;

        if (indexMaterialChapeuAtual >= ListaMateriaisDeChapeus.Count) // Condição que valida se nosso index de chapeus chegou ao limite MÁXIMO da lista de chapeus.
        {
            indexMaterialChapeuAtual = 0;
        }

        else if (indexMaterialChapeuAtual < 0) // Condição que valida se nosso index de chapeus chegou ao limite MÍNIMO da lista de chapeus.
        {
            indexMaterialChapeuAtual = ListaMateriaisDeChapeus.Count -1;
        }

        meshRenderer.material = ListaMateriaisDeChapeus[indexMaterialChapeuAtual]; //Seta o novo material selecionado.
        index_Chapeu.text = indexMaterialChapeuAtual.ToString();
    }


    public void SetNewTexture(int index)
    {
        indexTexturaAtual += index;

        if (indexTexturaAtual >= ListaTexturas.Count) 
        {
            indexTexturaAtual = 0;
        }

        else if (indexTexturaAtual < 0)
        {
            indexTexturaAtual = ListaMateriaisDeChapeus.Count - 1;
        }


        meshRenderer_Person.materials[1].mainTexture = ListaTexturas[indexTexturaAtual].texture;
        index_Textura.text= indexTexturaAtual.ToString();
    }

    public void SetNewWeapon(int index)
    {
        ListaArmas[indexArmaAtual].SetActive(false);

        indexArmaAtual += index;

        if (indexArmaAtual >= ListaArmas.Count)
        {
            indexArmaAtual = 0;
        }

        else if (indexArmaAtual < 0)
        {
            indexArmaAtual = ListaArmas.Count - 1;
        }

        ListaArmas[indexArmaAtual].SetActive(true);
        index_Arma.text= indexArmaAtual.ToString();
    }

    public void SetNewMesh(int index)
    {
        indexEscudoAtual += index;

        if (indexEscudoAtual >= ListaMeshsEscudo.Count)
        {
            indexEscudoAtual = 0;
        }

        else if (indexEscudoAtual < 0)
        {
            indexEscudoAtual = ListaMeshsEscudo.Count - 1;
        }

        meshFilterEscudo.mesh = ListaMeshsEscudo[indexEscudoAtual];
        index_Escudo.text= indexEscudoAtual.ToString();
    }

    public void SetNewBackpack(int index)
    {
        indexMochila += index;

        if (indexMochila >= ListaDeMochilas_Instantiate.Count)
        {
            indexMochila = 0;
        }

        else if (indexMochila < 0)
        {
            indexMochila = ListaArmas.Count - 1;
        }

        if(position_Mochila.childCount > 0)
        {
            Destroy(position_Mochila.GetChild(0).gameObject);
            
        }
         
        GameObject refMochila = Instantiate(ListaDeMochilas_Instantiate[indexMochila], position_Mochila.position, position_Mochila.rotation, position_Mochila);
        index_Mochila.text = indexMochila.ToString();


    }
    #endregion

}
