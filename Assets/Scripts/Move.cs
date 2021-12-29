using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;

    [SerializeField] private float moveSpeed = 5000;
    [SerializeField] private float jumpForce = 500;
    private bool isJumping = false;
    private bool punchRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        anim.SetInteger("movement", (int) direction);
        anim.SetBool("isMoving", direction != 0);

        float movement = direction * moveSpeed * Time.deltaTime;
        Vector3 translation = new Vector2(movement, 0);
        rb2d.AddForce(translation);

        if (Input.GetButtonDown("Jump") && !isJumping)
		{
            StartCoroutine(Jump());
        }

        if (direction == -1)
		{
            transform.localScale = new Vector2(-1, transform.localScale.y);
		}
        if (direction == 1)
		{
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if (Input.GetMouseButtonDown(0))
		{
            if (punchRight)
			{
                anim.SetTrigger("punchRight");
                punchRight = !punchRight;
			} else
			{
                anim.SetTrigger("punchLeft");
                punchRight = !punchRight;
            }
        }
    }

    private IEnumerator Jump()
	{
        isJumping = true;
        anim.SetTrigger("jump");
        anim.SetBool("isGrounded", false);
        rb2d.AddForce(Vector2.up * jumpForce);
        yield return null;
    }

    private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Floor") && isJumping)
		{
            isJumping = false;
            anim.SetBool("isGrounded", true);
		}
	}
}
