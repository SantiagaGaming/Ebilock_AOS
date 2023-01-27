using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }

    [SerializeField] private AOSColliderActivator _aosColliderActivator;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private MovingTextWindow _objectsInfoWindow;
    [SerializeField] private LocationController _locationController;

    public AOSColliderActivator AOSColliderActivator => _aosColliderActivator;
    public MovingButtonsController MovingButtonsController => _movinButtonsController;
    public MovingTextWindow ObjectsInfoWindow => _objectsInfoWindow;
    public LocationController LocationController => _locationController;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }

}
