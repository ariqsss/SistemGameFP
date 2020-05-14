using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform target;
    public GameObject QuizCanvas;
    public GameObject Battle;
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
        
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            
       
    }
}
