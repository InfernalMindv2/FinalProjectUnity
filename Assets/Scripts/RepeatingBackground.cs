using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private float groundHorizontalLength;
    private BoxCollider2D groundCollider;
    public GameObject ground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundCollider = ground.GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }
    
    private void RepositionBackground()
    {
        transform.position = new Vector2(transform.position.x + groundHorizontalLength * 2, 0);
    }
}
