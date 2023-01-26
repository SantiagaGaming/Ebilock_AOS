using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButton : BaseButton
{
    [SerializeField] protected string actionText;
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.5f;
        if (helperPos != null)
        {
            InstanceHandler.Instance.CanvasObjectHelperController.ShowTextHelper(actionText, helperPos);
        }
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.5f;
        if (helperPos != null)
            InstanceHandler.Instance.CanvasObjectHelperController.HidetextHelper();
    }
    public void SetActionText(string text)
    {
        actionText = text;
    }
}
