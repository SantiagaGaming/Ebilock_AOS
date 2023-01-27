using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;
using TMPro;

public class MainMenuCanvas : BaseCanvas
{
    [SerializeField] private GameObject[] _allMenuScreens;
    [SerializeField] private GameObject _mainMenuScreen;
    [Space]
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    public void ShowMainMenuScreen(bool value)
    {
          foreach (var screen in _allMenuScreens)
        {
            screen.SetActive(false);
        }
        if(value)
        _mainMenuScreen.SetActive(true);
    }
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }

    public void SetExitText(string exitText, string warntext)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }
}
