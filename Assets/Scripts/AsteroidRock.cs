using UnityEngine;

public class AsteroidRock : MonoBehaviour
{
    public float deformation = 0.25f;
    public float noiseScale = 3f;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter == null)
            return;

        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;

        float seed = Random.Range(0f, 100f);

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 direction = vertices[i].normalized;

            float noise1 = Mathf.PerlinNoise(
                direction.x * noiseScale + seed,
                direction.y * noiseScale + seed
            );

            float noise2 = Mathf.PerlinNoise(
                direction.y * noiseScale + seed,
                direction.z * noiseScale + seed
            );

            float noise3 = Mathf.PerlinNoise(
                direction.z * noiseScale + seed,
                direction.x * noiseScale + seed
            );

            float noise = (noise1 + noise2 + noise3) / 3f;

            float offset = (noise - 0.5f) * deformation;

            vertices[i] += direction * offset;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}