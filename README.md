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
To narrow down your results, add the first two letters of the persons first name. 
<br> Leave request body empty to see all people. 
```
POST /people/

Using JSON:
{
	"search":"wa"
}
```
<img src="/Images/Get_all_people_search_ex.jpg" width="33%"> <img src="/Images/Get_people_search.jpg" width="33%">
<br>
```
POST /people/
```
<img src="/Images/Get_all_people.jpg" width="33%">
<br>

#### **Pagination** 
Replace *{pageNumber}* and *{pageSize}* with your desired choices.
```
GET /people/pageNumber/{pageNumber}/pageSize/{pageSize}
```
<img src="/Images/Get_pagination.jpg" width="33%">

<br>

#### **Hierarchical info** 
Replace *{personId}* with ID of the person you want to see all info about. Returns info hierarchically in JSON format.
```
GET /people/{personId}/hierarchical
```
<img src="/Images/Get_hierarchical.jpg" width="33%">

<br>

#### **Add person to the database** 
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
<img src="/Images/Post_add_person.jpg" width="33%">

<br>


#### **Get all interests in the database**
```
GET /interests
```
<img src="/Images/Get_all_interests.jpg" width="33%">

<br>

#### **Add interest to the database**
Provide necessary info to the request body
```
POST /interests

Using JSON:
{
	"name": "HiFi",
	"description": "High fidelity is the high-quality reproduction of sound."
}
```
<img src="/Images/Post_add_interest.jpg" width="33%">

<br>

#### **Get a specific persons interests**
Replace *{personId}* with the desired persons ID.
```
GET /interests/{personId}
```
<img src="/Images/Get_specific_person_interests.jpg" width="33%">

<br>


#### **Connect a specific person to an interest**
Replace *{personId}* with the desired persons ID and *{interestId}* with the interest ID.
```
POST /people/{personId}/interests/{interestId}
```
<img src="/Images/Post_new_interest.jpg" width="33%">

<br>

#### **Get all links connected to a specific person**
Replace *{personId}* with the desired persons ID.
```
GET /people/{personId}/interests
```
<img src="/Images/Get_all_links_specific_person.jpg" width="33%">

<br>

#### **Add a new link to a specific person and interest**
Replace *{personId}* with the desired persons ID and *{interestId}* with the interest ID.
<br>Add the link to the request body.
```
POST /people/{personId}/interests/{interestId}/addLink

Using JSON:
{
	"url": "https://en.wikipedia.org/wiki/Chemistry"
}
```
<img src="/Images/Post_add_new_link.jpg" width="33%">
