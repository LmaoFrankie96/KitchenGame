using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 inputVector;
    private static InputManager instance;
    private PlayerInputActions inputActions;
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public static InputManager Instance
    {
        get
        {

            if (instance == null)
            {

                instance = FindObjectOfType<InputManager>();
                if (instance != null)
                {

                    DontDestroyOnLoad(instance.gameObject);
                }

            }
            return instance;
        }
        private set { instance = value; }

    }
    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.InteractAlt.performed += InteractAlt_performed;
    }

    private void InteractAlt_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
