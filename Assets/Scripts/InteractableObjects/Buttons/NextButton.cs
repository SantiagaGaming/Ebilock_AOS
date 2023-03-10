using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextButton : BaseButton
{
    public UnityAction<string> OnNextButtonPressed;
    [HideInInspector] public NextButtonState CurrentState;
    [SerializeField] private API _api;
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
            _api.OnInvokeNavAction("next");
            OnNextButtonPressed?.Invoke("next");
            Player.Instance.CanMove = false;
        }
        else if (CurrentState == NextButtonState.Fault)
        {
            _api.OnInvokeNavAction("start");
            OnNextButtonPressed?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
