using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOSColliderActivator : MonoBehaviour
{
    private List<SceneObject> _aosSceneObjects = new List<SceneObject>();
    public bool CanTouch { get; set; } = true;
    public void AddBaseObject(SceneObject obj)
    {
        _aosSceneObjects.Add(obj);
    }
    public void ActivateColliders(string objectName, string text)
    {
        foreach (var item in _aosSceneObjects)
        {
            if (item.GetAOSName() == objectName)
            {
                item.EnableObject(true);
                item.SetHelperName(text);
            }
        }
    }
    public void DeactivateAllColliders()
    {
        foreach (var item in _aosSceneObjects)
        {
            item.EnableObject(false);
        }
    }
}
