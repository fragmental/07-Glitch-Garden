using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    //[Range (-1, 1.5f)]
    private float currentSpeed;
    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private GameObject currentTarget;
    //public Rigidbody2D myRigidbody;
    private Animator animator;
    
    void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        myRigidbody.isKinematic = true;
        //myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        //Debug.Log(name + " caused damage: " + damage);
        if (currentTarget)
        { 
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
    }

    /// <summary>
    /// Called from the animator at the time of actual blow
    /// </summary>
    /// <param name="obj"></param>
    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }
}
