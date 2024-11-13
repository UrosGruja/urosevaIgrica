using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	// Start is called before the first frame update
	private GameObject spawnLocation;
	[SerializeField] GameObject[] objectToSpawn;
	[SerializeField] private float timeBetweenSpawns = 3.0f;
	[SerializeField] private float minTras = -10;
	[SerializeField] private float maxTras = 10;


	void Start()
	{
		StartCoroutine(spawnObjects());
	}

	IEnumerator spawnObjects()
    {
		while (true)
		{
			var wanted = Random.Range(minTras, maxTras);
			var position = new Vector3(wanted, transform.position.y);
			yield return new WaitForSeconds(timeBetweenSpawns);
			GameObject spawnedObject;
			spawnedObject = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], position, Quaternion.identity);
		}
	}
}
