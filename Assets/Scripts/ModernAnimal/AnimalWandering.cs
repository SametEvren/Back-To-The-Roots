using System;
using UnityEngine;
using DG.Tweening;
using Polyperfect.PrehistoricAnimals;
using Unity.VisualScripting;
using Utility;
using Random = System.Random;

public class AnimalWandering : MonoBehaviour
{
    public Vector3[] path;
    public Transform[] pathElementsTransform;
    public float duration = 20f;
    public float idleTime = 2f;
    public float durationRandMin, durationRandMax;
    public float idleRandMin, idleRandMax;

    private void Start()
    {
        SetPath();
        Wander();
    }

    private void Wander()
    {
        SetPath();
        if (path.Length > 6)
        {
            durationRandMin = 40;
            durationRandMax = 50;
            idleRandMin = 7;
            idleRandMax = 12;
        }
        else
        {
            durationRandMin = 5;
            durationRandMax = 10;
            idleRandMin = 2;
            idleRandMax = 5;
        }
        duration = UnityEngine.Random.Range(durationRandMin, durationRandMax);
        idleTime = UnityEngine.Random.Range(idleRandMin, idleRandMax);
        GetComponent<AnimationControl>().SetAnimation("isRunning");
        transform.DOPath(path, duration, PathType.Linear).SetLookAt(0.01f).OnComplete(() =>
        {
            GetComponent<AnimationControl>().SetAnimationIdle();
            transform.DOLocalRotate(new Vector3(0, 180, 0), idleTime).OnComplete(Wander);
        }).SetEase(Ease.Linear);
    }

    private void SetPath()
    {
        var rng = new Random();
        rng.Shuffle(pathElementsTransform);
        path = new Vector3[pathElementsTransform.Length];
        for (int i = 0; i < pathElementsTransform.Length; i++)
        {
            path[i] = pathElementsTransform[i].position;
        }
    }
}