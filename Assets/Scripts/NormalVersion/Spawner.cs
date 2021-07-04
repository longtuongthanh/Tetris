using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BlockComponent[] listBlock;

    public void SpawnNewBlock()
    {
        NormalTetrisController.Instance.SpawnBlock(Instantiate(listBlock[Random.Range(0,listBlock.Length)], transform.position, Quaternion.identity));
    }
}