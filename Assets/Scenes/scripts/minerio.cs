using UnityEngine;
using UnityEngine.UI;

public class minerio : MonoBehaviour
{
    public GameObject objetoADrop; 
    public int vidaMaxima = 100;
    private int vidaAtual;

    public Slider barraDeVida; // para adicionar uma barra de vida futuramente (ignorar por enquanto)   

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
            Quebrar();
        }
    }

    public void Quebrar() // para dropar de 1 a 3 pedaços na posição em volta do minerio
    {
        int quantidade = Random.Range(1, 4); //randomizador de quantidade

        float raio = 1.0f;

        for (int i = 0; i < quantidade; i++) //randomizador de posição
        {
            Vector2 deslocamento = new Vector2(
                Random.Range(-raio, raio),
                Random.Range(-raio, raio)
            );
            Vector3 posicaoDrop = transform.position + (Vector3)deslocamento;

            Instantiate(objetoADrop, posicaoDrop, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitboxMinerador")) //tag que conta o dano
        {
            ReceberDano(20);
        }
    }
}

//OBS: o minério precisa ter 2 box collider, uma para a hitbox do minerador (essa sendo trigger), e outra para a hitbox do minério.