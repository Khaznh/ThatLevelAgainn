using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speedForce = 5f;

    private PlayerInput playerInput;
    private Vector2 inputVec;
    private Rigidbody2D rid;
    private bool isFaceRight = true;
    private bool isOnGround = false;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rid = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInputVector();
        HandleFacing();
        HandleJump();
    }

    private void FixedUpdate()
    {
        HandeMovement();
    }

    private void GetInputVector()
    {
        inputVec = playerInput.Player.Movement.ReadValue<Vector2>();
    }

    private void HandleFacing()
    {
        if (isFaceRight && inputVec.x < 0)
        {
            Vector3 temp = transform.parent.localScale;
            transform.parent.localScale = new Vector3(temp.x * -1, temp.y, temp.z);
            isFaceRight = false;
        } else if (!isFaceRight && inputVec.x > 0)
        {
            Vector3 temp = transform.parent.localScale;
            transform.parent.localScale = new Vector3(temp.x * -1, temp.y, temp.z);
            isFaceRight = true;
        }
    }

    private void HandleJump()
    {
        if (playerInput.Player.Jump.WasPressedThisFrame() && isOnGround)
        {
            rid.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private void HandeMovement()
    {
        rid.linearVelocity = new Vector2(inputVec.x * speedForce, rid.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
