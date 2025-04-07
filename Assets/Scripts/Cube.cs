using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
