using UnityEngine;

public class Player : MonoBehaviour
{
    private float upForce = 300f;
    private Rigidbody2D rb2d;
    private Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.linearVelocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, upForce));
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // if player in the air we still wants him to keep the Jump state even if he clicks the right arrow
            if (!anim.GetBool("isJump"))
            {
                anim.SetBool("isRun", true);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isRun", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Whenever player touch the ground disable jump, and enable running state
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJump", false);
            if (Input.GetKey(KeyCode.RightArrow))
                anim.SetBool("isRun", true);
        }
        // Debug.Log("I got collision from: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameController.instance.gameOver) return;
        // Collect coin
        else if (collision.CompareTag("Coin"))
        {
            GameController.instance.PlayerScored();
            collision.transform.position = new Vector2(-15, -25);
            return;
        }

        // Player died
        rb2d.linearVelocity = Vector2.zero;
        anim.SetTrigger("die");
        GameController.instance.GameOver();
    }
}
