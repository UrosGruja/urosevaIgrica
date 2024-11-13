using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float respownTime = 3.5f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(spawner());

    }

    private void spawnArrow()
    {
        GameObject s = Instantiate(prefab);
        s.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respownTime);
            spawnArrow();
        }
        
    }
}
