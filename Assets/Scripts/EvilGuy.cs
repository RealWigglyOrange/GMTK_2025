using UnityEngine;

public class EvilGuy : MonoBehaviour
{
    [SerializeField] DetectDeath detectDeath;
    [SerializeField] PlayerController player;
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (detectDeath.isdead)
        {
            // transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.02f);
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, 0.4f);
        }
    }
}
