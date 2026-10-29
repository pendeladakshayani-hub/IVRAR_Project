using UnityEngine;

public class AsteroidBeltGenerator : MonoBehaviour
{
    public int asteroidCount = 150;
    public float beltRadius = 12f;
    public float beltWidth = 3f;

    public float minSize = 0.08f;
    public float maxSize = 0.25f;

    public Material asteroidMaterial;

    void Start()
    {
        GenerateAsteroids();
    }

    void GenerateAsteroids()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            GameObject asteroid =
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            asteroid.name = "Asteroid_" + i;

            float angle = Random.Range(0f, 360f);
            float radius = Random.Range(
                beltRadius - beltWidth,
                beltRadius + beltWidth
            );

            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            float y = Random.Range(-0.6f, 0.6f);

            asteroid.transform.position =
                transform.position + new Vector3(x, y, z);

            float size = Random.Range(minSize, maxSize);

            asteroid.transform.localScale = new Vector3(
                size * Random.Range(0.7f, 1.4f),
                size * Random.Range(0.6f, 1.3f),
                size * Random.Range(0.7f, 1.4f)
            );

            asteroid.transform.rotation = Random.rotation;

            if (asteroidMaterial != null)
            {
                Renderer renderer = asteroid.GetComponent<Renderer>();
                renderer.material = asteroidMaterial;
            }

            asteroid.transform.SetParent(transform);
        }
    }
}