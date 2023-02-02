using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabableObject : MonoBehaviour, IHandObject
{
    public void HandAction()
    {
      gameObject.SetActive(false);
    }
}
