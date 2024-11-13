using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float waitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitAndDestroy());
    }


    IEnumerator WaitAndDestroy()
    {
        if (rb.velocity.y == 0)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(gameObject);
        };
    }
}
