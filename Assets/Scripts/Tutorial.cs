using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using PrimalEra;
using TMPro;
using UnityEngine.SceneManagement;
using Utility;

public class Tutorial : Instancable<Tutorial>
{
    [SerializeField] private List<string> sentences;
    private int sentenceIndex;
    public TextMeshProUGUI textArea;
    [SerializeField] private Color colorAlphaZero, colorAlphaHundred;
    public bool canStart;

    private void OnEnable()
    {
        if(canStart)
            StartCoroutine(IterateSentence());
    }

    public IEnumerator IterateSentence()
    {
        yield return new WaitForSeconds(3f);
        var sequence = DOTween.Sequence()
            .Append(textArea.DOColor(colorAlphaHundred, 1f))
            .Append(textArea.DOColor(colorAlphaZero,1f).SetDelay(1f))
            .OnComplete(() =>
            {
                if (sentenceIndex >= sentences.Count - 1)
                {
                    if (SceneManager.GetActiveScene().name == "PrimalWorld")
                    {
                        FightManager.Instance.startAllOverButton.SetActive(true);
                        PlayerPrefs.SetInt("AnimalIndex",0);
                    }
                    return;
                }
                
                sentenceIndex++;
                textArea.text = sentences[sentenceIndex];
                StartCoroutine(IterateSentence());
            });
        
    }
}
