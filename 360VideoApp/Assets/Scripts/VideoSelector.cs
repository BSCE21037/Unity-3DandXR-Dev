// using UnityEngine;
// using UnityEngine.Video;

// public class VideoSelector : ObjectController
// {
//     //public GameObject menuCanvas; // Reference to the menu canvas
//     //public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
//     public VideoPlayer videoPlayer = new VideoPlayer();
//     //public bool playVideo = false; // Flag to indicate whether to play the video
//     //public string videoPath; // Path to the video clip
//     void Awake()
//     {
//         // Get the VideoPlayer component
//         videoPlayer = GetComponent<VideoPlayer>();
//     }
//     void Update()
//     {
//         // Check if playVideo is true and the videoPlayer is not already playing
//         if (playVideo && !videoPlayer.isPlaying)
//         {
//             PlayVideo();
//         }
//     }

//     // Method to play a video
//     public void PlayVideo()
//     {
//         // Set the video URL
//         videoPlayer.url = "/Assets/360Videos/Poppy Field, Armenia. Relaxation video in 8K..mp4";

//         // Play the video
//         videoPlayer.Play();

//         // Hide the menu canvas
//         //menuCanvas.SetActive(false);

//         // Reset the playVideo flag
//         playVideo = false;
//     }
// }
