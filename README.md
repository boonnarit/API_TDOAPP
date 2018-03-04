## API_TODOAPP

## Supported Platforms
* .NET 4.5.2 
* MySql

## Getting Started
1. Setup IIS to create new site and set physical path to this project (..\TO-DO-APP\TO-DO-APP) 
```
   If the site can't start or get problem about permission you must turn on all of windows features about IIS.
```
2. import tododb_task_to_do.sql to MySql Database
3. config connectionStrings (..\TO-DO-APP\TO-DO-APP\Web.config) as your information database

## Detail of Task object
```jason
 {
        "Task_id": "1",
        "Subject": "Test Task",
        "Detail": "This is detail of task.",
        "Status": "0"
    }
```
## Usage examples
```
http://localhost:1412/api/getlist/alltask
```

##Routes
1.For view all item in the list 
this route return list of Task object
```
GET /api/getlist/alltask
```
2.For view a single task in the list
this route get TaskId and return jason object
```
GET /api/getlist/singletask?TaskId=2
```
3.For add a task to the list
this route get Task object and return boolean
```
POST /api/getlist/addtask
```
4.For edite existing task
this route get Task object and return boolean
```
POST /api/getlist/edittask
```
5.For set the task status
this route get Task object and return boolean
```
POST /api/getlist/changestatustask
```
6.For delete a task from the list
this route get TaskId and return boolean
```
GET /api/getlist/deletetask?TaskId=5
```