using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public Transform earth;
    public float orbitSpeed = 80f;

    void Update()
    {
        transform.RotateAround(
            earth.position,
            Vector3.up,
            orbitSpeed * Time.deltaTime
        );
    }
}