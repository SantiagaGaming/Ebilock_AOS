using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _hallFieldPosition;
    [SerializeField] private Transform _hallDspPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallRelay1Position;
    [SerializeField] private Transform _hallRelay2Position;
    [SerializeField] private Transform _hallFromFieldPosition;
    [SerializeField] private Transform _hallFromDspPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [SerializeField] private Transform _hallFromRelay1Position;
    [SerializeField] private Transform _hallFromRelay2Position;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    private void Start()
    {
        Teleport("r_dsp");
    }


    public UnityAction<string> OnTeleportEnd;

    private string _previousLocation;
    public void Teleport(string locationName)
    {
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_startPosition);
         if (locationName == "hall" || locationName == "r_dsp" || locationName == "r_shn" || locationName == "relay1"||  locationName == "relay2" || locationName == "field")
        {
            if (_previousLocation == locationName)
                return;
            if (locationName == "hall" && _previousLocation == "r_dsp")
            {
                TeleportPlayer(_hallFromDspPosition);
            }
            else if (locationName == "hall" && _previousLocation == "field")
            {
                TeleportPlayer(_hallFromFieldPosition);
            }
            else if (locationName == "hall" && _previousLocation == "r_shn")
            {
                TeleportPlayer(_hallFromShnPosition);
            }
            else if (locationName == "hall" && _previousLocation == "relay1")
            {
                TeleportPlayer(_hallFromRelay1Position);
            }
            else if (locationName == "hall" && _previousLocation == "relay2")
            {
                TeleportPlayer(_hallFromRelay2Position);
            }
            else if (locationName == "field")
            {
                TeleportPlayer(_hallFieldPosition);
            }
            else if (locationName == "r_dsp")
            {
                TeleportPlayer(_hallDspPosition);
            }
            else if (locationName == "r_shn")
            {
                TeleportPlayer(_hallShnPosition);
            }
            else if (locationName == "relay1")
            {
                TeleportPlayer(_hallRelay1Position);
            }
            else if (locationName == "relay2")
            {
                TeleportPlayer(_hallRelay2Position);
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
            }
        }
    }

    private void TeleportPlayer(Transform newPosition)
    {
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }

}
