using UnityEngine;
using UnityEngine.AI;
public class EventNPCController : NPCManager
{
    public enum ENEMY_STATE
    {
        MOVE,DIE,
    }
    [SerializeField] NavMeshAgent agent = null;

    private bool die = false;

    /// <summary>アタッチしているオブジェクトの撃破ポイント</summary>
    [SerializeField] readonly int eventPointValue = 50;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        EnemyRoutine(ENEMY_STATE.MOVE);
    }

    public void EnemyRoutine(ENEMY_STATE sTATE)
    {
        switch (sTATE)
        {
            case ENEMY_STATE.MOVE:
                AnimePlay(ANIME_STATE.HAPPY3);
                break;
            case ENEMY_STATE.DIE:
                SetRagdoll(die);
                break;
        }
    }
    /// <summary>eventNPCが死亡したら呼ばれる。</summary>
    public void NPCDie()
    {
        PointController.Instance.PointSet(eventPointValue);
        die = true;
        EnemyRoutine(ENEMY_STATE.DIE);
    }
}
