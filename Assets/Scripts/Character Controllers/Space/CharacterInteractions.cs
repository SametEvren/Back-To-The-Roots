using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"PlanetEarth"))
        {
            SceneController.Instance.LoadFuturisticWorld();
        }

        if (other.CompareTag("FuturisticMirror"))
        {
            SceneController.Instance.LoadModernWorld();
        }

        if (other.CompareTag("ModernMirror"))
        {
            SceneController.Instance.LoadPrimalWorld();
        }
    }
}
