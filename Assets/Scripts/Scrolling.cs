using UnityEngine;

public class Scrolling : MonoBehaviour
{

   private Rigidbody2D rb2d;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver || GameController.instance.isPaused || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb2d.linearVelocity = Vector2.zero;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
          rb2d.linearVelocity = new Vector2(GameController.instance.scrollSpeed, 0);
        }
        
    }
}
