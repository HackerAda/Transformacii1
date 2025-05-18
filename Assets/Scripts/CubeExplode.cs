using System.Collections.Generic;
using UnityEngine;

public static class CubeExplode
{
    public static void Explode(float explosionPower, Vector3 explosionPosition, float explosionRadius, List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rb = cube.Rigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(explosionPower, explosionPosition, explosionRadius);
            }
        }
    }
}