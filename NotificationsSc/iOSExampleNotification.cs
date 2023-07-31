using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSExampleNotification : MonoBehaviour
{
    [SerializeField] string notificationId = "exampleNotif";

#if UNITY_IOS
    public void NotificationExample (string notificationId) {
        iOSNotification notification = new iOSNotification() {
            Identifier = notificationId,
            Title = "Example Title",
            Subtitle = "Where are you?",
            Body = "Come back and play",
            ShowInForeground = false,
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger() {
                TimeInterval = new System.TimeSpan(0, 0, 0, 10),
                Repeats = false,
            }
        };
        iOSNotificationCenter.ScheduleNotification(notification);
    }

    void OnApplicationFocus(bool focusStatus) {
        if (focusStatus == false) {
            NotificationExample(notificationId);
        } else {
            iOSNotificationCenter.RemoveScheduledNotification(notificationId);
        }
    }
#endif

}
