using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithAnimation : SceneObject, IScriptableAnimationObject
{
    public virtual void PlayScriptableAnimation()
    {
    }
    public override void OnClicked(InteractHand interactHand)
    {
       PlayScriptableAnimation();
    }
}
