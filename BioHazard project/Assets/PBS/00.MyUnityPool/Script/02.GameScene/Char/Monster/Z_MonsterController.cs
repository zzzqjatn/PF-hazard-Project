using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Z_MonsterController : MonoBehaviour
{
    //===== 
    private const float MOVE_SPEED_DEFAULT = 1.0f;
    private Z_Monster monster;
    public NavMeshAgent Agent { get; private set; }
    private float MoveSpeed;
    private float RandomTime;
    private float RandomEndTime;
    public Transform targetPos;
    private float targetRange;
    private Vector3 rpPoint;

    //===== 
    public Transform Trans;
    public Z_Timming IsTiming;

    private FieldOfView Z_FieldView;
    private Z_CustomState Z_customState;

    private IsColliderHit Z_Attack;
    public Z_MoveType inputType;

    public bool IsFind;

    void Start()
    {
        Z_customState = new Z_CustomState();
        Z_customState.SetZombiState(100, 0, 80, inputType);

        monster = this.gameObject.GetComponent<Z_Monster>();
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Z_FieldView = this.gameObject.GetComponent<FieldOfView>();

        Z_Attack = this.gameObject.FindChildObj("AttackBox").GetComponent<IsColliderHit>();

        Trans = this.transform;
        Agent.baseOffset = -0.05f;

        MoveSpeed = MOVE_SPEED_DEFAULT;

        RandomTime = 0;
        RandomEndTime = Random.RandomRange(0.0f, 6.0f);

        targetRange = 10.0f;
        IsTiming = Z_Timming.Search;
        IsFind = false;
    }

    void Update()
    {
        RandomPattens();
    }

    private void RandomPattens()
    {
        if (Z_FieldView.visibleTargets.Count > 0)
        {
            IsTiming = Z_Timming.Find;
            IsFind = true;
        }
        else if (Z_FieldView.visibleTargets.Count == 0)
        {
            IsTiming = Z_Timming.Search;
            IsFind = false;
        }

        if (IsTiming == Z_Timming.Search)
        {
            RandomTime += Time.deltaTime;

            if (RandomTime >= RandomEndTime)
            {
                int stateNum = Random.RandomRange(0, 4);

                switch (stateNum)
                {
                    case 0:
                        monster.ChangeAniState(Z_StateMachine.Idle);
                        RandomEndTime = Random.RandomRange(2.0f, 10.0f);
                        break;
                    case 1:
                        if (CheckRandomPoint(targetPos.position, targetRange, out rpPoint) && Z_customState.MoveType == Z_MoveType.Walk)
                        {
                            targetPos.position = rpPoint;
                            monster.ChangeAniState(Z_StateMachine.Walk);
                            IsTiming = Z_Timming.Moving;
                            RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                        }
                        break;
                    case 2:
                        if (CheckRandomPoint(targetPos.position, targetRange, out rpPoint) && Z_customState.MoveType == Z_MoveType.Run)
                        {
                            targetPos.position = rpPoint;
                            monster.ChangeAniState(Z_StateMachine.Run);
                            IsTiming = Z_Timming.Moving;
                            RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                        }
                        break;
                    case 3:
                        monster.ChangeAniState(Z_StateMachine.Turnning);
                        IsTiming = Z_Timming.Moving;
                        RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                        break;
                }
                RandomTime = 0.0f;
            }
        }
        else if (IsTiming == Z_Timming.Moving)
        {
            if (monster.Z_AniState == Z_StateMachine.Turnning)
            {
                if (monster.Z_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
                {
                    monster.ChangeAniState(Z_StateMachine.Idle);
                    IsTiming = Z_Timming.Search;
                    RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                }
            }
        }
        else if (IsTiming == Z_Timming.Find)
        {
            if (Z_Attack.IsOn == true)
            {
                monster.ChangeAniState(Z_StateMachine.Attck);
            }
            else if (Z_Attack.IsOn == false)
            {
                //탐지 성공
                targetPos.position = Z_FieldView.visibleTargets[0].transform.position;
                if (IsFind == false) StartCoroutine(FindScream());
                // State_WR_changeType();
            }
        }
    }

    IEnumerator FindScream()
    {
        yield return new WaitForSeconds(0.2f);
        Agent.isStopped = true;
        monster.ChangeAniState(Z_StateMachine.Idle);
        monster.ChangeAniState(Z_StateMachine.Scream);
        yield return new WaitForSeconds(0.8f);
        monster.ChangeAniState(Z_StateMachine.Idle);
        // State_WR_changeType();
        // Agent.isStopped = false;
        // if (monster.Z_Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        // {
        //     monster.ChangeAniState(Z_StateMachine.Idle);
        //     State_WR_changeType();
        // }
    }

    private void State_WR_changeType()
    {
        if (Z_customState.MoveType == Z_MoveType.Walk)
        {
            monster.ChangeAniState(Z_StateMachine.Walk);
        }
        else if (Z_customState.MoveType == Z_MoveType.Run)
        {
            monster.ChangeAniState(Z_StateMachine.Run);
        }
        IsTiming = Z_Timming.Moving;
        RandomEndTime = Random.RandomRange(2.0f, 3.0f);
    }

    public bool CheckRandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public void SetNavOffsetY(float inputData)
    {
        Agent.baseOffset = inputData;
    }

    public void SetTranRot(Quaternion input)
    {
        this.transform.rotation = input;
    }

    public void StopAndResetMotion()
    {
        monster.ChangeAniState(Z_StateMachine.Idle);
        IsTiming = Z_Timming.Search;
    }
    // private void IsMovingEnd()
    // {
    //     if (IsMoving)
    //     {
    //         if (Vector3.Distance(transform.position, targetPos) > 0.2f)
    //         {
    //             Z_monster.ChangeAniState(Z_StateMachine.Idle);
    //             IsMoving = false;
    //         }
    //     }
    // }
}
public enum Z_StateMachine
{
    None = -1, Idle, Walk, Run, Turnning, Attck, Scream, HitBite, DownBite, DownBiteKeep, CrawlRun, CrawlDown
}

public enum Z_Timming
{
    None = -1, Search, Moving, Find
}
