using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement_Player : MonoBehaviour
{
    [Header("Variaveis do jogador")]
    [SerializeField] float speedMovement;
    [SerializeField] float speedRotate_Camera;
    [SerializeField] float dodgePower;
    [SerializeField] float cooldownDodge;
    [SerializeField] float powerJump;

    [Header("Componentes do jogador")]
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Transform pivotCamera;
    [SerializeField] Animator animatorController;

    [Header("Informações e controladores")]
    [SerializeField] bool isMovement;
    [SerializeField] bool isRotate;
    [SerializeField] bool isDodge;
    [SerializeField] bool isJump;
    [SerializeField]private LayerMask groundLayer;

    private Vector2 direction;
    private RaycastHit raycastHit;

    void FixedUpdate()
    {
        MovementPlayer();
        RotateCamera();
        JumpPlayer();
    }    

    #region Private Methods
    private void MovementPlayer()
    {
        if(isMovement)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            
            animatorController.SetFloat("Horizontal", direction.x);
            animatorController.SetFloat("Vertical", direction.y);

            direction = direction.normalized;


            rigidbody.velocity = transform.TransformDirection(direction.x * speedMovement * Time.fixedDeltaTime, rigidbody.velocity.y, direction.y * speedMovement * Time.fixedDeltaTime);
        }
    }
    private void RotateCamera()
    {
        if(isRotate)
        {
            Vector2 rotateCamera = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            pivotCamera.Rotate(rotateCamera.y * speedRotate_Camera * Time.fixedDeltaTime,0,0);
            rigidbody.angularVelocity = new Vector3(0, rotateCamera.x * speedRotate_Camera * Time.fixedDeltaTime,0);
        }
    }
    private void DodgePlayer()
    {
        if (isDodge) 
        { 
            rigidbody.velocity = new Vector3(rigidbody.velocity.normalized.x * dodgePower * Time.fixedDeltaTime, 0, rigidbody.velocity.normalized.y * dodgePower * Time.fixedDeltaTime);
            isDodge = false;
            StartCoroutine(CooldownDodge());
            Debug.Log("Dodge: " + direction);
        }
    }
    private void JumpPlayer()
    {
        if(isJump)
        {
            float jump = Input.GetAxis("Jump");

            if (Physics.Raycast(transform.position + new Vector3(0,0.5f,0), Vector3.down, 1f, groundLayer) && jump > 0.1f)
            {
                Debug.Log("Esta colidindo com o chao");  
                rigidbody.velocity = new Vector3(rigidbody.velocity.x , jump * powerJump * Time.fixedDeltaTime, rigidbody.velocity.z);
                animatorController.SetTrigger("Jump");
                jump = 0;
            }
        }
    }
    #endregion

    #region  Public Methods
    public void SwapMovementBool()
    {
        isMovement = !isMovement;
    }
    #endregion

    #region Corrotina
    IEnumerator CooldownDodge()
    {
        yield return new WaitForSecondsRealtime(cooldownDodge);
        isDodge = true;
    }
    #endregion
}
