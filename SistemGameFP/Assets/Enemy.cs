using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform target;
    public Transform target2;
    public GameObject QuizCanvas;
    public GameObject Battle;
     public bool iscollidetarget1 = false;
    void Start()
    {
        
        StartCoroutine(TransitionToNextQuestion());
    }

    // Update is called once per frame
    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(0.25f);
       
        Battle.SetActive(true);
        yield return new WaitForSeconds(1f);
        Battle.SetActive(false);
        QuizCanvas.SetActive(true);

    }
    void Update()
    {
        //float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(iscollidetarget1 == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
        if (iscollidetarget1 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target2.position.x, transform.position.y), speed * Time.deltaTime);
        }



    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "StandingPoint")
        {
            //iscollidetarget1 = true;
            Debug.Log("Colliding");
        }
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "MC")
        {

        }
    }*/
    
}
