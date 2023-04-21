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
    public bool IsMoving;

    //===== 
    private Ray ray;
    private RaycastHit hit;
    private float viewAngle;
    private float viewDistance;
    private LayerMask TargetMask;
    private LayerMask ObstacleMask;

    void Start()
    {
        monster = this.gameObject.GetComponent<Z_Monster>();
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        Trans = this.transform;
        Agent.baseOffset = -0.05f;

        MoveSpeed = MOVE_SPEED_DEFAULT;

        RandomTime = 0;
        RandomEndTime = Random.RandomRange(0.0f, 6.0f);

        // targetPos = transform.position;
        targetRange = 10.0f;

        IsMoving = false;
    }

    void Update()
    {
        RandomPattens();
    }

    private void RandomPattens()
    {
        if (!IsMoving)
        {
            RandomTime += Time.deltaTime;

            if (RandomTime >= RandomEndTime)
            {
                int stateNum = Random.RandomRange(0, 3);

                switch (stateNum)
                {
                    case 0:
                        monster.ChangeAniState(Z_StateMachine.Idle);
                        IsMoving = false;
                        break;
                    case 1:
                        //목표지점
                        if (CheckRandomPoint(targetPos.position, targetRange, out rpPoint))
                        {
                            targetPos.position = rpPoint;
                            monster.ChangeAniState(Z_StateMachine.Walk);
                            IsMoving = true;
                        }
                        break;
                    case 2:
                        //목표지점
                        if (CheckRandomPoint(targetPos.position, targetRange, out rpPoint))
                        {
                            targetPos.position = rpPoint;
                            monster.ChangeAniState(Z_StateMachine.Run);
                            IsMoving = true;
                        }
                        break;
                }
                RandomTime = 0.0f;
                RandomEndTime = Random.RandomRange(2.0f, 3.0f);
            }
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
        IsMoving = false;
    }

    //==========================================================

    public Vector3 DirFormAngle(float angleDegrees)
    {
        angleDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
    }

    public void DrawView()
    {
        Vector3 leftBoundary = DirFormAngle(-viewAngle / 2);
        Vector3 rightBoundary = DirFormAngle(viewAngle / 2);
        Debug.DrawLine(transform.position, transform.position + leftBoundary * viewDistance, Color.blue);
        Debug.DrawLine(transform.position, transform.position + rightBoundary * viewDistance, Color.blue);
    }

    public void FindVisibleTargets()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewDistance, TargetMask);

        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                Transform target = targets[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;

                if (Vector3.Dot(transform.forward, dirToTarget) > Mathf.Cos((viewAngle / 2) * Mathf.Deg2Rad))
                {
                    float distToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, ObstacleMask))
                    {
                        Debug.DrawLine(transform.position, target.position, Color.red);
                    }
                }
            }
        }
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
    None = -1, Question, Item, Action, Fight
}