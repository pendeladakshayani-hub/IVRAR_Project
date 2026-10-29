using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitPath : MonoBehaviour
{
    public float radius = 5f;
    public int segments = 100;

    void Start()
    {
        LineRenderer line = GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = true;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (float)i / segments * Mathf.PI * 2f;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, z));
        }
    }
}