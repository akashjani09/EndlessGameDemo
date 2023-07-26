using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject ground_Prefab;
    public int groundPoolSize = 5;
    public float spawnZ = 0f;
    public float groundLength = 10f;

    private Transform playerTransform;
    private float spawnX = 0f;
    private GameObject[] groundPool;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        groundPool = new GameObject[groundPoolSize];
        for (int i = 0; i < groundPoolSize; i++)
        {
            groundPool[i] = Instantiate(ground_Prefab, Vector3.zero, Quaternion.identity);
        }
        RecycleGround();
    }

    private void Update()
    {
        if (playerTransform.position.z - 20 > (spawnZ - groundPoolSize * groundLength))
        {
            RecycleGround();
        }
    }

    void RecycleGround()
    {
        groundPool[0].transform.position = new Vector3(spawnX, 0f, spawnZ);
        spawnZ += groundLength;
        GameObject tmp = groundPool[0];
        for (int i = 1; i < groundPoolSize; i++)
        {
            groundPool[i - 1] = groundPool[i];
        }
        groundPool[groundPoolSize - 1] = tmp;
    }
}
