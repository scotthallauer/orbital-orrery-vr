using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollision : MonoBehaviour
{

    IEnumerator ResetPlanetPosition(GameObject planet)
    {
        string planetName = GetPlanetName(planet.name);
        // Hide object and play sound
        planet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        planet.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        Vector3 originalScale = planet.transform.localScale;
        planet.transform.localScale = new Vector3(0, 0, 0);
        AudioSource popSound = planet.GetComponent<AudioSource>();
        popSound.Play();
        yield return new WaitForSeconds(popSound.clip.length);
        // Move object back to table and show it
        switch (planetName)
        {
            case "Sun":
            planet.transform.localPosition = new Vector3(0, 2.34f, 0);
            break;
            case "Mercury":
            planet.transform.localPosition = new Vector3(2, 1.43f, 0.5f);
            break;
            case "Venus":
            planet.transform.localPosition = new Vector3(-3.3f, 1.48f, 0.5f);
            break;
            case "Earth":
            planet.transform.localPosition = new Vector3(1.4f, 1.51f, 0.5f);
            break;
            case "Moon":
            planet.transform.localPosition = new Vector3(-4, 1.42f, 0.5f);
            break;
            case "Mars":
            planet.transform.localPosition = new Vector3(5, 1.46f, 0.5f);
            break;
            case "Jupiter":
            planet.transform.localPosition = new Vector3(4, 1.63f, 0.5f);
            break;
            case "Saturn":
            planet.transform.localPosition = new Vector3(-2, 1.6f, 0.5f);
            break;
            case "Uranus":
            planet.transform.localPosition = new Vector3(3, 1.57f, 0.5f);
            break;
            case "Neptune":
            planet.transform.localPosition = new Vector3(-5, 1.54f, 0.5f);
            break;
        }
        planet.transform.localScale = originalScale;
    }

    string GetPlanetName(string objectName)
    {
        string planetName = "";
        int idx = objectName.IndexOf("Sphere");
        if (idx > 0) 
        {
            planetName = objectName.Substring(0, idx);          
        }
        return planetName;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Sphere")) {
            StartCoroutine(ResetPlanetPosition(col.gameObject));
        }
    }
}
