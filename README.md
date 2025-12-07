PolicyCheck.exeを実行してください


``` PolicyCheck.ini
[script]
path=./script/GetPolcyScript.ps1

[policy]
polnum=5
pol01=「ネットワークを使用した通知をオフにする」を有効に設定する,SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications,NoCloudApplicationNotification,REG_DWORD,4,1
pol02=「バルーン通知をオフにする」を有効に設定する,Software\Microsoft\Windows\CurrentVersion\Policies\Explorer,TaskbarNoNotification,REG_DWORD,4,1
pol03=「トースト通知をオフにする」を有効に設定する,SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications,NoToastApplicationNotification,REG_DWORD,4,1
pol04=「ロック画面のトースト通知をオフにする」を有効に設定する,SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications,NoToastApplicationNotificationOnLockScreen,REG_DWORD,4,1
pol05=「通知のミラーリングをオフにする」を有効に設定する,SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications,DisallowNotificationMirroring,REG_DWORD,4,1
```

このアプリは以下のMicrosoft製品を使用しております。


https://github.com/PowerShell/GPRegistryPolicyParser


