using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    string CurrentWeapon;
    Rigidbody RigidBody;
    public string[] WeaponTypes;

    GameObject[] AmmoInGame = new GameObject[100];
    public GameObject PlasmaBallObject;
    int AmmoAmountInstantiated = 0;

    bool CoroutineStarted = false;

    void Start()
    {
        CurrentWeapon = "Pistol";
        
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {

        if (AmmoAmountInstantiated < 1)
        {
            return;
        }

        foreach (GameObject Bullet in AmmoInGame)
        {
            Bullet.transform.position += Vector3.right * 0.2f;
        }

    }

    //var task = Task.Run(() => ResetCoroutine());
    //if (task.Wait(TimeSpan.FromSeconds(10)))
    //{
    //    return task.Result;
    //}
    //else
    //{
    //    throw new Exception("Timed out");
    //}

    public void ShootPistol(Vector3 Position)
    {

        if (AmmoAmountInstantiated > 2)
        {
            return;
        }
        AmmoInGame[AmmoAmountInstantiated] = Instantiate(PlasmaBallObject);
        AmmoAmountInstantiated += 1;

        for (var i = 0; i < 1; i++)
        {
            Debug.Log(AmmoInGame[i]);
            Debug.Log(AmmoAmountInstantiated);

        }

        
    }

    private void ResetCoroutine()
    {

        CoroutineStarted = false;
        
    }

    IEnumerator RealShootPistol()
    {
        Debug.Log("Real Shoot pistol run");
        if (AmmoAmountInstantiated > 2)
        {
            yield return new WaitForSeconds(1f);
        }
        AmmoInGame[AmmoAmountInstantiated] = Instantiate(PlasmaBallObject);
        AmmoAmountInstantiated += 1;

        for (var i = 0; i < 1; i++)
        {
            Debug.Log(AmmoInGame[i]);
            Debug.Log(AmmoAmountInstantiated);

        }

        yield return new WaitForSeconds(2f);

    }
}
