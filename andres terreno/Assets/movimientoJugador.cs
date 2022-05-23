using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]


public class movimientoJugador : MonoBehaviour
{
    public float gravityScale = -20f;

    [Header("reference")]
    public Camera CameraJugador;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    [Header("rotation")]
    public float rotationSensibility = 10f;
    private float cameraVerticalangle;

    Vector3 moveInput = Vector3.zero;
    Vector3 rotationImput = Vector3.zero;
    CharacterController characterController;

    [Header("Jump")]
    public float jumpHeight = 1.9f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Look();
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded )
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
             
            if(Input.GetButton ("Sprint"))
            {
                moveInput = transform.TransformDirection (moveInput) * runSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkSpeed;
            }
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }
        {
            moveInput.y += gravityScale * Time.deltaTime;
            characterController.Move(moveInput * Time.deltaTime);
        }
    } 
    private void Look()
    {
        rotationImput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationImput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalangle = cameraVerticalangle + rotationImput.y;
        cameraVerticalangle = Mathf.Clamp(cameraVerticalangle, - 70, 70);

        transform.Rotate(Vector3.up * rotationImput.x);
        CameraJugador.transform.localRotation = Quaternion.Euler (-cameraVerticalangle, 0f, 0f);
    }
}