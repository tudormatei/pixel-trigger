using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForceObjects : MonoBehaviour
{
    private float constForce = 15f;

    void Update()
    {
        this.transform.Translate(-Vector3.right * Time.deltaTime * constForce);
    }
}
