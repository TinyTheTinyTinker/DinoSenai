using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    public ObstacleSpawner obSpawner;

    void Update()
    {
        speed = obSpawner.obstacleSpeed;

        // Move o obst�culo para a esquerda todo frame
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Se o obst�culo sair da tela (x < -10), destr�i para liberar mem�ria
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        obSpawner = GameObject.FindGameObjectWithTag("Socorro").GetComponent<ObstacleSpawner>();
    }
}
