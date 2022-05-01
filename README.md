# AutodeskAppStore.Entitlement

[![NuGet version (AutodeskAppStore.Entitlement)](https://buildstats.info/nuget/AutodeskAppStore.Entitlement)](https://www.nuget.org/packages/AutodeskAppStore.Entitlement)

AutodeskAppStore.Entitlement is a library that provides the ability to check if the currently signed in user has a valid Entitlement to use an app from the Autodesk App Store. 

## Usage
This library contains a public `EntitlementService` class which contains a method called `ValidAppUser()`. The App Id needs to be passed in and it will return a bool value on whether the current user has a valid Entitlement to use the app.

If the user is not signed in to Inventor using their Autodesk ID, the Autodesk sign in window will be presented to them.

The `ValidAppUser()` method can either be used as an extension method of `Inventor.Application` or by calling it directly from the `EntitlementService` class and passing in the `Inventor.Application` instance and the App Id. 


```csharp
bool validUser = EntitlementService.ValidAppUser(inventor, "insert_App_Id_here");
```

or 

```csharp
bool validUser = inventor.ValidAppUser("insert_App_Id_here");
```

## Legal

This library is not affiliated with with Autodesk or its subsidiaries. Autodesk Inventor is a registered trademark of Autodesk, Inc. A license of Autodesk Inventor is required to use this library as it is dependent on the application interop.
