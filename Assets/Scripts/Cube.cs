using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _divisionChance = 1.0f;
    public float DivisionChance => _divisionChance;

    public Rigidbody Rigidbody { get; private set; }
    public event Action<Cube> OnClicked;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseDown()
    {
        OnClicked?.Invoke(this);
    }

    public void SetDivisionChance(float chance)
    {
        _divisionChance = chance;
    }
}