using UnityEngine;
using System.Collections;

public class AutoDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float closeDelay = 2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool playerNearby = false;
    private Coroutine closeCoroutine;

    void Start()
    {
        closedRotation = transform.rotation;

        openRotation = Quaternion.Euler(
            transform.eulerAngles.x,
            transform.eulerAngles.y + openAngle,
            transform.eulerAngles.z
        );
    }

    void Update()
    {
        Quaternion targetRotation = playerNearby
            ? openRotation
            : closedRotation;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * openSpeed
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerNearby = true;

        if (closeCoroutine != null)
        {
            StopCoroutine(closeCoroutine);
            closeCoroutine = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        closeCoroutine = StartCoroutine(CloseAfterDelay());
    }

    IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        playerNearby = false;
    }
}