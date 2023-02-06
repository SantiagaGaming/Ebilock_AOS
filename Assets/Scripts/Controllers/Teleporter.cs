using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityAction<string> OnTeleportEnd;
    public bool CanTeleport { get; set; } = true;
    private bool _menu = false;

    [SerializeField] private Transform _menuPosition;
    [SerializeField] private Transform _hallFieldPosition;
    [SerializeField] private Transform _hallFeedPosition;
    [SerializeField] private Transform _hallDspPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallRelay1Position;
    [SerializeField] private Transform _hallRelay2Position;
    [SerializeField] private Transform _hallFromFieldPosition;
    [SerializeField] private Transform _hallFromFeedPosition;
    [SerializeField] private Transform _hallFromDspPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [SerializeField] private Transform _hallFromRelay1Position;
    [SerializeField] private Transform _hallFromRelay2Position;
    [Space]
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private ModeController _modeController;

    private Vector3 _currentPlayerPosition = new Vector3();

    private string _previousLocation;
    public void Teleport(string locationName)
    {
   
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_menuPosition);
         if (locationName == "hall" || locationName == "r_dsp" || locationName == "r_shn" || locationName == "relay1"||  locationName == "relay2" || locationName == "field" || locationName == "feed")
        {
            if (_previousLocation == locationName)
                return;
            Debug.Log(locationName + "From teleport");
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
            else if (locationName == "hall" && _previousLocation == "feed")
            {
                TeleportPlayer(_hallFromFeedPosition);
            }
            else if (locationName == "hall")
            {
                TeleportPlayer(_hallFromFieldPosition);
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
            else if (locationName == "feed")
            {
                TeleportPlayer(_hallFeedPosition);
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
            }
        }
    }
    public void TeleportToMenu()
    {
        if (!_menu)
        {
            _menu = true;
            _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 0.1500001f, _modeController.GetPlayerTransform().position.z); ;
            TeleportPlayer(_menuPosition);
            OnTeleportEnd?.Invoke("menu");
        }
        else
        {
            _menu = false;
            TeleportPlayer(_currentPlayerPosition);
        }
    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }
    private void TeleportPlayer(Vector3 newPos)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPos);
    }
}
