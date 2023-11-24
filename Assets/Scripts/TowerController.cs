using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    public float ReloadTime;
    public GameObject Bullet;
    public float ShootSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine(ReloadTime));
    }

    public IEnumerator ShootCoroutine(float x)
    {
        while (true)
        {
            yield return new WaitForSeconds(x);
        }
    }

    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, transform.position +
        (transform.forward * 0.5f), Quaternion.identity, transform);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward *
        ShootSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        CreateBullet();
    }
}
