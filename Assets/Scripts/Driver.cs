using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float slowedSpeed = 0.1f;
    [SerializeField] private float boostedSpeed = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Driver script started!");
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Buff"))
        {
            moveSpeed = boostedSpeed;
            Debug.Log("Speed Boost Activated!");
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            moveSpeed = slowedSpeed;
            Debug.Log("Slowed Down!");
        }
    }
}
