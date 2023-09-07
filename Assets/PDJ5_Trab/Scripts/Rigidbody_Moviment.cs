using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody_Moviment : MonoBehaviour
{
    [Header("Variaveis")]
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Vector3 direction;
    [SerializeField] float rotation;
    [SerializeField] float jumpPower;
    [SerializeField] bool wantsToJump;
    [SerializeField] bool wantsToRun;

    [Header("Componentes")]
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private LayerMask layerGround;

    private float currentSpeed;
    private void FixedUpdate()
    {
        CharacterMovement();
    }

    private void Update()
    {
        PlayerController();
    }

    private void PlayerController()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        rotation = Input.GetAxis("RotateKeyBoard");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1.2f, layerGround))
            {
                wantsToJump = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            wantsToRun = true;
        }
        else
        {
            wantsToRun = false;
            currentSpeed = moveSpeed;
        }

    }

    private void CharacterMovement()
    {
        if (wantsToJump)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.y);

            wantsToJump = !wantsToJump;
        }

        if (wantsToRun)
        {
            currentSpeed = runSpeed;
        }

        //Move o objeto para a posi��o indicada. Tamb�m tem problemas de colis�o pois ele seta a posi��o que o objeto dever ir. (Funciona melhor no 2D).
        //rigidbody.MovePosition(transform.TransformDirection(new Vector3(0, rigidbody.velocity.y) + direction.normalized * currentSpeed));

        //Seta a velocidade do corpo rigido e a partir dessa nova velocidade ele calcula o movimento do meu objeto. Aqui j� temos um calculo maior de f�sica. 
        //N�o funciona mt bem para colis�es de 2 objetos de corpor rigido.
        rigidbody.velocity = transform.TransformDirection(new Vector3(0, rigidbody.velocity.y) + direction.normalized * currentSpeed);

        //Add em geral s�o usados quando queremos criar um sistema que considere totalmente a f�sica. Ele funciona como um acelerador.
        //rigidbody.AddForce(transform.TransformDirection(new Vector3(0, rigidbody.velocity.y) + direction.normalized * currentSpeed), ForceMode.Acceleration);

        rigidbody.angularVelocity = new Vector3(0, rotation * moveSpeed, 0);
    }
}