using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : EntityMovement
{
    [Header("Sub class properties")]
    public PlayerInput playerInput;

    protected override void Start()
    {
        base.Start();

        playerInput.RegisterBind(RetrieveMovement, "Move", ActionEventType.Performed);
        playerInput.RegisterBind(RetrieveMovement, "Move", ActionEventType.Cancelled);

        playerInput.RegisterBind(InputJump, "Jump", ActionEventType.Performed);
        playerInput.RegisterBind(CancelInputJump, "Jump", ActionEventType.Cancelled);

        _jumpForce = settingsSO.jumpPower;
    }

    private void Update()
    {
        CalculateJumpTime();

        CalculateInertia();

        _slopeSpeed = entityChecker.isGrounded(this) ? settingsSO.groundedSlopeSpeed : settingsSO.airborneSlopeSpeed;
        checkTimer = checkTimer <= settingsSO.jumpCheck ? checkTimer + Time.deltaTime : checkTimer;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void RetrieveMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>().x * settingsSO.movementSpeed;
        GetMovement();
    }

    private void InputJump(InputAction.CallbackContext context)
    {
        ProneJump();
    }

    private void CancelInputJump(InputAction.CallbackContext context)
    {
        CancelJump();
    }
}
