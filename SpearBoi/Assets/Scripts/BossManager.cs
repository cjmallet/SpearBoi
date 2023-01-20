using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }

    [SerializeField]
    private GameObject saw, homingSaw;

    [SerializeField]
    private int health = 3;

    private GameObject leftArmor, rightArmor, leftArm, rightArm;
    private SawSpitter leftSpitter, rightSpitter;

    private void Awake()
    {
        Instance = this;
        leftArm = transform.GetChild(1).gameObject;
        rightArm = transform.GetChild(0).gameObject;

        leftArmor = transform.GetChild(2).gameObject;
        rightArmor = transform.GetChild(3).gameObject;

        leftSpitter = leftArm.transform.GetChild(0).GetComponent<SawSpitter>();
        rightSpitter = rightArm.transform.GetChild(0).GetComponent<SawSpitter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ResetToBase()
    {
        leftArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        rightArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        leftSpitter.shootTimer = 1f;
        rightSpitter.shootTimer = 1f;
        leftSpitter.saw = saw;
        rightSpitter.saw = saw;
        leftSpitter.shotgunMode = false;
        rightSpitter.shotgunMode = false;
    }

    private IEnumerator SprayAttack()
    {
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
                Destroy(leftArmor);
                health--;
                break;
            case Direction.RIGHT:
                Destroy(rightArmor);
                health--;
                break;
            case Direction.DOWN:
                if (health==1)
                {
                    GetDestroyed();
                }
                break;
        }

        if (health==1)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void GetDestroyed()
    {
        Destroy(this.gameObject);
    }

    public enum Direction{
        LEFT,
        RIGHT,
        DOWN
    }
}
