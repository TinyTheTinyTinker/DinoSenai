using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinoCollison : MonoBehaviour
{
    public GameObject gameOverText; // objeto de UI com a mensagem "Você morreu"

    public AudioSource audioSouce; // arrastar no Inspector



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Time.timeScale = 0f; // pausa o jogo
            if (gameOverText != null)
                gameOverText.SetActive(true);

            audioSouce.Stop(); // para o som do jogo
        }
    }
}