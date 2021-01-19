using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 5f)]
    [SerializeField] float speed;
    float defaultSpeed =  0;
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    public void SetMovementSpeed()
    {
        currentSpeed = speed;
    }

    //lam cham
    public void SetSlowMomentSpeed()
    {
        defaultSpeed = speed;
        speed = speed / 4;
        //currentSpeed = speed;
    }
    
    //bi choang
    public void SetStun()
    {
        defaultSpeed = speed;
        speed = 0;
        currentSpeed = 0;
    }

    //dung im
    public void Set0()
    {
        currentSpeed = 0;
    }

    //khoi phuc
    public void DefaultSpeed()
    {
        speed = defaultSpeed;
    }


    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationSate();
    }

    private void UpdateAnimationSate()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
