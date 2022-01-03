using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public string actionMapName;
    InputActionMap actionMap;
    InputAction move;

    public float speed = 10f;

    Vector2 direction;
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        actionMap = actionAsset.FindActionMap(actionMapName);
        move = actionAsset.FindAction("Move");

        move.performed += Movement;
        move.canceled += Movement;
        move.Enable();
    }

    private void Update()
    {
        MoveCharacter(direction);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(transform.position + ((Vector3)direction * speed * Time.deltaTime));
    }

}
