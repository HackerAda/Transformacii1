using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeforward : MonoBehaviour
{
    [SerializeField] private Vector3 _movementDirection;
    void Update()
    {
        transform.Translate(_movementDirection, Space.World);
    }
}
