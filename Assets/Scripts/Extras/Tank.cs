using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Tank : MonoBehaviour //NetworkBehaviour
{
    //Variables
    public GameObject playerModel;
    public GameObject GunModel;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    Pool bulletPool;

    public float moveSpeed = 4.0f;
    public float bulletSpeed = 3.0f;
    public float reloadSpeed = 0.4f;
    float reloadTimer = 0.0f;

    CharacterController controller;
    Vector3 move = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        bulletPool = new Pool(bulletPrefab);
    }


    //public override void OnStartLocalPlayer()
    //{
    //}


    // Update is called once per frame
    void Update() {
        //Network players - no action
        //if (!isLocalPlayer) return;

        FallCheck();
        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        else
        {
            Fire(); //auto-fire
        }

        //recoil (and recovery)
        if (reloadSpeed > 0)
        {
            float percent = reloadTimer / reloadSpeed;
            GunModel.transform.localPosition = new Vector3(0, 0, -0.1f * percent);
        }
    }
    
    void FallCheck()
    {
        if (transform.position.y < -10.0f)
        {
            Debug.Log("ahhhhh!");
            transform.position = new Vector3(0.0f, 20.0f, 0.0f);
        }
    }

    public void Move(Vector3 direction)
    {
        //Calculate 'move' amount from direction and speed 
        move = transform.TransformDirection(direction) * moveSpeed;

        //Making it move
        //transform.position += move * Time.deltaTime;
        controller.Move(move * Time.deltaTime);
    }

    public void Aim(Vector3 aim)
    {
        playerModel.transform.LookAt(transform.position + aim);
    }

    void Fire()
    {
        //Set delay for next shot
        reloadTimer = reloadSpeed;

        //Get Bullet
        GameObject bullet = bulletPool.Spawn(bulletSpawn);

        // Add velocity to the bullet
        //var rb = bullet.GetComponent<Rigidbody>();
        //rb.ResetInertiaTensor();
        //rb.AddForce(bullet.transform.forward * bulletSpeed);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 3.0f);
        StartCoroutine(CollectBulletAfterTime(bullet, 3.0f));
    }

    IEnumerator CollectBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        bulletPool.Collect(bullet);
    }

}
