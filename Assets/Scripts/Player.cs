using System;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private bool isWalking, canMove;
    private float playerRadius, playerHeight, moveDistance;
    private Vector3 lastInteractDir;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;

    public static Player Instance
    {
        get; private set;
    }

    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {

        public BaseCounter counterSelected;
    }
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
        {

            Debug.Log("Error. More than one references of the Player");
        }
        isWalking = false;
        canMove = false;
        playerRadius = .7f;
        playerHeight = 2f;
        lastInteractDir = Vector3.zero;
    }
    private void Start()
    {
        InputManager.Instance.OnInteractAction += Input_OnInteractAction;
        InputManager.Instance.OnInteractAlternateAction += Input_OnInteractAlternateAction;
    }

    private void Input_OnInteractAlternateAction(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    private void Input_OnInteractAction(object sender, System.EventArgs e)
    {

        if (selectedCounter != null)
        {

            selectedCounter.Interact(this);
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
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {

                //Has clear counter in raycastHit
                if (baseCounter != selectedCounter)
                {

                    selectedCounter = baseCounter;
                    SetSelectedCounter(selectedCounter);

                }

            }
            else
            {

                SetSelectedCounter(null);
            }
            //Debug.Log(raycastHit.transform);
        }
        else
        {

            SetSelectedCounter(null);
        }


    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {

        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { counterSelected = selectedCounter });

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
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

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
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
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

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return this.kitchenObject != null;
    }
}
