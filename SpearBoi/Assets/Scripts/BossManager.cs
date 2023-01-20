using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }

    [SerializeField]
    private GameObject saw, homingSaw, doorBlockade, bossCoinExplosion;

    [SerializeField]
    private int health = 3;

    [SerializeField]
    private float attackTimer;

    private GameObject leftArmor, rightArmor, leftArm, rightArm;
    private SawSpitter leftSpitter, rightSpitter;
    private float timer;
    private bool canAttack, leftDestroyed,rightDestroyed, isDying;

    private void Awake()
    {
        Instance = this;
        leftArm = transform.GetChild(1).gameObject;
        rightArm = transform.GetChild(0).gameObject;

        leftArmor = transform.GetChild(2).gameObject;
        rightArmor = transform.GetChild(3).gameObject;

        leftSpitter = leftArm.transform.GetChild(0).GetComponent<SawSpitter>();
        rightSpitter = rightArm.transform.GetChild(0).GetComponent<SawSpitter>();

        ResetToBase();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDying)
        {
            return;
        }

        if (canAttack)
        {
            timer += Time.deltaTime;

            if (timer > attackTimer)
            {
                int chooseAttack = Random.Range(0,8);
                switch (chooseAttack)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        StartCoroutine("SprayAttack");
                        break;

                    case 4:
                    case 5:
                    case 6:
                        StartCoroutine("ShotgunBlast");
                        break;

                    case 7:
                        StartCoroutine("HomingAttack");
                        break;
                }
            }
        }
    }

    private void ResetToBase()
    {
        leftArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        rightArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        leftSpitter.shootTimer = 2f;
        rightSpitter.shootTimer = 2f;
        leftSpitter.saw = saw;
        rightSpitter.saw = saw;
        leftSpitter.shotgunMode = false;
        rightSpitter.shotgunMode = false;
        timer = 0;
        canAttack = true;
    }

    private IEnumerator SprayAttack()
    {
        canAttack = false;
        leftSpitter.shootTimer = 0.3f;
        rightSpitter.shootTimer = 0.3f;
        RotateArms(-10);
        yield return new WaitForSeconds(0.3f);
        RotateArms(25);
        yield return new WaitForSeconds(0.3f);
        RotateArms(25);
        yield return new WaitForSeconds(0.3f);
        RotateArms(40);
        yield return new WaitForSeconds(0.3f);
        RotateArms(20);
        yield return new WaitForSeconds(0.3f);
        ResetToBase();
    }

    private void RotateArms(int rotateSpeed)
    {
        leftArm.transform.Rotate(new Vector3(0, 0, -rotateSpeed));
        rightArm.transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

    private IEnumerator HomingAttack()
    {
        canAttack = false;
        RotateArms(90);
        leftSpitter.shootTimer = 20f;
        rightSpitter.shootTimer = 20f;
        yield return new WaitForSeconds(1f);
        leftSpitter.shootTimer = 0.3f;
        rightSpitter.shootTimer = 0.3f;
        leftSpitter.saw = homingSaw;
        rightSpitter.saw = homingSaw;
        yield return new WaitForSeconds(0.3f);
        leftSpitter.shootTimer = 20f;
        rightSpitter.shootTimer = 20f;
        yield return new WaitForSeconds(1f);
        ResetToBase();
    }

    private IEnumerator ShotgunBlast()
    {
        canAttack = false;
        RotateArms(50);
        leftSpitter.shootTimer = 20f;
        rightSpitter.shootTimer = 20f;
        yield return new WaitForSeconds(1f);
        leftSpitter.shotgunMode = true;
        rightSpitter.shotgunMode = true;
        leftSpitter.shootTimer = 0.5f;
        rightSpitter.shootTimer = 0.5f;
        yield return new WaitForSeconds(1f);
        ResetToBase();
    }

    public void TakeDamage(Direction side)
    {
        switch (side)
        {
            case Direction.LEFT:
                if (leftDestroyed)
                {
                    break;
                }
                Destroy(leftArmor);
                health--;
                attackTimer *= 0.8f;
                leftDestroyed = true;
                break;

            case Direction.RIGHT:
                if (rightDestroyed)
                {
                    break;
                }
                Destroy(rightArmor);
                health--;
                attackTimer *= 0.8f;
                rightDestroyed = true;
                break;

            case Direction.DOWN:
                if (health==1)
                {
                    StartCoroutine("GetDestroyed");
                }
                break;
        }
    }

    private IEnumerator GetDestroyed()
    {
        isDying = true;
        Instantiate(bossCoinExplosion, transform);
        leftSpitter.shootTimer = 20;
        rightSpitter.shootTimer = 20;
        Destroy(doorBlockade);
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

    public enum Direction{
        LEFT,
        RIGHT,
        DOWN
    }
}