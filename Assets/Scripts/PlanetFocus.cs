using UnityEngine;

public class PlanetFocus : MonoBehaviour
{
    public Camera mainCamera;

    void OnMouseDown()
    {
        if (mainCamera != null)
        {
            SolarSystemCameraController cameraController =
                mainCamera.GetComponent<SolarSystemCameraController>();

            if (cameraController != null)
            {
               cameraController.FocusOnPlanet(transform);
            }
        }

        PlanetInfoUI infoUI = Resources.FindObjectsOfTypeAll<PlanetInfoUI>()[0];

        if (infoUI != null)
        {
            string planetName = gameObject.name;
            string details = GetPlanetDetails(planetName);

            infoUI.ShowPlanetInfo(planetName.ToUpper(), details);
        }
    }

    string GetPlanetDetails(string planetName)
    {
        switch (planetName)
        {
            case "Mercury":
                return "Distance from Sun: 0.39 AU\nType: Terrestrial Planet\nMoons: 0";

            case "Venus":
                return "Distance from Sun: 0.72 AU\nType: Terrestrial Planet\nMoons: 0";

            case "Earth":
                return "Distance from Sun: 1 AU\nType: Terrestrial Planet\nMoons: 1";

            case "Mars":
                return "Distance from Sun: 1.52 AU\nType: Terrestrial Planet\nMoons: 2";

            case "Jupiter":
                return "Distance from Sun: 5.2 AU\nType: Gas Giant\nMoons: Many";

            case "Saturn":
                return "Distance from Sun: 9.58 AU\nType: Gas Giant\nMoons: Many";

            case "Uranus":
                return "Distance from Sun: 19.2 AU\nType: Ice Giant\nMoons: Many";

            case "Neptune":
                return "Distance from Sun: 30.1 AU\nType: Ice Giant\nMoons: Many";

            case "Moon":
                return "Orbits: Earth\nType: Natural Satellite\nMoons: 0";

            default:
                return "Solar System Object";
        }
    }
}