using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed - (ItemCollector.points / ItemCollector.nextLevel * 2f), 0);
    }
}
