using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    public Transform[] groundPieces; // Blocos de chão
    public float speed = 5f;

    private float groundWidth;

    void Start()
    {
        if (groundPieces.Length > 0)
        {
            groundWidth = groundPieces[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        foreach (Transform ground in groundPieces)
        {
            ground.position += Vector3.left * speed * Time.deltaTime;

            // Se o chão sair da tela pela esquerda, reposiciona à direita do mais à frente
            if (ground.position.x <= -groundWidth)
            {
                float rightMostX = GetRightMostGroundX();
                ground.position = new Vector3(rightMostX + groundWidth, ground.position.y, ground.position.z);
            }
        }
    }

    float GetRightMostGroundX()
    {
        float maxX = float.MinValue;
        foreach (Transform ground in groundPieces)
        {
            if (ground.position.x > maxX)
                maxX = ground.position.x;
        }
        return maxX;
    }
}
