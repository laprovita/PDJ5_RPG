using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Cannon : MonoBehaviour
{
    [Header("Movemento")]
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance = 2.5f;

    [Header("Canhao")]
    [SerializeField] GameObject cannonBall;
    [SerializeField] Transform aim;

    [Header("Feedbacks")]
    [SerializeField] ParticleSystem particle;


    #region Metodos Privados
    private void Movement() //Metodo utilizado para movimentar o carrinho do canhão no eixo X.
    {
        float x = Input.GetAxis("Horizontal"); //Recebe o Input.

        if (transform.position.x < -maxDistance) //Valida o limite de posição do player.
        {
            transform.position = new Vector3(maxDistance,transform.position.y, transform.position.z);
        }

        else if (transform.position.x > maxDistance)
        {
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        }

        transform.GetComponent<Rigidbody>().velocity=new Vector3(x * maxSpeed, 0,0) * Time.fixedDeltaTime; //Adiciona o movimento ao corpo rigido do player.
    }

    private void Shoot() //Metodo utilizado para instanciar os projeteis que sao disparados pelo jogador.
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject refGameObject = Instantiate(cannonBall, aim.position, aim.rotation);
            refGameObject.GetComponent<ProjetilCannon>().enabled = true;
            Instantiate(particle, aim.position, aim.rotation);
            SwapMaterial(refGameObject);
        }
    }

    private void SwapMaterial(GameObject refGameObject) //Metodo para mudar as cores dos projeteis.
    {
        Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        int color = Random.Range(0, 5);

        switch(color){
            case 0:
                material.color = Color.black;
                break;

            case 1:
                material.color = Color.blue;
                break;

            case 2:
                material.color = Color.red;
                break;

        }

        Material[] newListMaterials = new Material[6];

        refGameObject.GetComponent<MeshRenderer>().materials = newListMaterials;
        refGameObject.GetComponent<MeshRenderer>().materials[0] = material;
        refGameObject.GetComponent<MeshRenderer>().material = material;
    }
    #endregion

    #region Chamadas

    private void Update()
    {
        Movement();
        Shoot();
    }

    #endregion
}
