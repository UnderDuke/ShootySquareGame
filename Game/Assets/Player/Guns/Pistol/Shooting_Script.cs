using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{
    public Transform pistolFirepoint;
    public Rigidbody2D pistolFirepointRB;
    public GameObject pistolBullet;
    public Transform pistolGun;
    public Camera cam;
    public Rigidbody2D pistolRB;
    public Transform player;
    public SpriteRenderer sp;

    public float gunPosX = 0.2f;
    public float gunPosY = 0.2f;
    public float pistolBulletForce = 30f;

    Vector2 mousePos;
    Vector3 eulerRotation;
    void Fire() 
    {
        GameObject bullet = Instantiate(pistolBullet, pistolFirepoint.position, pistolFirepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(pistolFirepoint.up * pistolBulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1.5f);
    }

   void Aiming() 
    {
        Vector2 lookDir = mousePos - pistolRB.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        pistolRB.rotation = angle;
        eulerRotation = pistolFirepoint.rotation.eulerAngles;

        if (angle > -179.9f && angle < -90)
        {
            pistolGun.localScale = new Vector3(-3, -3, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, -90);
            Debug.Log("True");
        }
        
        if (angle < 179.9f && angle > 90) 
        {
            pistolGun.localScale = new Vector3(-3, -3, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, -90);
           
            Debug.Log("True");
        }

        if (angle > -90 && angle < 0) 
        {
            pistolGun.localScale = new Vector3(-3, 3, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);
            pistolFirepointRB.rotation = angle;
            Debug.Log("False");
        }

        if (angle > 0 && angle < 90) 
        {
            pistolGun.localScale = new Vector3(-3, 3, 0);
            pistolFirepoint.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 90);

            Debug.Log("False");
        }

    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        pistolGun.localPosition = new Vector2(gunPosX, gunPosY);

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
