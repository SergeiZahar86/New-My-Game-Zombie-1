using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float offset;
    private Transform headTransform;

    private void Awake ()
    {
        //headTransform = transform.Find ("Head");
    }

    private void Update ()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (0f, 0f, rotZ + offset);

        //headTransform.eulerAngles = new Vector3 (0, 0, rotZ);



    }

}
