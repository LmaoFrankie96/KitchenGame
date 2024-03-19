using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private bool isWalking, canMove;
    private float playerRadius, playerHeight, moveDistance;
    private Vector3 lastInteractDir;
    [SerializeField] private LayerMask countersLayerMask;
    private void Awake()
    {
        isWalking = false;
        canMove = false;
        playerRadius = .7f;
        playerHeight = 2f;
        lastInteractDir = Vector3.zero;
    }
    private void Start()
    {
        InputManager.Instance.OnInteractAction += Input_OnInteractAction;
    }

    private void Input_OnInteractAction(object sender, System.EventArgs e)
    {

        Vector2 inputVector = InputManager.Instance.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {

                //Has clear counter in raycastHit
               clearCounter.Interact();
            }
            //Debug.Log(raycastHit.transform);
        }

    }

    private void Update()
    {
        PlayerMovement();
        PlayerInteractions();
    }
    private void PlayerInteractions()
    {
        Vector2 inputVector = InputManager.Instance.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {

                //Has clear counter in raycastHit
                //clearCounter.Interact();
            }
            //Debug.Log(raycastHit.transform);
        }

    }
    private void PlayerMovement()
    {
        Vector2 inputVector = InputManager.Instance.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        moveDistance = moveSpeed * Time.deltaTime;
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        if (!canMove)
        {
            //Cannot move towards moveDir

            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //Can only move on the X
                moveDir = moveDirX;

            }
            else
            {

                // Cannot only move on the x
                //Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;

                }
                else
                {

                    //Cannot move in any direction

                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        isWalking = moveDir != Vector3.zero;
        //Debug.Log(inputVector);
    }
    public bool IsWalking()
    {

        return isWalking;
    }
}
