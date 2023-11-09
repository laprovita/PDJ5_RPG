using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class State_Enemy
{
    public enum STATE
    {
        IDLE, PATROL, CHASE, ATTACK
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE state;
    protected EVENT stage;
    protected GameObject npc;
    protected NavMeshAgent agent;
    protected Animator animator;
    protected Transform player;
    protected Transform[] waipoints;
    protected State_Enemy nextState;

    public State_Enemy(GameObject _npc, NavMeshAgent _agent, Animator _animator, Transform _player, Transform[] _waiponts)
    {
        npc = _npc;
        agent = _agent;
        animator = _animator;
        player = _player;
        waipoints = _waiponts;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State_Enemy Process()
    {
        if (stage == EVENT.ENTER)
        {
            Enter();
        }
        else if(stage == EVENT.UPDATE)
        {
            Update();
        }
        else
        {
            Exit();
            return nextState;
        }
        return this;
    }

}

public class Idle : State_Enemy
{
    float timer;

    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _animator, Transform _player, Transform[] _waiponts) : base(_npc, _agent, _animator, _player, _waiponts)
    {

    }

    public override void Enter()
    {
        agent.isStopped= true;
        animator.SetTrigger("idle");
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Idle");
        timer += Time.deltaTime;
    }

    public override void Exit() 
    { 

    }
}
