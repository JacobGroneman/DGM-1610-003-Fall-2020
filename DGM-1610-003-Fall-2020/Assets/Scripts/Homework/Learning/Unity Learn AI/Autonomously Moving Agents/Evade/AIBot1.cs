using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBot1 : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _target;
    
    void Start()
    {
        _target = GameObject.Find("target");
        _agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Evade();
    }

    void Seek(Vector3 location)
    {
        _agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        _agent.SetDestination(this.transform.position - fleeVector);
    }

    void Pursue()
    {
        Vector3 targetDirection = _target.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward,
            this.transform.TransformVector(_target.transform.forward));
        float toTarget = Vector3.Angle
            (this.transform.forward, this.transform.TransformVector(targetDirection));
            
        if (toTarget > 90 && relativeHeading < 20 ||_target.GetComponent<sfDrive>().currentSpeed < .01f)
        {
            Seek(_target.transform.position);
            return;
        }
        
        float lookAhead = 
            targetDirection.magnitude /
            (_agent.speed + _target.GetComponent<sfDrive>().currentSpeed);
        Seek(_target.transform.position + _target.transform.forward * lookAhead);
    }

    void Evade()
    {//(Opposite of Pursuit)
        Vector3 targetDirection = _target.transform.position - this.transform.position;
        float lookAhead = 
            targetDirection.magnitude /
            (_agent.speed + _target.GetComponent<sfDrive>().currentSpeed);
        Flee(_target.transform.position + _target.transform.forward * lookAhead);
    }
}
