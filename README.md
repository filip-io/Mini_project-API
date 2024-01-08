# Mini Project: API

<b>Greetings! This is my first API. It's built using ASP.NET Core with Minimal API, implementing RESTful architecture.</b>
<br>The API is managing viewing and storing people, their interests and corresponding links using HTTP verbs.

<br>

### ER (Entity Relationship) diagram 
Illustrates appropriate normalization
<br>

![ER-Diagram](/Diagrams/ER_diagram_Mini_project-API_dark.png)

<br>

### UML (Unified Modeling Language) diagram
Graphical representation of the structure, behaviors and interactions.

![UML-Diagram](/Diagrams/UML_diagram_MiniAPIproject_dark.png)




## Endpoints and how to use them



#### **Get all people in the database** 
Leave request body empty to see all people. 
<br>To narrow down your results, add the first two letters of the persons first name.
```
POST /people/

{
	"search":"jo" // if person first name is e.g. "John"
}
```
<br>

#### **Pagination** 
Replace *{pageNumber}* and *{pageSize}* with your desired choices.
```
GET /people/pageNumber/{pageNumber}/pageSize/{pageSize}
```

<br>

#### **Hierarchical info** 
Replace *{personId}* with ID of the person you want to see all info about. Returns info hierarchically in JSON format.
```
GET /people/{personId}/hierarchical
```

<br>

#### **Add person to database** 
Provide the mandatory info in the request body to add a new person to the database.
```
POST /people/add/

Using JSON:
{
	"firstName": "Tony",
	"lastName": "Stark",
	"phoneNumber": "0705456267"
}
```

<br>


#### **Get all interests in the database**
```
GET /interests
```
<br>


#### **Get a specific persons interests**
Replace *{personId}* with the desired persons ID.
```
GET /interests/{personId}
```
<br>


#### **Connect a specific person to an interest**
Replace *{personId}* with the desired persons ID and *{interestId}* with the interest ID.
```
POST /people/{personId}/interests/{interestId}
```

<br>

#### **Get all links connected to a specific person**
<br>Replace *{personId}* with the desired persons ID.
```
GET /people/{personId}/interests
```


<br>

#### **Add a new link to a specific person and interest**
Replace *{personId}* with the desired persons ID and *{interestId}* with the interest ID.
<br>Add the link to the request body.
```
POST /people/{personId}/interests/{interestId}/addLink

{
	"Url": "https://en.wikipedia.org/wiki/Chemistry"
}
```
