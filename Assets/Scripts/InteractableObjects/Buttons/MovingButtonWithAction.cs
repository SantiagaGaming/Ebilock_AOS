using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButtonWithAction : MovingButton
{
    public UnityAction<int> ButtonNumberEvent;
    [SerializeField] private ButtonActionName _currentAction;
    private enum ButtonActionName
    {
        Hand,
        Eye,
        Tool,
        Pen,
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_currentAction == ButtonActionName.Hand)
        {
           InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand");
            //MovingButtonsController.Instance.PlayPushAnimation();
            ButtonNumberEvent?.Invoke(1);
        }
        else if (_currentAction == ButtonActionName.Eye)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("eye");
        }

        else if (_currentAction == ButtonActionName.Tool)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("tool");
            //MovingButtonsController.Instance.PlayToolAnimation();
        }
        else if (_currentAction == ButtonActionName.Pen)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("pen");
        }

    }

}
