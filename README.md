# ConnectWise.Http
A .Net HttpClient wrapper for interacting with the ConnectWise Manage REST API.

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

### GET Request
```C#
using ConnectWise.Http.Modules.Service;

// Build & Send Request
int ticketId = 121;
var request = ServiceModule.Tickets.GetRequest(ticketId);
var response = await client.SendAsync(request);
```

### POST/PUT Request
You serialize the body content before building the request.
```C#
// Build & Send Request
string serializedContent = JsonConvert.SerializeObject(...);
var request = ServiceModule.Tickets.CreateRequest(serializedContent);
var response = await client.SendAsync(request);
```

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

### Modules
Below are the modules currently implemented. You can use the CWRequest object to specify specific endpoints not yet supported here - These serve only to simplify the creation of the request URI.

|   Modules  | Supported |
|------------|:---------:|
|Company     |No         |
|Expense     |No         |
|Finance     |No         |
|Marketing   |No         |
|Procurement |No         |
|Project     |**Yes**    |
|Sales       |No         |
|Schedule    |No         |
|Service     |**Yes**    |
|System      |No         |
|Time        |*Partial*  |