using UnityEngine;
using TMPro;

public class PlanetInfoUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text planetNameText;
    public TMP_Text planetDetailsText;

    public void ShowPlanetInfo(string planetName, string details)
    {
        panel.SetActive(true);

        planetNameText.text = planetName;
        planetDetailsText.text = details;
    }
}