using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectResizing : MonoBehaviour
{
    [SerializeField] private Vector3 _speedSize;

    private void Update()
    {
        transform.localScale += _speedSize * Time.deltaTime;
    }
}
