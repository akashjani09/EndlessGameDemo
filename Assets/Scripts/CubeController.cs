using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        // Move the cube forward continuously
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
