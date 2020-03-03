using UnityEngine;

public class Bow : MonoBehaviour
{
    //This class allows the player to shoot "arrows" (or any prefab) onto a surface in the game using a raycast.

    //Two variables-- one for the player's camera, and one for the range of how far the raycast can go
    public Camera playerCam;
    public int range = 1000;

    //Prefab that will be fired
    public GameObject arrowPrefab;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        //Left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            //Declaring the raycast to be used in the following cast
            RaycastHit hit;

            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
            {
                //Debug stuff-- lets us see if the raycast is working.
                Debug.Log("hitting!");
                Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * range, Color.red);
            }

            //Instantiates the "arrow" at the point of impact
            GameObject arrow = Instantiate(arrowPrefab, hit.point, Quaternion.identity);
            
            //Destroys the arrow after a few seconds so that the game doesn't get cluttered
            Destroy(arrow, 3f);
        }
    }
}
