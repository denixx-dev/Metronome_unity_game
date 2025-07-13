using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float speed = 0.001f;
    public Rigidbody2D rb;
    public Vector2 moveDirection;
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();

        moveDirection = Vector2.right;

        rb.gravityScale = 0f;
        rb.linearVelocity = moveDirection.normalized;
    }

    void OnCollisionEnter2D(Collision2D collision){
        Vector2 normal = collision.contacts[0].normal;

        moveDirection = Vector2.Reflect(moveDirection, normal).normalized;

        rb.linearVelocity = moveDirection;

        if (collision.gameObject.CompareTag("Border")){
            audioSource.Play();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
