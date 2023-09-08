using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [Header("Lista de Materials de Chapeuis")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] List<Material> ListaMateriaisDeChapeus;
    [SerializeField] int indexMaterialChapeuAtual;

    [Header("Lista de Materials e Texturas")]
    [SerializeField] List<Material> ListaMaterialsTexturas;
    [SerializeField] int indexMaterialAtual;

    [Header("Lista de Meshs")]
    [SerializeField] List<Mesh> ListaMesh;

    [Header("Lista de Mochilas (Instantiate)")]
    [SerializeField] List<GameObject> ListaDeMochilas_Instantiate;


    #region Private

    public void SetHat(int index)
    {
        indexMaterialAtual= indexMaterialAtual + index;

        if (indexMaterialAtual > ListaMateriaisDeChapeus.Count) // Condição que valida se nosso index de chapeus chegou ao limite MÁXIMO da lista de chapeus.
        {
            indexMaterialAtual = 0;
        }

        else if (indexMaterialAtual < 0) // Condição que valida se nosso index de chapeus chegou ao limite MÍNIMO da lista de chapeus.
        {
            indexMaterialAtual = ListaMateriaisDeChapeus.Count;
        }

        meshRenderer.material = ListaMateriaisDeChapeus[indexMaterialChapeuAtual]; //Seta o novo material selecionado.
    }

    #endregion

}
