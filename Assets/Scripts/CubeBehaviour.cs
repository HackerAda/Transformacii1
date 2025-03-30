using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private float _divisionChance = 1.0f;
    private CubeSpawner _spawner;

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