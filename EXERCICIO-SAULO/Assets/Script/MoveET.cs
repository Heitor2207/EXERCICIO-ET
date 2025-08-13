using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;
    private bool noChao;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimento horizontal
        float movimento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        // Pulo
        if (Input.GetButtonDown("Jump") && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    // Detecta se está no chão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Chao"))
        {
            noChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Chao"))
        {
            noChao = false;
        }
    }
}