using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GestureManager : MonoSingleton<GestureManager>
{
    private GestureRecognizer gestures = null;

    private GameObject focusedObject = null;

    // Use this for initialization
    void Start()
    {
        InitializeGestures();
	}
	
	// Update is called once per frame
	void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f))
        {
            focusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            focusedObject = null;
        }
    }

    private void InitializeGestures()
    {
        gestures = new GestureRecognizer();

        gestures.TappedEvent += (source, tapCount, ray) =>
        {
            // single tap
            if (focusedObject != null)
            {
                GlobalSounds.Instance.Play("Lasershot", 0f);
                focusedObject.SendMessage("OnHit");
            }
        };

        gestures.NavigationStartedEvent += (source, normalizedOffset, headRay) =>
        {
        };

        gestures.NavigationUpdatedEvent += (source, normalizedOffset, headRay) =>
        {
        };

        gestures.NavigationCompletedEvent += (source, normalizedOffset, headRay) =>
        {
        };

        gestures.StartCapturingGestures();
    }

    public GameObject FocusedObject
    {
        get
        {
            return focusedObject;
        }
    }
}
