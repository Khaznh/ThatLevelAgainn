using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 moveVec;
    private Animator animator;

    private void Awake()
    {
        playerInput = new PlayerInput();
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    

    // Update is called once per frame
    void Update()
    {
        HandleGetInput();
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        animator.SetFloat("MoveX",moveVec.x);
    }

    private void HandleGetInput()
    {
        moveVec = playerInput.Player.Movement.ReadValue<Vector2>();
    }
}
