using UnityEngine;

public class ZombieController : MonoBehaviour
{

    private Transform target;
    private UnityEngine.AI.NavMeshAgent  agente;
    
    void Start()
    {
        target = Camera.main.transform;
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agente.destination = target.position;
    }

  void OnTriggerEnter(Collider other)
  {
      GetComponent<SphereCollider>().enabled = false;
      agente.destination = gameObject.transform.position;

      GetComponent<Animation>().Stop();
      GetComponent<Animation>().Play("back_fall");

      Destroy(gameObject, 6.0f);

      GameObject zombie = Instantiate(Resources.Load("Zombie", typeof(GameObject))) as GameObject;

      zombie.transform.position = new Vector3(UnityEngine.Random.Range(-20f, 20f), 1.681568f, UnityEngine.Random.Range(-20f, 20f));

      while (Vector3.Distance(zombie.transform.position, target.position) <= 5)
      {
          zombie.transform.position = new Vector3(UnityEngine.Random.Range(-20f, 20f), 1.681568f, UnityEngine.Random.Range(-20f, 20f));
      }
}
}
