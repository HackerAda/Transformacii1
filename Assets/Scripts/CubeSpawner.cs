using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] public Cube _cubePrefab;
    [SerializeField] private float _spawnRadius = 0.5f;
    [SerializeField] private float _explosionPower = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    private int _minRangeSpawn = 2;
    private int _maxRangeSpawn = 7;
    private int spawnPositionStartX = 8;
    private int spawnPositionStartY = 0;
    private int spawnPositionStartZ = 4;
    private int startCubesAmount = 4;
    private float _sizeReduction = 0.5f;
    private float _decreaseСhance = 2f;

    private void Awake()
    {
        
        Vector3 spawnPositionStart = new Vector3(8, 0, 4);

        for (int i = 0; i < startCubesAmount; i++)
        {
            spawnPositionStart = new Vector3(spawnPositionStartX + i, spawnPositionStartY, spawnPositionStartZ + i);
            Cube newCube = Instantiate(_cubePrefab, spawnPositionStart, Random.rotation);

            CubeBehaviour cubeBehavior = newCube.GetComponent<CubeBehaviour>();
            cubeBehavior.Initialize(this);
        }
    }

    public void SpawnCubes(Vector3 position, Vector3 scale, float divisionChance)
    {
        int numberOfCubes = Random.Range(_minRangeSpawn, _maxRangeSpawn);

        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 spawnPosition = position + Random.insideUnitSphere * _spawnRadius;
            Cube newCube = Instantiate(_cubePrefab, spawnPosition, Random.rotation);

            CubeBehaviour cubeBehavior = newCube.GetComponent<CubeBehaviour>();
            cubeBehavior.Initialize(this);

            newCube.transform.localScale = scale * _sizeReduction;
            CubeColorController.SetRandomColor(newCube.GetComponent<MeshRenderer>());

            cubeBehavior.SetDivisionChance(divisionChance / _decreaseСhance);

            Explode(_explosionPower, position, _explosionRadius, newCube.Rigidbody);
        }
    }

    private void Explode(float _explosionPower, Vector3 transform, float _explosionRadius, Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(_explosionPower, transform, _explosionRadius);
    }
}