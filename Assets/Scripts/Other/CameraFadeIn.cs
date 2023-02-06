using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFadeIn : MonoBehaviour
{
    public void StartFade()
    {
        Player.Instance.FadeIn(0, true);
        StartCoroutine(FadeDelay());
    }
    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Instance.FadeOut(0.5f, false);
    }
}
