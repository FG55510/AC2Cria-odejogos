using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    Seek,
    Arrive,
    Wander
}
public class EnemyStateMachine : MonoBehaviour
{

    public GameObject player;
    public float distance;

    public float timetostay = 5f;
    private float time = 5f;


    public Seek seek;
    public Wander wander;
    public Arrive arrive;

    public EnemyState state;
    // Start is called before the first frame update
    void Start()
    {
        time = timetostay;
        state = EnemyState.Wander;
        ChangeState(state);

        seek = GetComponent<Seek>();
        wander = GetComponent<Wander>();
        arrive = GetComponent<Arrive>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        switch (state)
        {
            case EnemyState.Wander:
                if (distance < 5)
                {
                    ChangeState(EnemyState.Seek);
                }
                break;


            case EnemyState.Seek:
                if (distance > 5)
                {
                    ChangeState(EnemyState.Wander);
                }

                if (distance <= 0.1)
                {
                    ChangeState(EnemyState.Arrive);
                }
                break;

            case EnemyState.Arrive:
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    ChangeState(EnemyState.Wander);
                    time = timetostay;
                }
                break;
        }
    }

    public void ResetAll()
    {
        seek.enabled = false;
        arrive.enabled = false;
        wander.enabled = false;

    }

    public void ChangeState(EnemyState estado)
    {
        ResetAll();

        switch (estado)
        {
            case EnemyState.Wander:
                wander.enabled = true;
                break;

            case EnemyState.Seek:
                seek.enabled = true;
                break;

            case EnemyState.Arrive:
                arrive.enabled = true;
                break;
        }

        state = estado;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetLife(-1);
            ChangeState(EnemyState.Arrive);
        }
    }
}
