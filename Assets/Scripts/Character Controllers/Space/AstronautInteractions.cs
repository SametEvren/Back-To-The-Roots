using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class AstronautInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"PlanetEarth"))
        {
            SceneController.Instance.LoadModernWorld();
        }
    }
}
