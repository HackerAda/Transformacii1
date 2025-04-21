using UnityEngine;

[RequireComponent(typeof(CubeBehaviour))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] public Cube _cubePrefab;
    [SerializeField] private float _spawnRadius = 0.5f;

    private int _spawnPositionStartX = 8;
    private int _spawnPositionStartY = 0;
    private int _spawnPositionStartZ = 4;
    private int _startCubesAmount = 4;
    private float _startCubesDivisionChance = 1f;
    private float _sizeReduction = 0.5f;
    private float _decreaseСhance = 2f;

    private void Start()
    {
        for(int i = 0; i < _startCubesAmount; i++)
        {
            Vector3 startCubesPosition = new Vector3(_spawnPositionStartX + i, _spawnPositionStartY, _spawnPositionStartZ + i);
            CreatingRegularCubes(startCubesPosition, _startCubesDivisionChance);
        }
    }

    public Cube SpawnCube(Vector3 position, Vector3 scale, float divisionChance)
    {
        Vector3 spawnPosition = position + Random.insideUnitSphere * _spawnRadius;

        Cube newCube = CreatingRegularCubes(spawnPosition, divisionChance / _decreaseСhance);

        newCube.transform.localScale = scale * _sizeReduction;

        return newCube;
    }

    private Cube CreatingRegularCubes(Vector3 position, float divisionChance)
    {
        Cube newCube = InstantiateCube(_cubePrefab, position);

        CubeBehaviour cubeBehavior = newCube.GetComponent<CubeBehaviour>();
        cubeBehavior.Initialize(this);

        cubeBehavior.SetDivisionChance(divisionChance);
        return newCube;
    }

    public Cube InstantiateCube(Cube cubePrefab, Vector3 position)
    {
        Cube newCube = Instantiate(cubePrefab, position, Random.rotation);
        return newCube;
    }
}