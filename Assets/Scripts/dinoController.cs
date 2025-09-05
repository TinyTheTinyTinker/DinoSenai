using UnityEngine;

public class dinoController : MonoBehaviour
{
    public float jumpVelocity = 8f;     // velocidade do salto
    public float fallMultiplier = 3f;   // força extra ao cair (pode ajustar)

    private Rigidbody2D rb;
    private bool isGrounded = true;

    public AudioSource audioSouce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pular com espaço
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
            isGrounded = false;

            audioSouce.Play();
        }

        // Aumenta a gravidade na queda (mais rápida)
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
