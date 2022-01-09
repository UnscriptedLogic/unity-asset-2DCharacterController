using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Movement Settings", menuName = "ScriptableObjects/Movement Setting")]
public class MovementSettingsSO : ScriptableObject
{
    [Header("Settings")]
    public float movementSpeed = 12f;
    public float jumpPower = 13f;

    [Header("Advanced Settings")]
    public float jumpCheck = 0.2f;

    [Space(15)]
    public Vector2 groundCheckPos = new Vector2(0f, -0.5f);
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Space(15)]
    public AnimationCurve inertiaSlope;
    public float groundedSlopeSpeed = 0.5f;
    public float airborneSlopeSpeed = 0.35f;

    [Space(15)]
    public float extraJumpTime = 0.3f;
    public float curveSpeed = 1f;
    public AnimationCurve extraJumpCurve;
}
