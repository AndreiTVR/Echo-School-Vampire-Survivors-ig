using UnityEngine;
using UnityEngine.InputSystem; // 1. Add this namespace

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 2. Use Keyboard.current instead of Input.GetAxis
        float moveX = 0;
        float moveZ = 0;

        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveX = -1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveX = 1f;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) moveZ = 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) moveZ = -1f;
        }

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized; // Normalized stops diagonal speed boost
        transform.Translate(movement * speed * Time.deltaTime);
    }
}