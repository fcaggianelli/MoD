using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform targetLeft;
    public Transform targetRight;

    public Transform spawnPoint;

    public GameObject prefab;
    public Texture2D ironSight;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(ironSight, Vector2.zero, CursorMode.Auto);
        StartCoroutine(SpawnGeneratoreLeft());
        StartCoroutine(SpawnGeneratoreRight());
    }

    private IEnumerator SpawnGeneratoreLeft()
    {
        while (true)
        {
            Target t = Instantiate(prefab).GetComponent<Target>();
            t.transform.position = spawnPoint.transform.position;
            t.Initialize(targetRight, Random.Range(2, 7), false);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private IEnumerator SpawnGeneratoreRight()
    {
        while (true)
        {
            Target t = Instantiate(prefab).GetComponent<Target>();
            t.transform.position = spawnPoint.transform.position;
            t.Initialize(targetLeft, Random.Range(2,7), true);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
}
