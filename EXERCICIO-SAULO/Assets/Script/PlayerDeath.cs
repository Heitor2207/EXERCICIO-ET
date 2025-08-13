using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isDead = false;

    // Nome da tag do objeto que mata
    public string tagPerigosa = "Perigo";

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Só morre se encostar no objeto com a tag definida
        if (!isDead && collision.gameObject.CompareTag(tagPerigosa))
        {
            isDead = true;

            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0;

            if (animator != null)
                animator.SetTrigger("Die");

            Invoke(nameof(RestartGame), 0.3f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}