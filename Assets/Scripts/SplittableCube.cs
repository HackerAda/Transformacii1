using UnityEngine;

public class SplittableCube : MonoBehaviour
{
    public int splitDepth = 0;
    private Renderer rend; 
    private Rigidbody rb;  

    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        if (rend != null)
        {
            rend.material.color = Random.ColorHSV();
        }
    }

    public void SetProperties(int depth, Vector3 scale, Color color)
    {
        splitDepth = depth;
        transform.localScale = scale;
        if (rend != null)
        {
            rend.material.color = color;
        }
    }

    private void OnMouseDown()
    {
        float prob = Mathf.Pow(0.5f, splitDepth);
        if (Random.value < prob)
        {
            int numNew = Random.Range(2, 7);
            Vector3 explosionPos = transform.position;
            float explosionForce = 100f;
            float explosionRadius = 5f;

            for (int i = 0; i < numNew; i++)
            {
                Vector3 offset = Random.insideUnitSphere * 0.5f;
                GameObject newCube = Instantiate(gameObject, transform.position + offset, Quaternion.identity);
                SplittableCube newScript = newCube.GetComponent<SplittableCube>();
                if (newScript != null)
                {
                    newScript.SetProperties(splitDepth + 1, transform.localScale / 2, Random.ColorHSV());
                }
                Rigidbody newRb = newCube.GetComponent<Rigidbody>();
                if (newRb != null)
                {
                    newRb.AddExplosionForce(explosionForce, explosionPos, explosionRadius);
                }
            }
        }
        Destroy(gameObject);
    }
}