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
    //
    int phase = 0;

    IEnumerator Start()
    {
        while (spawn)
        {
            if (!final)
            {
                if (phase == 2)
                {
                    yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
                    SpawnAttacker();
                }
                else if (phase == 3)
                {
                    yield return new WaitForSeconds(Random.Range(1f, maxSpawnDelay - 3f));
                    SpawnAttacker();
                }
                else
                {
                    //phase 1
                    yield return new WaitForSeconds(Random.Range(3f, 30f));
                    SpawnAttacker();
                }
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
    public void phase2()
    {
        phase = 2;
    }

    public void phase3()
    {
        phase = 3;
    }


    public void FinalWave()
    {
        final = true;
    }
}
