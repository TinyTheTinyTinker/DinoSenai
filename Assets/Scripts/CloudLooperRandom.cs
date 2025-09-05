using UnityEngine;

public class CloudLooperRandom : MonoBehaviour
{
    public Transform[] clouds; 
    public float speed = 1f;

    private float cloudWidth;
    private Camera mainCamera;
    private float screenRightEdgeX;

    void Start()
    {
        mainCamera = Camera.main;

        if (clouds.Length > 0)
        {
            cloudWidth = clouds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        // Calcula o limite direito da câmera toda frame (considerando ortográfica)
        screenRightEdgeX = mainCamera.transform.position.x + (mainCamera.orthographicSize * mainCamera.aspect);

        foreach (Transform cloud in clouds)
        {
            cloud.position += Vector3.left * speed * Time.deltaTime;

            float leftLimit = mainCamera.transform.position.x - (mainCamera.orthographicSize * mainCamera.aspect) - cloudWidth;

            if (cloud.position.x <= leftLimit)
            {
                // Reposiciona a nuvem exatamente no limite direito da tela + metade da largura da nuvem
                float newX = screenRightEdgeX + (cloudWidth / 2f);
                cloud.position = new Vector3(newX, cloud.position.y, cloud.position.z);
            }
        }
    }
}