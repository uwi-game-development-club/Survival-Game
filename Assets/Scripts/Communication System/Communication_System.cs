using UnityEngine;
using System.Collections;

public class Communication_System : MonoBehaviour
{
    [SerializeField] private Incoming_Radio_Notification notification;
    [SerializeField] private Radio_Message_Screen messageScreen;
    [SerializeField] private AudioManager audioManager;

    public AudioClip currDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OpenNotificationWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenNotificationWindow()
    {
        notification.gameObject.SetActive(true);
        notification.PickUpPhoneButton.onClick.AddListener(notificationClicked);
        Debug.Log("Incoming_Radio_Notification Activated and added to screen");

    }

    // IEnumerator allows us to use the yield return functionality to have a timer
    private void notificationClicked()
    {
        StartCoroutine(notificationClickedRoutine());
    }

    private IEnumerator notificationClickedRoutine()
{
    notification.gameObject.SetActive(false);
    Debug.Log("Incoming_Radio_Notification Button Clicked");
    messageScreen.gameObject.SetActive(true);
    Debug.Log("Radio_Message_Screen activated and Added to screen");

    if (audioManager.musicSource != null)
    {
        Debug.Log("audioManager.musicSource != null");

    }
    else
    {
        Debug.Log("audioManager.musicSource == null");
    }

    if (currDialogue != null)
    {
        Debug.Log("currDialogue != null");

    }
    else
    {
        Debug.Log("currDialogue == null");
    }

    if (audioManager.musicSource != null && currDialogue != null)
    {
        audioManager.musicSource.clip = currDialogue;
        audioManager.musicSource.loop = false;
        audioManager.musicSource.Play();

        float delayTime = currDialogue.length + 3.0f;
        yield return new WaitForSeconds(delayTime);

        messageClose();
    }
}

    private void messageClose()
    {
        messageScreen.gameObject.SetActive(false);
        Debug.Log("Radio_Message_Screen closed");

        audioManager.playBGMusic();
    }
}
