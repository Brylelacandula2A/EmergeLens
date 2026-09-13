using UnityEngine;

public class FireAlarm : MonoBehaviour, IInteractable
{
    [Header("Alarm Settings")]
    public AudioSource alarmAudio;

    public NPCFollowController npcToFollow;   // hehe

    private bool isPulled = false;

    public void OnGazeEnter() { }
    public void OnGazeExit() { }

    public void OnInteract()
    {
        if (!isPulled)
        {
            isPulled = true;
            
            if (alarmAudio != null && !alarmAudio.isPlaying) 
                alarmAudio.Play();


            if (npcToFollow != null)
                npcToFollow.StartFollowing();



        }
    }
}