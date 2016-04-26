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
    private float PauseDelay = 1f;
    private bool StillScreen = true;

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
        if (!collided)
        {
            distance = Mathf.Lerp(old_dis, Vector3.Distance(player1.position, player2.position), Time.deltaTime * 2.0f);
            Camera.main.fieldOfView = distance * distanceBias + minDistance;
            old_dis = distance;
        }
        else
        {
            PlayShake();
            float col_dis = Vector3.Distance(transform.position, target.position);
            Camera.main.fieldOfView -= col_dis / 200;
            if (Camera.main.fieldOfView <= 25) Camera.main.fieldOfView = 25;
            if ((Time.timeScale * 1.1f) <1)
            {
                Time.timeScale *= 1.1f;
                //Time.fixedDeltaTime = 0.01F * Time.timeScale;
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
        StillScreen = true;
        Time.timeScale = .0001f;
        target = playerTarget;

    }
    public float duration = 0.5f;
    public float speed = 1.0f;
    public float magnitude = 0.3f;

    public bool test = false;

    // -------------------------------------------------------------------------
    public void PlayShake()
    {

        StopAllCoroutines();
        StartCoroutine("Shake");
    }

    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;
        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;

            // We want to reduce the shake from full power to 0 starting half way through
            float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);

            // Calculate the noise parameter starting randomly and going as fast as speed allows
            float alpha = randomStart + speed * percentComplete;

            // map noise to [-1, 1]
            float x = Util.Noise.GetNoise(alpha, 0.0f, 0.0f) * 2.0f - 1.0f;
            float y = Util.Noise.GetNoise(0.0f, alpha, 0.0f) * 2.0f - 1.0f;

            x *= magnitude * damper;
            y *= magnitude * damper;

            float xpos = x + originalCamPos.x;
            float ypos = y + originalCamPos.y;
            Camera.main.transform.position = new Vector3(xpos, ypos, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
