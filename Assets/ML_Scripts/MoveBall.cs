using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float BallMoveSpeed = 100.0f;
    [SerializeField] GameObject player;
    MoveToGoal moveToGoal;
    public bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        moveToGoal = player.GetComponent<MoveToGoal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  void EpisodeStarted()
    {
       
        transform.localPosition= new Vector3(-2.55472565f, 0.640666008f, Random.Range(-1.78f, 1.56f));
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.angularDrag = 0f;
            rb.AddForce(Vector3.left * BallMoveSpeed );
            //transform.Translate
          

        

        
        
    }

    
    public void EpisodeEnded()
    {

    }
    public void Collided()
    {
        hasCollided = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "back wall")
        {
            moveToGoal.BallHitBack();
        }
    }
}
