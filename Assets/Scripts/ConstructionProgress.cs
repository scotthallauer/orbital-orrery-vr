using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionProgress : MonoBehaviour
{
    int planetsPlaced;
    bool sonarStopped;
    public AudioSource completeSound;

    // Start is called before the first frame update
    void Start()
    {
        planetsPlaced = 0;
        sonarStopped = false;
    }
    
    void Update()
    {
        if (!sonarStopped) 
        {
            Renderer table = GameObject.Find("Table").GetComponent<Renderer>();
            AudioSource sonarSound = table.GetComponent<AudioSource>();
            Camera camera = GameObject.Find("VRCamera").GetComponent<Camera>();
            if (IsObjectVisible(camera, table))
            {
                sonarSound.Stop();
                sonarStopped = true;
            }
        }
    }

    public void Increment()
    {
        planetsPlaced++;
        if (planetsPlaced == 10)
        {
            completeSound.Play();
            StartOrbits();
            Destroy(GameObject.Find("Table"));
        }
    }

    bool IsObjectVisible(UnityEngine.Camera camera, Renderer renderer)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), renderer.bounds);
    }

    void StartOrbits()
    {
        for (int i = 0; i < 10; i++) 
        {
            GameObject templateObject = GameObject.Find("Templates").transform.GetChild(i).gameObject;
            if (!templateObject.name.Contains("Sun"))
            {
                templateObject.GetComponent<RotateAround>().enabled = true;
            }
        }
    }
}
