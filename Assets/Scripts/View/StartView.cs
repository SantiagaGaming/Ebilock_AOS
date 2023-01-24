using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartView : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private NextButton _nextButton;
    private void OnEnable()
    {
        _nextButton.OnNextButtonPressed += OnHideStartScreen;
    }
    private void OnDisable()
    {
        _nextButton.OnNextButtonPressed -= OnHideStartScreen;
    }
    public void EnableStartScreen(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _startScreen.SetActive(true);
        _headerText.text = headerText;
        _commentText.text = commentText;
        _nextButtonText.text = buttonText;
        _nextButton.CurrentState = state;
    }
    private void OnHideStartScreen(string value)
    {
        if (value == "start")
            _startScreen.SetActive(false);
    }
}
