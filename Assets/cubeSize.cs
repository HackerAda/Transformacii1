using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSize : MonoBehaviour
{
    [SerializeField] private Vector3 _speedSize;
    void Update()
    {
        transform.localScale += _speedSize * Time.deltaTime;
    }
}
