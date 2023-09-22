using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{
    public UnityEvent onSwap;

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
        onSwap.Invoke();
    }
}
