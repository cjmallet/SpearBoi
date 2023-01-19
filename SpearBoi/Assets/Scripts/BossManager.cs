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

    private GameObject leftArm, rightArm;

    private void Awake()
    {
        Instance = this;
        leftArm = transform.GetChild(1).gameObject;
        rightArm = transform.GetChild(0).gameObject;
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
        leftArm.transform.rotation=(new Quaternion(0,0,Mathf.Lerp(0,-100,20),0));
        leftArm.transform.rotation= (new Quaternion(0, 0, Mathf.Lerp(0, 100, 20), 0));
        yield return new WaitForSeconds(1f);
    }

    private void HomingAttack()
    {

    }

    private void ShotgunBlast()
    {

    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Damage");
        if (health==0)
        {
            GetDestroyed();
        }
    }

    private void GetDestroyed()
    {

    }
}
