using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject quadObj;
    public QuadUtility quadUtility;
    public GameObject lineRendererGameObject;

    bool isMenuVisible = false;
    public TextMeshProUGUI showMenuButtonText;
    public GameObject hideMenuButton;
   
    private void Start()
    {
        UpdateButtons();
    }

    public void OnShowMenuButtonClick()
    {
        isMenuVisible = true;
        UpdateButtons();
    }

    public void OnHideMenuButtonClick()
    {
        isMenuVisible = false;
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        hideMenuButton.SetActive(isMenuVisible);
        lineRendererGameObject.SetActive(isMenuVisible);
        quadObj.SetActive(isMenuVisible);
        quadUtility.ResetQuadPosition();

        if (isMenuVisible)
        {
            showMenuButtonText.text = "Reset Menu";
        }
        else
        {
            showMenuButtonText.text = "Show Menu";
        }
    }
}
