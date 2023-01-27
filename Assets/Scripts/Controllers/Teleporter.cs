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
    [SerializeField] private Transform _hallDspPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallRelay1Position;
    [SerializeField] private Transform _hallRelay2Position;
    [SerializeField] private Transform _hallFromFieldPosition;
    [SerializeField] private Transform _hallFromDspPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [SerializeField] private Transform _hallFromRelay1Position;
    [SerializeField] private Transform _hallFromRelay2Position;
    [Space]
    [SerializeField] private CameraFadeIn _cameraFadeIn;

    private Transform _currentPlayerPosition;

    private string _previousLocation;
    private void Start()
    {
        _currentPlayerPosition = GetComponent<Transform>();
    }
    public void Teleport(string locationName)
    {
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_menuPosition);
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
    public void TeleportToMenu()
    {
        if (!_menu)
        {
            OnTeleportEnd?.Invoke("menu");
            _currentPlayerPosition.position = Player.Instance.transform.position;
            TeleportPlayer(_menuPosition);
        }
        else TeleportPlayer(_currentPlayerPosition);
      

    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }
}
