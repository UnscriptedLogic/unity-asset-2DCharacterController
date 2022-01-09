using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class EntityMovement : MonoBehaviour
{
    public MovementSettingsSO settingsSO;

    protected Rigidbody2D rb;
    public EntityChecker entityChecker;

    protected float checkTimer;
    protected float _slopeSpeed;

    protected float inertiaTime;
    protected float moveDir;
    protected float currMoveDir;

    protected float _jumpTime;
    protected float _jumpForce;
    protected float _jumpCurveTime;
    protected bool isJumping = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void ProneJump()
    {
        checkTimer = 0f;
        _jumpTime = 0f;
        _jumpCurveTime = 0f;
        _jumpForce = settingsSO.jumpPower;
    }

    public virtual void CancelJump()
    {
        _jumpTime = settingsSO.extraJumpTime + 0.1f;
        _jumpCurveTime = 1f;
        isJumping = false;
    }

    protected virtual void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
    }

    public virtual void GetMovement()
    {
        inertiaTime = 0f;
    }

    protected virtual void MoveCharacter()
    {
        rb.velocity = new Vector2(currMoveDir, rb.velocity.y);
    }

    protected void CalculateInertia()
    {
        if ((moveDir - currMoveDir) != 0)
        {
            inertiaTime += _slopeSpeed * Time.deltaTime;
            currMoveDir = Mathf.Lerp(currMoveDir, moveDir, settingsSO.inertiaSlope.Evaluate(inertiaTime));
        }
    }

    protected void CalculateJumpTime()
    {
        if (entityChecker.isGrounded(this) && !isJumping && checkTimer < settingsSO.jumpCheck)
        {
            isJumping = true;
        }

        if (_jumpTime < settingsSO.extraJumpTime && isJumping)
        {
            Jump();
            _jumpCurveTime += settingsSO.curveSpeed * Time.deltaTime;
            _jumpForce = Mathf.Lerp(_jumpForce, 0f, settingsSO.extraJumpCurve.Evaluate(_jumpCurveTime));
            _jumpTime += Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + (Vector3)settingsSO.groundCheckPos, settingsSO.groundCheckRadius);
    }
}
