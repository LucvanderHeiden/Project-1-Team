using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{

    public Transform PosA, PosB, PosC, PosD, PosE;
    public int Speed;
    Vector2 targetPos;

    GameObject enemy;

    int randomInt;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = PosB.position;

        enemy = GameObject.Find("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView fovScript = enemy.GetComponent<FieldOfView>();
        if (Vector2.Distance(transform.position, PosA.position) < .1f)
        {
            randomInt = Random.Range(1, 6);

            if (randomInt == 1)
            {
                targetPos = PosA.position;
            }

            if (randomInt == 2)
            {
                targetPos = PosB.position;
            }

            if (randomInt == 3)
            {
                targetPos = PosC.position;
            }

            if (randomInt == 4)
            {
                targetPos = PosD.position;
            }

            if (randomInt == 5)
            {
                targetPos = PosE.position;
            }
        }

        if (Vector2.Distance(transform.position, PosB.position) < .1f)
        {
            randomInt = Random.Range(1, 6);

            if (randomInt == 1)
            {
                targetPos = PosA.position;
            }

            if (randomInt == 2)
            {
                targetPos = PosB.position;
            }

            if (randomInt == 3)
            {
                targetPos = PosC.position;
            }

            if (randomInt == 4)
            {
                targetPos = PosD.position;
            }

            if (randomInt == 5)
            {
                targetPos = PosE.position;
            }
        }

        if (Vector2.Distance(transform.position, PosC.position) < .1f)
        {
            randomInt = Random.Range(1, 6);

            if (randomInt == 1)
            {
                targetPos = PosA.position;
            }

            if (randomInt == 2)
            {
                targetPos = PosB.position;
            }

            if (randomInt == 3)
            {
                targetPos = PosC.position;
            }

            if (randomInt == 4)
            {
                targetPos = PosD.position;
            }

            if (randomInt == 5)
            {
                targetPos = PosE.position;
            }
        }

        if (Vector2.Distance(transform.position, PosD.position) < .1f)
        {
            randomInt = Random.Range(1, 6);

            if (randomInt == 1)
            {
                targetPos = PosA.position;
            }

            if (randomInt == 2)
            {
                targetPos = PosB.position;
            }

            if (randomInt == 3)
            {
                targetPos = PosC.position;
            }

            if (randomInt == 4)
            {
                targetPos = PosD.position;
            }

            if (randomInt == 5)
            {
                targetPos = PosE.position;
            }
        }

        if (Vector2.Distance(transform.position, PosE.position) < .1f)
        {
            randomInt = Random.Range(1, 6);

            if (randomInt == 1)
            {
                targetPos = PosA.position;
            }

            if (randomInt == 2)
            {
                targetPos = PosB.position;
            }

            if (randomInt == 3)
            {
                targetPos = PosC.position;
            }

            if (randomInt == 4)
            {
                targetPos = PosD.position;
            }

            if (randomInt == 5)
            {
                targetPos = PosE.position;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }
}
