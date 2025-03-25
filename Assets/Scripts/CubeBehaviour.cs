using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private float _divisionChance = 1.0f;
    private CubeSpawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<CubeSpawner>();
        if (_spawner == null)
        {
            Debug.LogError("CubeSpawner не найден в Awake!");
        }

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        ColorManager.SetRandomColor(renderer);
    }

    private void OnMouseDown()
    {
        if (Random.value < _divisionChance)
        {
            _spawner.SpawnCubes(transform.position, transform.localScale, _divisionChance);
        }

        Destroy(gameObject);
    }

    public void SetDivisionChance(float chance)
    {
        _divisionChance = chance;
    }
}