using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] private Transform _buttonsPos;
    private IHandObject _handObject;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (_buttonsPos == null)
            return;
        InstanceHandler.Instance.MovingButtonsController.SetCurrentBaseObjectAndMovingButtonsPosition(_buttonsPos.position, this);
        InstanceHandler.Instance.MovingButtonsController.ObjectHelperName = HelperName;
        InstanceHandler.Instance.MovingButtonsController.HandObject = null;
        _handObject = GetComponent(typeof(IHandObject)) as IHandObject;
        if (_handObject != null)
            InstanceHandler.Instance.MovingButtonsController.HandObject = _handObject;
    }
}
