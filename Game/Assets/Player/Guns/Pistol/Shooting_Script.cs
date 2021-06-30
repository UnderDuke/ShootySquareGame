using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{
    public Transform pistolFirepoint;
    public GameObject pistolBullet;
    public Transform pistolGun;
    public Camera cam;
    public Rigidbody2D pistolRB;
    public Transform player;
    public AudioSource gunShot;
 
    public float pistolBulletForce = 30f;

    Vector2 mousePos;
    Vector3 eulerRotation;

    void Fire() 
    {
        GameObject bullet = Instantiate(pistolBullet, pistolFirepoint.position, pistolFirepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pistolFirepoint.up * pistolBulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1.5f);
        gunShot.Play(0);
    }


    void Aiming() 
    {
        Vector2 lookDir = mousePos - pistolRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        pistolRB.rotation = angle;
        eulerRotation = pistolFirepoint.rotation.eulerAngles;

        // Facing Left
        if (angle > -179.9f && angle < -90)
        {
            pistolGun.localScale = new Vector3(-10, -10, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, -90);
        }
        
        if (angle < 179.9f && angle > 90) 
        {
            pistolGun.localScale = new Vector3(-10, -10, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, -90);
        }

        //Facing Right
        if (angle > -90 && angle < 0) 
        {
            pistolGun.localScale = new Vector3(-10, 10, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);

        }

        if (angle > 0 && angle < 90) 
        {
            pistolGun.localScale = new Vector3(-10, 10, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
            
        }

    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        pistolGun.position = new Vector2(player.position.x, player.position.y + .7f);
        if (Input.GetButtonDown("Fire1")) 
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        Aiming();
    }

}
