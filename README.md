# theCircuitLive

## Quick reference for useful things

### Add tap recognition to any element that inherits gestures
```csharp
elem.GestureRecognizers.Add(new TapGestureRecognizer
{
 Command = new Command(() => {
  // Whatever operation you want to do  ( this isn't async )
 })
});
```
### Easy way to do an operation in ui thread only after async
```csharp
Task.Run(async() =>
{
 // Do an async operation here, or if you don't actually need to use an await, take async out of the
 // lamba func
 
 Device.BeginInvokeOnMainThread(() => 
 {
  // Do something in the ui thread. 
  })
});
// This is particularly useful when you want to avoid race conditions. The backcode of EventPage shows this being used
```
OVERVIEW: Display Events and link to EventBrite

At the end of this iteration, the app will retrieve event information from the database and present it to the user, who will be accessing the app as a Guest (no registered account).  The app will also provide a link to allow Guests to register for an event.
>>To Do : 
>>>Event Registration (US): Link to Event Brite :

>>>Guest Views Event Title (US): : *DONE*

>>>Guest Views Date (US): : *DONE*

>>>Guest Views Event Speaker (US): : *DONE*

>>>Guest Views Event Description (US): : *DONE*

>>>Establish Web Serv with rest or similar framework for db connection (CONST) : *DONE*
 
>>>etc

Total Estimated Velocity
22 HR



>>>Resources

>>>[create mobile apps with xamarin](https://developer.xamarin.com/guides/xamarin-forms/creating-mobile-apps-xamarin-forms/)

>http://www.looah.com/source/view/2284

>https://www.atlassian.com/git/tutorials/using-branches


