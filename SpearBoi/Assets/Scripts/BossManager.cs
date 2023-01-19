using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager Instance { get; private set; }

    [SerializeField]
    private GameObject saw, homingSaw, player;

    [SerializeField]
    private int health = 3;

    private GameObject leftArmor, rightArmor, leftArm, rightArm;

    private void Awake()
    {
        Instance = this;
        leftArm = transform.GetChild(1).gameObject;
        rightArm = transform.GetChild(0).gameObject;

        leftArmor = transform.GetChild(2).gameObject;
        rightArmor = transform.GetChild(3).gameObject;
        StartCoroutine("SprayAttack");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SprayAttack()
    {
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
    }

    private void RotateArm(int rotateSpeed)
    {
        leftArm.transform.Rotate(new Vector3(0, 0, -rotateSpeed));
        rightArm.transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }

    private IEnumerator LaserAttack()
    {
        leftArm.transform.rotation = (new Quaternion(0, 0, Mathf.Lerp(0, -100, 20), 0));
        leftArm.transform.rotation = (new Quaternion(0, 0, Mathf.Lerp(0, 100, 20), 0));
        yield return new WaitForSeconds(1f);
    }

    private void HomingAttack()
    {

    }

    private void ShotgunBlast()
    {

    }

    public void TakeDamage(Direction side)
    {
        health--;

        switch (side)
        {
            case Direction.LEFT:
                Destroy(leftArmor);
                break;
            case Direction.RIGHT:
                Destroy(rightArmor);
                break;
            case Direction.DOWN:
                Destroy(this.gameObject);
                break;
        }

        if (health==1)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            rightArm.GetComponent<BoxCollider2D>().enabled = true;
            leftArm.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (health == 0)
        {
            GetDestroyed();
        }
    }

    private void GetDestroyed()
    {

    }

    public enum Direction{
        LEFT,
        RIGHT,
        DOWN
    }
}
