using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoal : Agent
{
    [SerializeField] Material winmat;
    [SerializeField] Material losemat;
   
    //[SerializeField] Vector3 ballpos;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] Transform ballpos;
    [SerializeField] GameObject goal;
    [SerializeField] MeshRenderer agentmesh;
    public MoveBall moveball;
    // Start is called before the first frame update
    void Start()
    {
        moveball = goal.GetComponent<MoveBall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnEpisodeBegin()
    {
        


        transform.localPosition = new Vector3(-7.49472523f, 0.530666351f, -0.0299999993f);
        moveball.EpisodeStarted();
        
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveZ = actions.ContinuousActions[0];
       
        
        transform.localPosition += new Vector3(0, 0, moveZ) * Time.deltaTime* moveSpeed;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(ballpos.localPosition);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(1.0f);

            agentmesh.material = winmat;
            moveball.Collided();
            
            EndEpisode();
        }
        if(other.gameObject.tag == "side wall")
        {
            agentmesh.material = losemat;
            SetReward(-1.0f);
            GoBack();
        }
        
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
       
    }
    public void BallHitBack()
    {
        agentmesh.material = losemat;
        SetReward(-1.0f);
        EndEpisode();
            
    }
    public void GoBack()
    {
        transform.localPosition = new Vector3(-7.49472523f, 0.530666351f, -0.0299999993f);
    }
}
