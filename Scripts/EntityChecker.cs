using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityChecker : MonoBehaviour
{
    public bool isGrounded(EntityMovement moveScript) 
    {
        return Physics2D.OverlapCircle((Vector2)moveScript.transform.position + moveScript.settingsSO.groundCheckPos, moveScript.settingsSO.groundCheckRadius, moveScript.settingsSO.groundLayer);
    }
}
