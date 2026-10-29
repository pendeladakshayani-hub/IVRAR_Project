using UnityEngine;

public class CometOrbit : MonoBehaviour
{
    public float orbitSpeed = 25f;
    public float orbitWidth = 18f;
    public float orbitHeight = 6f;

    private float angle = 0f;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float radians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians) * orbitWidth;
        float z = Mathf.Sin(radians) * orbitHeight;

        Vector3 newPosition = new Vector3(x, 2f, z);

        // Direction the comet is travelling
        Vector3 movementDirection = newPosition - previousPosition;

        if (movementDirection.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(movementDirection);
        }

        transform.position = newPosition;

        previousPosition = newPosition;
    }
}