using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 inputVector;
    private static InputManager instance;
    private PlayerInputActions inputActions;
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
    }
    public Vector2 GetMovementVector()
    {

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
