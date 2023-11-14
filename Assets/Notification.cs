using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class Notification : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Delete All Notis When Clicked Or Game Started
        AndroidNotificationCenter.CancelAllDisplayedNotifications();


        //Notification Cantre
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications Channel",
            Importance = Importance.Default,
            Description = "Remainder notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //Creating Noti To Send
        var notification = new AndroidNotification();
        notification.Title = "Hey! Come Back!";
        notification.Text = "You Have To Beat "+PlayerPrefs.GetString("HighScorePerson")+"'s HighScore";
        notification.FireTime = System.DateTime.Now.AddHours(6);


        var notification2 = new AndroidNotification();
        notification2.Title = "Hey! Come Back!";
        notification2.Text = "Cars Are Waiting To Be Unlocked";
        notification2.FireTime = System.DateTime.Now.AddHours(12);

        var notification3 = new AndroidNotification();
        notification3.Title = "Hey! What's Your HighScore";
        notification3.Text = PlayerPrefs.GetString("HighScorePerson")+" Has "+ PlayerPrefs.GetFloat("HighScore").ToString();
        notification3.FireTime = System.DateTime.Now.AddHours(4);
        //Sending Noti
        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        var id2 = AndroidNotificationCenter.SendNotification(notification2, "channel_id");
        var id3 = AndroidNotificationCenter.SendNotification(notification3, "channel_id");

        //Rescheduele All Noti If app Started
        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id2) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification2, "channel_id");
        }
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id3) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification3, "channel_id");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
