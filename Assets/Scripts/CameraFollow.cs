using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    private Transform playerPos;
    private void Awake ()
    {
        playerPos = GameObject.FindGameObjectWithTag ("Player").transform;
    }
    void Update()
    {
        // слежение за игроком
        transform.position = new Vector3 (playerPos.position.x, playerPos.position.y,
            transform.position.z);

        // ограничение движения по карте
        transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -7.2f, 7.2f),
            Mathf.Clamp (transform.position.y, -5.4f, 5.4f), transform.position.z); 
    }
}
