using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<string> sentences;
    private int sentenceIndex;
    public TextMeshProUGUI textArea;
    [SerializeField] private Color colorAlphaZero, colorAlphaHundred;

    private void Start()
    {
        StartCoroutine(IterateSentence());
    }

    private IEnumerator IterateSentence()
    {
        yield return new WaitForSeconds(3f);
        var sequence = DOTween.Sequence()
            .Append(textArea.DOColor(colorAlphaHundred, 1f))
            .Append(textArea.DOColor(colorAlphaZero,1f).SetDelay(1f))
            .OnComplete(() =>
            {
                if (sentenceIndex >= sentences.Count - 1) return;
                
                sentenceIndex++;
                textArea.text = sentences[sentenceIndex];
                StartCoroutine(IterateSentence());
            });
        
    }
}
