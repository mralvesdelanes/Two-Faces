using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{

    public PlayerController playerWhite, playerBlack;

    void Start()
    {
        InputManager.Instance.control.Input.Swap.started += OnSwap;

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void OnDestroy()
    {
        InputManager.Instance.control.Input.Swap.started -= OnSwap;
    }


    private void OnSwap(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Swap();
        }
    }


    public void Swap()
    {
        if (playerWhite.isSelected)
        {
            playerWhite.isSelected = false;
            playerBlack.isSelected = true;
        }
        else
        {
            playerBlack.isSelected = false;
            playerWhite.isSelected = true;
        }

    }
}
