using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlacement : MonoBehaviour
{
    public Material planetMaterial;
    public AudioSource correctSound;
    public AudioSource Sun;
    public AudioSource Mercury;
    public AudioSource Venus;
    public AudioSource Earth;
    public AudioSource Moon;
    public AudioSource Mars;
    public AudioSource Jupiter;
    public AudioSource Saturn;
    public AudioSource Uranus;
    public AudioSource Neptune;


    public AudioSource wrongSound;


    string GetPlanetName(string objectName, string objectType)
    {
        string planetName = "";
        int idx = objectName.IndexOf(objectType);
        if (idx > 0) 
        {
            planetName = objectName.Substring(0, idx);          
        }
        return planetName;
    }

    void playPlanetNameSound(string templateName)
    {
        switch (templateName)
        {
            case "Sun":
            Sun.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Mercury":
            Mercury.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Venus":
            Venus.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Earth":
            Earth.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Moon":
            Moon.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Mars":
            Mars.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Jupiter":
            Jupiter.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Saturn":
            Saturn.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Uranus":
            Uranus.PlayDelayed(correctSound.clip.length+1);
            break;
            case "Neptune":
            Neptune.PlayDelayed(correctSound.clip.length+1);
            break;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        string templateName = GetPlanetName(gameObject.name, "Template");
        string sphereName = GetPlanetName(col.gameObject.name, "Sphere");
        if (templateName == sphereName) 
        {
            correctSound.Play();
            playPlanetNameSound(templateName);
            GameObject.Find("Player").GetComponent<ConstructionProgress>().Increment();
            Destroy(col.gameObject);
            GetComponent<MeshRenderer>().material = planetMaterial;

            // Show Saturn's rings
            if (templateName == "Saturn")
            {
                for (int i = 0; i < 2; i++) 
                {
                    GameObject ringObject = gameObject.transform.GetChild(i).gameObject;
                    if (ringObject.name.Contains("Asteroids"))
                    {
                        ringObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        ringObject.transform.localScale = new Vector3(1.35f, 1.35f, 1.35f);
                    }
                }
            }
        } 
        else 
        {
            wrongSound.Play();
        }
    }
}
