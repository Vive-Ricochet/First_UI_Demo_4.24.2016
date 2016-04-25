using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    // private fields editable by inspector
    [SerializeField]
    private Transform target;              // the target object for this camera
    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;
    [SerializeField]
    private float minDistance = 15;
    [SerializeField]
    private float distanceBias = 0.75f;    //How much the distance affects the zoom affect

    private float old_dis;
    private float distance;

    // private fields
    private float xDeg = 0.0f;
    private float yDeg = 0.0f;

    public bool collided = false;

    void Start()
    {
        old_dis = Vector3.Distance(player1.position, player2.position);
        collided = false;
        Time.timeScale = 1.0f;
    }

    void LateUpdate()
    {
        if (!target)
            return;
        if (!collided) {
            distance = Mathf.Lerp(old_dis, Vector3.Distance(player1.position, player2.position), Time.deltaTime * 2.0f);
            Camera.main.fieldOfView = distance * distanceBias + minDistance;
            old_dis = distance;
        } else
        {
            float col_dis = Vector3.Distance(transform.position, target.position);
            Camera.main.fieldOfView -= col_dis / 100;
            if (Camera.main.fieldOfView <= 15) Camera.main.fieldOfView = 15;
            if (Time.timeScale < 1f)
            {
                Time.timeScale += .001f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
            // camera rotation
            Quaternion rotation = Quaternion.Euler(yDeg, xDeg, 0);


            // apply rotation
            transform.LookAt(target);
        
    }
    public void onCollision(Transform playerTarget)
    {
        collided = true;
        Time.timeScale = .1f;
        target = playerTarget;
    }
}
