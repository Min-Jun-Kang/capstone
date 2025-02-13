﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public static BattleUIManager instance;

    [SerializeField] Text UICycle; // 인스펙터 활용
    [SerializeField] GameObject cancelUsingCardBtn; // button = btn

    public GameObject useCardArea;

    public GameObject deckbutton;
    public GameObject showDeckPanel;

    [Header("Instruction")] // 알림창
    public GameObject instructionBox;
    public Text instructionText;

    [Header("Notice")] // 알림창
    public GameObject noticebox;
    public Text noticetext;

    private WaitForSeconds _UIDelay = new WaitForSeconds(2.3f);


    

    private void Awake()
    {
        showDeckPanel.SetActive(false);
        instructionBox.SetActive(false);
        noticebox.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateCycle(int cycleNum)
    {
        UICycle.text = "Cycle : " + cycleNum.ToString();
    }

    public void EnableCancelUsingCardBtn()
    {
        cancelUsingCardBtn.SetActive(true);
    }
    public void DisableCancelUsingCardBtn()
    {
        cancelUsingCardBtn.SetActive(false);
    }

    public void EnableInstruction(string instruction)
    {
        instructionBox.SetActive(true);
        instructionText.text = instruction;
    }

    public void DisableInstruction()
    {
        instructionBox.SetActive(false);
    }

    public void notice(string message)
    {
        noticetext.text = message;
        noticebox.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(noticeDelay());
    }

    IEnumerator noticeDelay()
    {
        noticebox.SetActive(true);
        yield return _UIDelay;
        noticebox.SetActive(false);
    }

    public void showdeck()
    {
        deckbutton.SetActive(false);
        showDeckPanel.SetActive(true);
        CardManager.instance.DeckTransform.gameObject.SetActive(true);
    }

    public void ShowGrave()
    {
        deckbutton.SetActive(false);
        showDeckPanel.SetActive(true);
        CardManager.instance.GraveTransform.gameObject.SetActive(true);
    }

    public void backtofield()
    {
        deckbutton.SetActive(true);
        showDeckPanel.SetActive(false);
        CardManager.instance.DeckTransform.gameObject.SetActive(false);
        CardManager.instance.GraveTransform.gameObject.SetActive(false);
    }

    public void EnableUseCardArea()
    {
        useCardArea.SetActive(true);
    }

    public void DisableUseCardArea()
    {
        useCardArea.SetActive(false);
    }

    public void EnableChooseResource()
    {

    }

    public void DisableChooseResource()
    {
        
    }
}
