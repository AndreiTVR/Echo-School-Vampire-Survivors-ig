using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        // Get input in Update
        float x = 0;
        float y = 0;
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed)
            {
                anim.SetBool("backWalk", false);
                anim.SetBool("sideskWalk", false);
                anim.SetBool("walkFront", true);
                anim.SetBool("idle", false);

                x = -1f;
            }
            if (keyboard.dKey.isPressed)
            {
                x = 1f;
                anim.SetBool("backWalk", false);
                anim.SetBool("sideskWalk", true);
                anim.SetBool("walkFront", false);
                anim.SetBool("idle", false);
            }
            if (keyboard.wKey.isPressed)
            {
                y = 1f;
                anim.SetBool("backWalk", true);
                anim.SetBool("sideskWalk", false);
                anim.SetBool("walkFront", false);
                anim.SetBool("idle", false);
            }
            if (keyboard.sKey.isPressed) {
                y = -1f;
                anim.SetBool("backWalk", false);
                anim.SetBool("sideskWalk", true);
                anim.SetBool("walkFront", false);
                anim.SetBool("idle", false);
            }
            else
            {
                anim.SetBool("backWalk", false);
                anim.SetBool("sideskWalk", false);
                anim.SetBool("walkFront", false);
                anim.SetBool("idle", true);
            }
        }

        moveInput = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        // Move the physical body in FixedUpdate for smooth collisions
        rb.linearVelocity = moveInput * speed;
    }
}