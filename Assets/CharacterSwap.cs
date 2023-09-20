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
        if (possibleCharacters.Count > 0)
        {
            character = possibleCharacters[whichCharacter];
            character.GetComponent<CharacterController>().enabled = true;
        }

        InputManager.Instance.control.Input.Swap.started += OnSwap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSwap(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            // Desativa o personagem atual
            character.GetComponent<CharacterController>().enabled = false;

            // Incrementa o índice do personagem para a próxima troca
            whichCharacter = (whichCharacter + 1) % possibleCharacters.Count;

            // Atualiza o personagem para o novo selecionado
            character = possibleCharacters[whichCharacter];

            // Ativa o novo personagem
            character.GetComponent<CharacterController>().enabled = true;
        }
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
