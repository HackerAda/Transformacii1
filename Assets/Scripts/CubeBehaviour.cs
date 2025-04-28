using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private float _divisionChance = 1.0f;
    [SerializeField] private float _explosionPower = 100f;
    [SerializeField] private float _explosionRadius = 5f;

    private int _minRangeSpawn = 2;
    private int _maxRangeSpawn = 7;

    private CubeSpawner _spawner;
    private CubeExplode _explodeCube;

    public void Initialize(CubeSpawner spawner)
    {
        _spawner = spawner;
        _explodeCube = new CubeExplode();
    }

    public void HandleClick()
    {
        if (_spawner == null)
        {
            Debug.LogError("Спавнер не задан!");
            return;
        }

        if (Random.value < _divisionChance)
        {
            int numberOfCubes = Random.Range(_minRangeSpawn, _maxRangeSpawn);
            List<Cube> newCubes = new List<Cube>();

            for (int i = 0; i < numberOfCubes; i++)
            {
                Cube newCube = _spawner.SpawnCube(transform.position, transform.localScale, _divisionChance);
                newCubes.Add(newCube);
            }

            _explodeCube.Explode(_explosionPower, transform.position, _explosionRadius, newCubes);
        }

        Destroy(gameObject);
    }

    public void SetDivisionChance(float chance)
    {
        _divisionChance = chance;
    }
}