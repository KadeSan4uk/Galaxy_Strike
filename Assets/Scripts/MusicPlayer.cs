using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // This is disabled in the inspector because the audio plays in the Timeline.
    private void Start()
    {
        int numOfMusicPlayer = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}
