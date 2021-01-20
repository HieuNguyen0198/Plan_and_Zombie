using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0f, 5f)]
    [SerializeField] float speed;
    float currentSpeed = 1f;
    float defaultSpeed = 0;
    bool attacking = false;
    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
        defaultSpeed = speed;
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

    public float getSpeed()
    {
        return speed;
    }

    //lam cham
    public void SetSlowMomentSpeed()
    {
        //defaultSpeed = speed;
        speed = defaultSpeed/2;
        StartCoroutine(LateCall());
    }
    
    //bi choang
    public void SetStun()
    {
        //defaultSpeed = speed;
        speed = 0;
        currentSpeed = 0;
        StartCoroutine(LateCall());
    }

    //tu hoi phuc sau 3s
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(3f);
        if (GetComponent<Animator>().GetBool("IsAttacking") == false)
        {
            speed = defaultSpeed;
            currentSpeed = defaultSpeed;
        }      
    }

    //dung im
    public void Set0()
    {
        currentSpeed = 0;
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
            //attacking = false;
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
        //attacking = true;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) 
        {
            //attacking = false;
            return; 
        }
        attacking = true;
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
