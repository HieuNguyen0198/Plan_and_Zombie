using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    bool spawn = true;
    bool final = false;

    IEnumerator Start()
    {
        while (spawn)
        {
            if(!final)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                SpawnAttacker();
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1f, 1f));
                SpawnAttacker();
            }
        }
    }

    public void StopSpawning()
    {
        spawn = false;
        final = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

   private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    //tang do kho
    public void FinalWave()
    {
        final = true;
    }
}
