using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float aggroDistance = 30;

    [SerializeField]
    private float _spawnPeriod = 10;

    [SerializeField]
    private Character _enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnProcess());
    }

    IEnumerator SpawnProcess()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnPeriod);
            Character player = Game.Instance.Player.PlayerCharacter;
            Vector3 pos = player.transform.position;
            if (Vector3.Distance(pos, transform.position) < aggroDistance)
            {
                var spawnedEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
