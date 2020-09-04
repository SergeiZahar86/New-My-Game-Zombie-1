using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
        public Vector3 shellPosition;
    }

    private Transform handsTransform;
    private Transform legsTransform;
    private Transform headTransform;
    private Transform bodyTransform;
    private Transform handsShellPositionTransform;
    private Transform handsGunEndPointTransform;
    private Animator handsAnimator;

    private void Awake () // Awake всегда вызывается перед любой функцией Start. Используйте Awake 
    //для инициализации переменных или состояний перед запуском приложения. Unity вызывает Awake 
    //только один раз за время существования экземпляра скрипта.
    {
        bodyTransform = transform.Find ("Body");
        handsTransform = transform.Find ("Hands");
        headTransform = transform.Find ("Head");
        legsTransform = transform.Find ("Legs");
        handsAnimator = handsTransform.GetComponent<Animator> ();
        handsGunEndPointTransform = handsTransform.Find ("GunEndPointPosition");
        handsShellPositionTransform = handsTransform.Find ("ShellPosition");
    }
    private void Update ()
    {
        HandleAiming ();
        HandleShooting ();
        ReversalOfFixedBodyParts (bodyTransform);
        ReversalOfFixedBodyParts (legsTransform);
    }

    private void HandleAiming ()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition ();

        Vector3 handsDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2 (handsDirection.y, handsDirection.x) * Mathf.Rad2Deg;
        handsTransform.eulerAngles = new Vector3 (0, 0, angle);
        headTransform.eulerAngles = new Vector3 (0, 0, angle);

        /////////Разворот спрайта //////////////////////
        Vector3 handsLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            handsLocalScale.y = -1f;
        } else
        {
            handsLocalScale.y = +1f;
        }
        handsTransform.localScale = handsLocalScale;
        headTransform.localScale = handsLocalScale;
        ///////////////////////////////////////////////

    }
    void ReversalOfFixedBodyParts (Transform bodyParts)
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition ();

        Vector3 handsDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2 (handsDirection.y, handsDirection.x) * Mathf.Rad2Deg;

        Vector3 bodyLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            bodyLocalScale.x = -1f;
        }
        else
        {
            bodyLocalScale.x = +1f;
        }
        bodyParts.localScale = bodyLocalScale;
    }

    private void HandleShooting ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition ();

            handsAnimator.SetBool ("Shoot", true);
            OnShoot?.Invoke (this, new OnShootEventArgs
            {
                gunEndPointPosition = handsGunEndPointTransform.position,
                shootPosition = mousePosition, shellPosition = handsShellPositionTransform.position
            });
        }
        else
        {
            handsAnimator.SetBool ("Shoot", false);
        }
        
        /*
        if (Input.GetMouseButtonDown (0))
        {
            handsAnimator.SetBool ("Shoot", true);
        }
        else
        {
            handsAnimator.SetBool ("Shoot", false);

        }*/
    }

    public class UtilsClass
    {
        public static Vector3 GetMouseWorldPosition ()
        {
            Vector3 vec = GetMouseWorldPositionWith (Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPositionWith ()
        {
            return GetMouseWorldPositionWith (Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWith (Camera worldCamera)
        {
            return GetMouseWorldPositionWith (Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWith (Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint (screenPosition);
            return worldPosition;
        }
    }
    
}
