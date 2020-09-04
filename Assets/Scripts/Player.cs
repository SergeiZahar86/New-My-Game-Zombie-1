using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform handsTransform;
    private Animator handsAnimator;

    private void Awake () // Awake всегда вызывается перед любой функцией Start. Используйте Awake 
    //для инициализации переменных или состояний перед запуском приложения. Unity вызывает Awake 
    //только один раз за время существования экземпляра скрипта.
    {
        handsTransform = transform.Find ("Hands");
        handsAnimator = handsTransform.GetComponent<Animator> ();
    }
    private void Update ()
    {
        HandleAiming ();
        HandleShooting ();
        
    }




    private void HandleAiming ()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition ();

        Vector3 handsDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2 (handsDirection.y, handsDirection.x) * Mathf.Rad2Deg;
        handsTransform.eulerAngles = new Vector3 (0, 0, angle);
    }
    private void HandleShooting ()
    {
        /*
        if (Input.GetMouseButtonDown (0))
        {
            handsAnimator.SetTrigger ("Shoot");
        }
        */
        
        if (Input.GetMouseButtonDown (0))
        {
            handsAnimator.SetBool ("Shoot", true);
        }
        else
        {
            handsAnimator.SetBool ("Shoot", false);

        }
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
