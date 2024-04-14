using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Assertions;

public class UiManager : MonoBehaviour
{
    public bool finishCd;

    [SerializeField] TextMeshProUGUI countdownText;

    [SerializeField] CanvasGroup menuUI;

    [SerializeField] CanvasGroup gameUI;

    [SerializeField] CanvasGroup optionUI;

    Sequence countdownSequence;
    private void Awake()
    {
        Assert.IsNotNull(countdownText, "Please set countdown text");
        Assert.IsNotNull(menuUI, "Please set menu canvas group");
        countdownText.text = "";
        ResetUi();    
    }

    private void ResetUi()
    {
        gameUI.alpha = 0f;
        gameUI.interactable = false;
        gameUI.blocksRaycasts = false;

        optionUI.alpha = 0f;
        optionUI.interactable = false;
        optionUI.blocksRaycasts = false;

        menuUI.alpha = 1f;
        menuUI.interactable = true;
        menuUI.blocksRaycasts = true;
    }

    public void ToggleOptionMenu(bool toogle)
    {
        if (toogle)
        {
            SoundManager.instance.PlayClip(2);
            ToggleMenuUi(false);
            optionUI.DOFade(1, 0.3f);
            optionUI.interactable = true;
            optionUI.blocksRaycasts = true;
        }
        else
        {
            if (GameManager.instance.stateMachine.currentState.ToString() == GameStateMachine.EGameState.MenuState.ToString())
            {
                ToggleMenuUi(true);
            }
            SoundManager.instance.PlayClip(2);
            optionUI.DOFade(0, 0.3f);
            optionUI.interactable = false;
            optionUI.blocksRaycasts = false;
        }
    }

    void ToggleMenuUi(bool toogle)
    {
        if (toogle)
        {
            menuUI.DOFade(1, 0.3f);
            menuUI.interactable = true;
            menuUI.blocksRaycasts = true;
        }
        else
        {
            menuUI.DOFade(0, 0.3f);
            menuUI.interactable = false;
            menuUI.blocksRaycasts = false;
        }
    }

    public void ToggleGameUi(bool toogle)
    {
        if (toogle)
        {
            gameUI.DOFade(1, 0.3f);
            gameUI.interactable = true;
            gameUI.blocksRaycasts = true;
        }
        else
        {
            gameUI.DOFade(0, 0.3f);
            gameUI.interactable = false;
            gameUI.blocksRaycasts = false;
        }
    }

    public void StartGameCountdown()
    {
        ToggleMenuUi(false);
        finishCd = false;
        countdownText.DOFade(1, 0);

        countdownText.text = "3";
        countdownText.rectTransform.localScale = Vector3.zero;

        countdownSequence = DOTween.Sequence();
        countdownSequence.AppendCallback(() => { SoundManager.instance.PlayClip(0); });
        countdownSequence.Append(countdownText.rectTransform.DOScale(1f, 0.5f));
        countdownSequence.AppendInterval(0.3f);
        countdownSequence.Append(countdownText.rectTransform.DOScale(2, 0.5f));
        countdownSequence.Join(countdownText.DOFade(0, 0.5f));
        countdownSequence.AppendCallback(() =>
        {

            countdownText.text = "2";
            countdownText.rectTransform.localScale = Vector3.zero;
            countdownText.DOFade(1, 0);
        });

        countdownSequence.AppendCallback(() => { SoundManager.instance.PlayClip(0); });
        countdownSequence.Append(countdownText.rectTransform.DOScale(1, 0.5f));
        countdownSequence.AppendInterval(0.3f);
        countdownSequence.Append(countdownText.rectTransform.DOScale(2, 0.5f));
        countdownSequence.Join(countdownText.DOFade(0, 0.5f));
        countdownSequence.AppendCallback(() =>
        {
            countdownText.text = "1";
            countdownText.rectTransform.localScale = Vector3.zero;
            countdownText.DOFade(1, 0);
        });

        countdownSequence.AppendCallback(() => { SoundManager.instance.PlayClip(0); });
        countdownSequence.Append(countdownText.rectTransform.DOScale(1f, 0.5f));
        countdownSequence.AppendInterval(0.3f);
        countdownSequence.Append(countdownText.rectTransform.DOScale(2, 0.5f));
        countdownSequence.Join(countdownText.DOFade(0, 0.5f));
        countdownSequence.AppendCallback(() =>
        {
            countdownText.text = "GO";
            countdownText.rectTransform.localScale = Vector3.zero;
            countdownText.DOFade(1, 0);

        });

        countdownSequence.AppendCallback(() => { SoundManager.instance.PlayClip(1); });
        countdownSequence.Append(countdownText.rectTransform.DOScale(1f, 0.5f));
        countdownSequence.AppendInterval(0.3f);
        countdownSequence.Append(countdownText.rectTransform.DOScale(2, 0.5f));
        countdownSequence.Join(countdownText.DOFade(0, 0.5f));
        countdownSequence.AppendCallback(() =>
        {
            countdownText.rectTransform.localScale = Vector3.zero;
            countdownText.DOFade(1, 0);
            finishCd = true;
            ToggleGameUi(true);
        });
    }
}


