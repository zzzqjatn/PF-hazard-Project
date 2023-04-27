using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Z_MonsterController : MonoBehaviour
{
    public Transform targetPos;
    public NavMeshAgent Agent { get; private set; }
    private Z_Monster monster;
    private float RandomTime;
    private float RandomEndTime;
    private float targetRange;
    private Vector3 ResultPoint;


    private FieldOfView FieldView;
    private Z_CustomState customState;

    private IsColliderHit Attack;
    public Z_MoveType inputType;

    public bool IsFind;
    private bool IsOnce;
    private bool IsFollow;

    void Start()
    {
        customState = new Z_CustomState();
        customState.SetZombiState(100, 0, 80, inputType);

        monster = this.gameObject.GetComponent<Z_Monster>();
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        FieldView = this.gameObject.GetComponent<FieldOfView>();
        Attack = this.gameObject.FindChildObj("AttackBox").GetComponent<IsColliderHit>();

        Agent.baseOffset = -0.05f;

        RandomTime = 0;
        RandomEndTime = Random.RandomRange(0.0f, 6.0f);

        targetRange = 10.0f;
        IsFind = false;
        IsOnce = false;
        IsFollow = false;
    }

    void Update()
    {
        RandomPattens();
    }

    private void FixedUpdate()
    {
        if (IsFollow)
        {
            float targetDis = Vector3.Distance(targetPos.position, transform.position);
            if (targetDis <= 0.1f)
            {
                StopAndResetMotion();
            }
            IsFollow = false;
        }
    }

    private void RandomPattens()
    {
        if (FieldView.visibleTargets.Count > 0)
        {
            IsFind = true;
        }

        if (IsFind)
        {
            if (Attack.IsOn == true)
            {
                if (monster.Z_AniState != Z_StateMachine.Idle)
                {
                    monster.ChangeAniState(Z_StateMachine.Idle);
                }
                monster.ChangeAniState(Z_StateMachine.Attck);
            }
            else if (Attack.IsOn == false) //탐지
            {
                if (FieldView.visibleTargets.Count > 0)
                {
                    targetPos.position = FieldView.visibleTargets[0].transform.position;
                    if (!IsOnce)
                    {
                        IsOnce = true;
                        StartCoroutine(FindScream());
                    }

                    if (IsFollow)
                    {
                        State_WR_changeType();
                    }
                }
            }

            if (FieldView.visibleTargets.Count == 0)
            {
                IsOnce = false;
                Agent.isStopped = true;    //임시
                StopAndResetMotion();
                IsFind = false;
                IsFollow = false;
            }
        }
        else
        {
            if (monster.Z_AniState == Z_StateMachine.Idle)
            {
                RandomTime += Time.deltaTime;

                if (RandomTime >= RandomEndTime)
                {
                    int stateNum = Random.RandomRange(0, 3);

                    switch (stateNum)
                    {
                        case 0:
                            monster.ChangeAniState(Z_StateMachine.Idle);
                            RandomEndTime = Random.RandomRange(2.0f, 5.0f);
                            break;
                        case 1:
                            if (CheckRandomPoint(targetPos.position, targetRange, out ResultPoint))
                            {
                                if (Agent.isStopped == true) Agent.isStopped = false;
                                targetPos.position = ResultPoint;
                                State_WR_changeType();
                                RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                            }
                            break;
                        case 2:
                            monster.ChangeAniState(Z_StateMachine.Turnning);
                            RandomEndTime = Random.RandomRange(2.0f, 3.0f);
                            break;
                    }
                    RandomTime = 0.0f;
                }
            }
            else
            {

            }
        }
    }

    IEnumerator FindScream()
    {
        yield return new WaitForSeconds(0.2f);
        if (Agent.isStopped == false) Agent.isStopped = true;
        yield return new WaitForSeconds(2.0f);
        monster.ChangeAniState(Z_StateMachine.Scream);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("2초뒤 발생");
        if (Agent.isStopped == true) Agent.isStopped = false;
        IsFollow = true;
    }

    private void State_WR_changeType()
    {
        if (customState.MoveType == Z_MoveType.Walk)
        {
            monster.ChangeAniState(Z_StateMachine.Walk);
        }
        else if (customState.MoveType == Z_MoveType.Run)
        {
            monster.ChangeAniState(Z_StateMachine.Run);
        }
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
        RandomTime = 0.0f;
        RandomEndTime = Random.RandomRange(2.0f, 10.0f);
    }
}
public enum Z_StateMachine
{
    None = -1, Idle, Walk, Run, Turnning, Attck, Scream, HitBite, DownBite, DownBiteKeep, CrawlRun, CrawlDown
}

public enum Z_Timming
{
    None = -1, Search, Moving, Find
}
