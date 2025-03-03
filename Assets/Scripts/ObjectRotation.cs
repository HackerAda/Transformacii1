using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed;

    public void Update()
    {
        transform.Rotate(0, _rotationSpeed, 0);
    }
}
