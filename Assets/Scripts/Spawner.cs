using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] listBlock;
    private void Start() {
        SpawnNewBlock();
    }

    public void SpawnNewBlock()
    {
        Instantiate(listBlock[Random.Range(0,listBlock.Length)], transform.position, Quaternion.identity);
    }
}