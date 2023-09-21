using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Transform mCamera;
    private CharacterSwap characterSwap;

    private bool isAction;

    private float moveSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runningSpeed;

    private float isRunning;
    private float currentRunningVelocity;
    [SerializeField]
    private float rotateSpeed;
    private float rotateRefSpeed;
    private float smoothRotationSpeed = 0.1f;

    private bool isWalk;
    private bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = Camera.main.transform;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        characterSwap = GetComponent<CharacterSwap>();


        moveSpeed = walkSpeed;

        InputManager.Instance.control.Input.LeftShoulder.started += OnLeftShoulder;
        InputManager.Instance.control.Input.LeftShoulder.canceled += OnLeftShoulder;
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.enabled)
        {
            MoveCharacter();
            HandleMoveSpeed();

        }
        else
        {
            animator.SetFloat("moveX", 0, 0.35f, Time.deltaTime);
            animator.SetFloat("moveY", 0, 0.15f, Time.deltaTime);

            animator.SetFloat("running", 0, 0.2f, Time.deltaTime);
        }
    }
    private void MoveCharacter() // Move o personagem
    {


        Vector3 moveDirection = transform.TransformDirection(InputManager.Instance.GetAxis());

        isWalk = InputManager.Instance.GetAxis().magnitude != 0;

        if (isWalk == true) // conseguir olhar a face do personagem quando está andando
        {
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, mCamera.eulerAngles.y, ref rotateRefSpeed, smoothRotationSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        controller.Move(Vector3.down * 2 * Time.deltaTime);

        animator.SetFloat("moveX", InputManager.Instance.GetAxis().x, 0.35f, Time.deltaTime);
        animator.SetFloat("moveY", InputManager.Instance.GetAxis().z, 0.15f, Time.deltaTime);

        animator.SetFloat("running", isRunning, 0.2f, Time.deltaTime);

    }

    private void HandleMoveSpeed() //Controla a velocidade da movimentação do personagem
    {
        if (isRunning == 1)
        {
            moveSpeed = Mathf.SmoothDamp(moveSpeed, runningSpeed, ref currentRunningVelocity, 0.2f);
        }
        else if (isRunning == 0)
        {
            moveSpeed = Mathf.SmoothDamp(moveSpeed, walkSpeed, ref currentRunningVelocity, 0.2f); ;
        }
    }

    #region INPUT

    private void OnLeftShoulder(InputAction.CallbackContext value) // Diz se o player está andando ou correndo ao apertar Shift
    {
        if (value.started)
        {
            isRunning = 1;
        }
        if (value.canceled)
        {
            isRunning = 0;
        }
    }

    public void ActionDone()
    {
        isAction = false;
    }
    #endregion
}
