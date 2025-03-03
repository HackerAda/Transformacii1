using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private int _rotationSpeed;

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed, 0);
    }
}
