using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TMP_Text meuTexto; // Arraste seu Text aqui no Inspector
    private float tempo = 0f;
    private float speedIncreaseVar = 0f;

    //Scripts Afetados Pela Velocidade A Baixo
    public GroundLooper groundLooperScript;
    public float obstacleSpeed = 5f;
    public CloudLooperRandom cloudLooper;
    public CloudLooperRandom bushesLooper;
    public dinoController dinoControlScript;

    void Update()
    {
        tempo += Time.deltaTime;
        speedIncreaseVar += Time.deltaTime;

        int segundos = Mathf.FloorToInt(tempo);
        int milissegundos = Mathf.FloorToInt((tempo - segundos) * 1000);
        meuTexto.text = string.Format("{0}:{1:000}", segundos, milissegundos);

        if (speedIncreaseVar >= 10f)
        {
            // Aumenta a velocidade do jogo
            groundLooperScript.speed++;
            obstacleSpeed = obstacleSpeed * 2;
            cloudLooper.speed++;
            bushesLooper.speed++;
            dinoControlScript.fallMultiplier++;
            speedIncreaseVar = 0f;
        }
    }
}
