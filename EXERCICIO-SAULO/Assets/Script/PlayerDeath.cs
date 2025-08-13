using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            isDead = true;

            // Para movimento
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0;

            // Animação de morte
            animator.SetTrigger("Die");

            // Reinicia o jogo após 1.5 segundos
            Invoke("RestartGame", 1.5f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}