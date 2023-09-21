using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{

    public Transform character;
    public Transform[] possibleCharacters = new Transform[2];
    public int whichCharacter;
    // Start is called before the first frame update
    void Start()
    {

        character = possibleCharacters[whichCharacter];
        character.GetComponent<CharacterController>().enabled = true;

        InputManager.Instance.control.Input.Swap.started += OnSwap;
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
        character.GetComponent<CharacterController>().enabled = false;

        whichCharacter = (whichCharacter + 1) % possibleCharacters.Length;

        character = possibleCharacters[whichCharacter];

        character.GetComponent<CharacterController>().enabled = true;

    }
}
