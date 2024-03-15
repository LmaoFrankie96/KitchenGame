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

        inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {

            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {

            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {

            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {

            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        isWalking = moveDir != Vector3.zero;
        //Debug.Log(inputVector);
    }
    public bool IsWalking() {

        return isWalking;
    }
}
