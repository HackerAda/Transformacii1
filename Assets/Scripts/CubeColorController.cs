using UnityEngine;

public class CubeColorController
{
    public static void SetRandomColor(MeshRenderer renderer)
    {
        if (renderer != null)
        {
            Color randomColor = Random.ColorHSV();

            renderer.material.color = randomColor;
        }
    }
}   