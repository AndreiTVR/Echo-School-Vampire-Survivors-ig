using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = 0;
        float moveY = 0; // Changed from moveZ to moveY

        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            // Left/Right = X
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveX = -1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveX = 1f;

            // Up/Down = Y (This was your moveZ)
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) moveY = 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) moveY = -1f;
        }

        // Apply to X and Y, keep Z at 0
        Vector3 movement = new Vector3(moveX, moveY, 0).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
    }
}