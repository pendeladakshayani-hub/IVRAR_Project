using UnityEngine;

public class AsteroidBeltRotation : MonoBehaviour
{
    public float orbitSpeed = 3f;
    public float rotationSpeed = 20f;

    void Update()
    {
        // Move the entire asteroid belt around the Sun
        transform.RotateAround(Vector3.zero, Vector3.up, orbitSpeed * Time.deltaTime);

        // Rotate each asteroid individually
        foreach (Transform asteroid in transform)
        {
            asteroid.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}