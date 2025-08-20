using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int vidaMaxima = 100;
    private int vidaAtual;
    public Slider barraDeVida;

    void Start()
    {
        vidaAtual = vidaMaxima;
        if (barraDeVida != null)
        {
            barraDeVida.maxValue = vidaMaxima;
            barraDeVida.value = vidaAtual;
        }
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
        if (barraDeVida != null)
        {
            barraDeVida.value = vidaAtual;
        }

        if (vidaAtual <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("armadilha"))
        {
            ReceberDano(20);
        }
        else if (collision.CompareTag("inimigo"))
        {
            ReceberDano(100); 
        }
    }

    Vector2 movement;

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}