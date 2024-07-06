using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // NPC movement (you can modify this based on your NPC behavior)
        Vector2 movement = new Vector2(moveSpeed, 0f) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Ignore collision with the player
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Re-enable collision when the player exits the trigger area
        if (other.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, false);
        }
    }
}
