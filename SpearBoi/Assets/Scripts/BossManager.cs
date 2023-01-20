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

    private void ResetToBase()
    {
        leftArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        rightArm.transform.rotation = Quaternion.Euler(Vector3.zero);
        leftArm.transform.GetChild(0).GetComponent<SawSpitter>().shootTimer = 1f;
        rightArm.transform.GetChild(0).GetComponent<SawSpitter>().shootTimer = 1f;
    }

    private IEnumerator SprayAttack()
    {
        leftArm.transform.GetChild(0).GetComponent<SawSpitter>().shootTimer = 0.3f;
        rightArm.transform.GetChild(0).GetComponent<SawSpitter>().shootTimer = 0.3f;
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        RotateArm(20);
        yield return new WaitForSeconds(0.3f);
        ResetToBase();
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
