using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform sun;
    public float orbitSpeed = 20f;

    void Update()
    {
        transform.RotateAround(
            sun.position,
            Vector3.up,
            orbitSpeed * Time.deltaTime
        );
    }
}