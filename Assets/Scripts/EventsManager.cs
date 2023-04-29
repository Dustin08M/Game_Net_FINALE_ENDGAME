using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private static EventsManager instance;
    public static EventsManager Instance { get { return instance; } }

    public delegate void PortalEvent();
    public static event PortalEvent onKnifePortal = delegate { };
    public static event PortalEvent onAxePortal = delegate { };
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void KnifePortal()
    {
        onKnifePortal?.Invoke();
    }
    public void AxePortal()
    {
        onAxePortal?.Invoke();
    }
}
