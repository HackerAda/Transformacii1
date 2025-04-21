using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeColorController : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer != null)
        {
            Color randomColor = Random.ColorHSV();

            _renderer.material.color = randomColor;
        }
    }
}   