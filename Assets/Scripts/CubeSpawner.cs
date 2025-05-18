using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _spawnRadius = 0.5f;

    private int _spawnPositionStartX = 8;
    private int _spawnPositionStartY = 0;
    private int _spawnPositionStartZ = 4;
    private int _startCubesAmount = 4;
    private float _startCubesDivisionChance = 1f;
    private float _sizeReduction = 0.5f;
    private float _decreaseChance = 2f;

    private void Start()
    {
        for (int i = 0; i < _startCubesAmount; i++)
        {
            Vector3 startCubesPosition = new Vector3(_spawnPositionStartX + i, _spawnPositionStartY, _spawnPositionStartZ + i);
            CreateRegularCube(startCubesPosition, _startCubesDivisionChance);
        }
    }

    public Cube SpawnCube(Vector3 position, Vector3 scale, float divisionChance)
    {
        Vector3 spawnPosition = position + Random.insideUnitSphere * _spawnRadius;
        Cube newCube = CreateRegularCube(spawnPosition, divisionChance / _decreaseChance);
        newCube.transform.localScale = scale * _sizeReduction;
        return newCube;
    }

    private Cube CreateRegularCube(Vector3 position, float divisionChance)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Random.rotation);
        newCube.SetDivisionChance(divisionChance);
        newCube.OnClicked += HandleCubeClick;
        return newCube;
    }

    private void HandleCubeClick(Cube cube)
    {
        cube.OnClicked -= HandleCubeClick;
        if (Random.value < cube.DivisionChance)
        {
            int numberOfCubes = Random.Range(2, 7);
            List<Cube> newCubes = new List<Cube>();

            for (int i = 0; i < numberOfCubes; i++)
            {
                Cube newCube = SpawnCube(cube.transform.position, cube.transform.localScale, cube.DivisionChance);
                newCubes.Add(newCube);
            }

            CubeExplode.Explode(100f, cube.transform.position, 5f, newCubes);
        }

        Destroy(cube.gameObject);
    }
}