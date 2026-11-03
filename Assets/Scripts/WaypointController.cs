using UnityEngine;

public class WaypointController : MonoBehaviour
{
   public void OnPointerEnter(Transform player){
        player.position = transform.position;
   }
    
}
