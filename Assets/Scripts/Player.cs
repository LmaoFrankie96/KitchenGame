using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private Vector2 inputVector;
    private bool isWalking;

    private void Awake()
    {
        isWalking = false;
    }
    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        inputVector = InputManager.Instance.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        isWalking = moveDir != Vector3.zero;
        //Debug.Log(inputVector);
    }
    public bool IsWalking()
    {

        return isWalking;
    }
}
