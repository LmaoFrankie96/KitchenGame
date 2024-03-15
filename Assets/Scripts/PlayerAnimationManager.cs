using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private Player player;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        MovementFlags();
    }
    private void Update()
    {
        MovementFlags();
    }
    private void MovementFlags()
    {
        playerAnimator.SetBool(IS_WALKING, player.IsWalking());

    }
}
