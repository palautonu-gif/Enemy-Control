using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    float moveSpeed = 5f;

    private void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.wKey.wasPressedThisFrame || kb.upArrowKey.wasPressedThisFrame)
            _direction = Vector2.up;
        else if (kb.sKey.wasPressedThisFrame || kb.downArrowKey.wasPressedThisFrame)
            _direction = Vector2.down;
        else if (kb.aKey.wasPressedThisFrame || kb.leftArrowKey.wasPressedThisFrame)
            _direction = Vector2.left;
        else if (kb.dKey.wasPressedThisFrame || kb.rightArrowKey.wasPressedThisFrame)
            _direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)_direction * moveSpeed * Time.fixedDeltaTime;
    }
}