using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplodeCube
{
    public void Explode(float _explosionPower, Vector3 transform, float _explosionRadius, Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(_explosionPower, transform, _explosionRadius);
    }
}

