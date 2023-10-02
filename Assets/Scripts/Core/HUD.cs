using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    Canvas parentCanvas;

    CanvasGroup parentCanvasGroup;

    private void Awake()
    {
        parentCanvas = GetComponent<Canvas>();
        parentCanvasGroup = GetComponent<CanvasGroup>();
    }


    public void HideCanvas()
    {
        parentCanvasGroup.alpha = 0;
        parentCanvasGroup.interactable = false;
        parentCanvasGroup.blocksRaycasts = false;
    }

    public void ShowCanvas()
    {
        parentCanvasGroup.alpha = 1;
        parentCanvasGroup.interactable = true;
        parentCanvasGroup.blocksRaycasts = true;
    }



}
