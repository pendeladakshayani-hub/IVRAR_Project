using UnityEngine;

public class AsteroidSpin : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(10f, 20f, 15f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}