using System.Collections;
using UnityEngine;

// Moves the agent toward it's target
public class PursuitState : OverworldState
{
    public Transform target;
    public Vector3 oldTarget;
    public PursuitState(OverworldStateSystem system) : base(system)
    {
    }
    public override IEnumerator Start()
    {
        target = _system.fov.GetTargetFromTag("Player");
        _system.target = target;
        if (target == null)
        {
            Debug.LogError("Something really dungooffed");
        }
        oldTarget = target.position;
        _system.fov.viewRadius = _system.targetedSightDistance;
        yield break;
    }
    public override IEnumerator Move()
    {
        //do xyz
        target = _system.fov.GetTargetFromTag("Player");
        if (target != null)
        {
            oldTarget = target.position;
            _system.nav.SetDestination(target.position);
        }
        else
        {
            _system.nav.SetDestination(oldTarget);
            if (_system.nav.remainingDistance<0.1f)
            {
                _system.target = null;
                _system.SetState(new WanderState(_system));
            }
        }
        
        yield break;
    }
}