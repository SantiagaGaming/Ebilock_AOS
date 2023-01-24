using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "�������")]
public class ConnectionChecker : AosObjectBase
{
    [AosEvent(name: "����� � �����������")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    public UnityAction OnConnectionReady;

    public void OnConnect()
    {
        OnReadyToAction.Invoke("Ready to Action");
        OnConnectionReady?.Invoke();
    }
}
