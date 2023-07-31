using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID 
using Unity.Notifications.Android;
#endif

public class AndroidExampleNotification : MonoBehaviour
{

    [SerializeField] int notificationId;
    [SerializeField] string channelIdExample;

    void Start()
    {
        
    }
#if UNITY_ANDROID
    public void NotificationExample(DateTime timeToFire) {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel() {
            Id = channelIdExample,
            Name = "Example Name",
            Description = "Example Description",
            Importance = Importance.Default,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification() {
            Title = "Where are you?",
            Text = "Com back and play",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = timeToFire
        };

        // AndroidNotificationCenter.SendNotification(notification, channelIdExample);
        AndroidNotificationCenter.SendNotificationWithExplicitID(notification, channelIdExample, notificationId);

    }

    void OnApplicationFocus(bool focusStatus) {
        if (!focusStatus) {
            // DateTime whenToFire = DateTime.Now.AddDays(1);
            DateTime whenToFire = DateTime.Now.AddSeconds(10);
            NotificationExample(whenToFire);
        } else {
            // AndroidNotificationCenter.CancelAllScheduledNotifications();
            AndroidNotificationCenter.CancelScheduledNotification(notificationId);
        }
    }
#endif
}
