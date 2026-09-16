using UnityEngine;
using TMPro;
using System.Collections;

public class BlockedExitTrigger : MonoBehaviour
{
    [Tooltip("Drag a TextMeshProUGUI element here to display the warning message.")]
    public TextMeshProUGUI messageText;

    [Tooltip("How long the message stays on screen, in seconds.")]
    public float displayDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowMessage("PRIMARY EXIT BLOCKED! FIND AN ALTERNATIVE ROUTE!", displayDuration);
        }
    }

    private void ShowMessage(string text, float duration)
    {
        if (messageText == null)
        {
            Debug.LogWarning("BlockedExitTrigger: messageText is not assigned.");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(DisplayRoutine(text, duration));
    }

    private IEnumerator DisplayRoutine(string text, float duration)
    {
        messageText.text = text;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
    }
}