using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed = 5f;
    public float animChange = 0f;
    public ObstacleSpawner obSpawner;

    void Update()
    {
        animChange += speed; 
        speed = obSpawner.obstacleSpeed;

        // Move o obst�culo para a esquerda todo frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Se o obst�culo sair da tela (x < -10), destr�i para liberar mem�ria
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }

        if (animChange > 20f)
        {
            //Mude Animacao
            animChange = 0;
        }
    }

    private void Awake()
    {
        obSpawner = GameObject.FindGameObjectWithTag("Socorro").GetComponent<ObstacleSpawner>();
    }
}
