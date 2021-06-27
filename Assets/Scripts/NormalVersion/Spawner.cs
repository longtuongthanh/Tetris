using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BlockComponent[] listBlock;
    private void Start() {
        SpawnNewBlock();
    }

    public void SpawnNewBlock()
    {
        NormalTetrisController.Instance.currentBlock = Instantiate(listBlock[Random.Range(0,listBlock.Length)], transform.position, Quaternion.identity);
    }
}