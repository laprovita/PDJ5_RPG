using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_Movement : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotation;

    [SerializeField] Vector2 direction;
    [SerializeField] float rotation;

    [SerializeField] float magnitude;

    [Header("Referencias")]
    [SerializeField] GameObject prefab_Lua;
    [SerializeField] Transform luaCopyTransform;
    private void Update()
    {
        MovementObject();
        InstantiateObject();
    }

    private void MovementObject()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
        rotation = Input.GetAxis("RotateKeyBoard");

        direction.Normalize();
        luaCopyTransform.Translate(direction.x * speedMovement * Time.deltaTime, 0, direction.y * speedMovement * Time.deltaTime);
        luaCopyTransform.Rotate(0, rotation * speedRotation * Time.deltaTime, 0);

        magnitude = direction.magnitude;
    }

    private void InstantiateObject()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab_Lua, luaCopyTransform.position, luaCopyTransform.rotation);
        }
    }
}
