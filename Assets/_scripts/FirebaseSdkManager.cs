
using Firebase;
using Firebase.Extensions;
using Firebase.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



namespace ZGame.SDK
{
    public class FirebaseSdkManager : Singleton<FirebaseSdkManager>
    {
        bool isInit = false;

        public void Init()
        {
            if (isInit)
            {
                return;
            }
            Debug.Log("Firebase sdk init start@@");
            //ContinueWith      
            //ContinueWithOnMainThread
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
           {
               var dependencyStatus = task.Result;
               if (dependencyStatus == Firebase.DependencyStatus.Available)
               {
                   Debug.Log("dependency status is available!");

#if !UNITY_EDITOR
                    initializeFCM();
#endif
               }
               else
               {
                   Debug.LogError(System.String.Format(
                     "Firebase sdk init fail. Could not resolve all Firebase dependencies: {0}", dependencyStatus));
               }
           });
        }



        public void initializeFCM()
        {
            Debug.Log("Register firebase  token receive");
            Firebase.Messaging.FirebaseMessaging.TokenReceived += FirebaseMessaging_TokenReceived;

            Debug.Log("Register firebase message  receive");
            Firebase.Messaging.FirebaseMessaging.MessageReceived += FirebaseMessaging_MessageReceived;
            isInit = true;
        }


        private void FirebaseMessaging_TokenReceived(object sender, TokenReceivedEventArgs e)
        {
            string token = e.Token;
            Debug.Log("FCM------>Token:" + token);
        }

        private static void FirebaseMessaging_MessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            try
            {
                var notification = e.Message.Notification;
                if (notification != null)
                {
                    Debug.Log("FCM------>From:" + e.Message.From);
                    Debug.Log("FCM------>Title:" + e.Message.Notification.Title);
                    Debug.Log("FCM------>Body:" + e.Message.Notification.Body);
                }
                else
                {

                    if (e.Message.Data != null && e.Message.Data.Count > 0)
                    {

                        foreach (KeyValuePair<string, string> item in e.Message.Data)
                        {
                            Debug.Log("FCM------>Data,key:" + item.Key + ", value:" + item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("messageReceived exception:" + ex.ToString());
                throw;
            }
        }
    }
}