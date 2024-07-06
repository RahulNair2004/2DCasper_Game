using UnityEngine;
using System.Collections;

public class SquareFalling : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAfterDelay(5f)); // Delay falling for 0.5 seconds
        }
    }

    IEnumerator FallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb2d.gravityScale = 1f; // Enable gravity for the square
    }
}
