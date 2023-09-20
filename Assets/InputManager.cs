using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public PlayerController playerController;
    public Controls control;
    private InputAction Axis;
    public CharacterSwap CharacterSwap;



    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        control = new Controls();
        Axis = control.Input.Axis;
        control.Enable();
    }

    public Vector3 GetAxis()
    {
        return new Vector3(Axis.ReadValue<Vector2>().x, 0, Axis.ReadValue<Vector2>().y);
    }
}
