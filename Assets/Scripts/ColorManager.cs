using UnityEngine;

public static class ColorManager
{
    public static void SetRandomColor(MeshRenderer renderer)
    {
        if (renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}   