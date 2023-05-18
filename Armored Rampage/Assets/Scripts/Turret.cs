using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    bool canShoot = true;
    Collider2D[] tankcolliders;
    public float currentDelay = 0;


    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnRealoading;
    private void Start()
    {
        OnRealoading?.Invoke(currentDelay);
    }


    private void Awake()
    {
        tankcolliders = GetComponentsInParent<Collider2D>();
    }

    private void Update()
    {
        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            OnRealoading?.Invoke(currentDelay);

            if(currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }



    public void Shoot()
    {
       if (canShoot)
       {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarels)
            {


                var hit = Physics2D.Raycast(barrel.position, barrel.up);
                if(hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }


                GameObject bullet = Instantiate(bulletPrefab);

                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize();

                foreach (var collider in tankcolliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
            ScreenShake.Instance.ShakeCamera(4f,.1f);
            OnShoot?.Invoke();
            OnRealoading?.Invoke(currentDelay);
        }
        OnCantShoot?.Invoke();
    }
   
}
