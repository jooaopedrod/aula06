using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public GameObject spawnPoint;
    private bool isShooting;
    void Start()
    {
        isShooting = false;
    }

    public void Update(){
        RaycastHit hit;
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.red);
        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 10))
        {
            if(hit.collider.gameObject.CompareTag("Zombie")){
                if(!isShooting){
                 StartCoroutine(Shoot());   
                }
            }
        }
    }

    IEnumerator Shoot(){
        isShooting = true;

        GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;

        bullet.transform.position = spawnPoint.transform.position;
        bullet.transform.rotation = spawnPoint.transform.rotation;

        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * 500f);

        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Play();
        Destroy(bullet, 2f);
        
        yield return new WaitForSeconds(1f); 
        isShooting = false;
    }
}
