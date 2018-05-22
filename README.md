# ConnectWise.Http
A .NET HttpClient wrapper for interacting with the ConnectWise Manage REST API.

# Installation
```
NuGet PM> Install-Package ConnectWise.Http
```

# Usage

### Client Setup
```C#
using ConnectWise.Http;

// Create Settings
var settings = new CWApiSettings(
  "https://cw.siteurl.com",
  "companyName",
  new MemberAuthSettings("publicKey", "privateKey")
  );

// Create HTTP Client
var client = new CWHttpClient(settings);
```

#### Providing an existing HttpClient
There is also an overloaded constructor that allows you to provide an existing instance of an `HttpClient`, so that `CWHttpClient` does not create its own `HttpClient` instance. It is generally good practice to only construct & use a single `HttpClient` instance throughout the lifetime of your application (with some exceptions relating to when DNS changes are made during the lifetime of your application) - this is because each `HttpClient` constructed will claim a web socket.

So, provide an `HttpClient` instance to `CWHttpClient`, which exclusively uses the `HttpClient.SendAsync(HttpRequestMessage message)` method so that you don't need to worry about `CWHttpClient` making any changes to the default settings of the `HttpClient` that you provided.

---

### GET Request
```C#
using ConnectWise.Http.Modules.Service;

// Build & Send Request
int ticketId = 121;
var request = ServiceModule.Tickets.GetRequest(ticketId);
var response = await client.SendAsync(request);
```

---

### POST/PUT Request
You serialize the body content before building the request.
```C#
// Build & Send Request
string serializedContent = JsonConvert.SerializeObject(...);
var request = ServiceModule.Tickets.CreateRequest(serializedContent);
var response = await client.SendAsync(request);
```

---

### PATCH Request
ConnectWise.Http provides a ConnectWise Patch Operation object as per their REST developer documentation.
```C#
// List Patch Operations
var operations = new List<CWPatch>();
operations.Add(new CWPatch {
  Op = CWPatchOperation.Replace,
  Path = "status/name",
  Value = "Closed"
  });
  
// Build & Send Request
int ticketId = 121;
var request = ServiceModule.Tickets.UpdateRequest(ticketId, operations);
var response = await client.SendAsync(request);
```

---

### Deserialization
Once you have your response, the `CWResponse` object can attempt to deserialize to your specified class type.
```C#
// Where "TConnectWiseTicket" is your custom type.
int ticketId = 121;
var request = ServiceModule.Tickets.GetRequest(ticketId);
var response = await client.SendAsync(request);

// Using Deserialize
// An exception will be thrown if deserialization fails
var ticketOne = response.Deserialize<TConnectWiseTicket>();

// Using TryDeserialize
if (response.TryDeserialize<TConnectWiseTicket>(out TConnectWiseTicket ticketTwo) {
  // Do something with ticketTwo
} else {
  var exception = response.DeserializationException;
  // Error Logging
}
```

---

### Modules
Below are the modules currently implemented. You can use the CWRequest object to specify specific endpoints not yet supported here - These serve only to simplify the creation of the request URI.

|   Modules  | Supported |
|------------|:---------:|
|Company     |**Yes**    |
|Expense     |**Yes**    |
|Finance     |**Yes**    |
|Marketing   |No         |
|Procurement |No         |
|Project     |**Yes**    |
|Sales       |No         |
|Schedule    |**Yes**    |
|Service     |**Yes**    |
|System      |*Partial*  |
|Time        |**Yes**    |
