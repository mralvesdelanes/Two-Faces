using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    // Start is called before the first frame update
    void Start()
    {
         if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();

        InputManager.Instance.control.Input.Swap.started += OnSwap;
        InputManager.Instance.control.Input.Swap.canceled += OnSwap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSwap(InputAction.CallbackContext value)
    {
        if (value.started && whichCharacter == 0)
        {
            whichCharacter = possibleCharacters.Count - 1;
        }
        if (value.canceled && whichCharacter == possibleCharacters.Count - 1)
        {
            whichCharacter -= 1;
        }
        Swap();
    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<CharacterController>().enabled = true;
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<CharacterController>().enabled = false;
            }
        }
    }
}
