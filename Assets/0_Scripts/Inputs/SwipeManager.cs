using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class SwipeManager : MonoBehaviour
{
    public static SwipeManager instance;

    public delegate void StartTouch(Vector2 position);
    public event StartTouch OnStartTouch;

    public delegate void UpdateTouch(Vector2 position);
    public event UpdateTouch OnUpdateTouch;

    public delegate void EndTouch(Vector2 position);
    public event EndTouch OnEndTouch;

    Action _ArtificialUpdate;
    Camera _cam;
    int _idTouch;
    Vector2 _actualPos;
    bool _started;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _cam = Camera.main;
        _ArtificialUpdate = StartTouchPrimary;
    }

    private void Update()
    {
        _ArtificialUpdate();
    }

    void StartTouchPrimary()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            _idTouch = touch.fingerId;

            _actualPos = GetWorldPositionPlane(touch.position);

            if (OnStartTouch != null)
                OnStartTouch(_actualPos);

            _ArtificialUpdate = UpdateTouchPrimary;
        }
    }

    void UpdateTouchPrimary()
    {
        if (Input.touchCount > 0)
        {
            if (OnUpdateTouch != null)
            {
                var touch = Input.GetTouch(0);

                if (touch.fingerId == _idTouch)
                {
                    _actualPos = GetWorldPositionPlane(touch.position);
                    OnUpdateTouch(_actualPos);
                }
                else
                    _ArtificialUpdate = EndTouchPrimary;
            }
        }
        else
            _ArtificialUpdate = EndTouchPrimary;
    }

    void EndTouchPrimary()
    {
        if (OnEndTouch != null)
            OnEndTouch(_actualPos);

        _ArtificialUpdate = StartTouchPrimary;
    }

    Vector3 GetWorldPositionPlane(Vector3 screenPos)
    {
        if (_cam.orthographic) 
            return _cam.ScreenToWorldPoint(screenPos);

        Ray ray = _cam.ScreenPointToRay(screenPos);
        Plane xy = new Plane(Vector3.forward, Vector3.zero);
        float dist;
        xy.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
}
