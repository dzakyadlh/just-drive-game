using UnityEngine;

public class Collision : MonoBehaviour
{
    private int packageNumber = 0;
    
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch! I hit something!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package"))
        {
            Debug.Log("You've picked up a package!");
            packageNumber++;
            Debug.Log("Total packages: " + packageNumber);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Package Owner") && packageNumber > 0)
        {
            Debug.Log("You've delivered " + packageNumber + " packages!");
            packageNumber = 0;
        }
    }
}
