# Task 1 Check list

``` TXT
- [ ] **to get started**
  - [ ] create a tag according to the [semantic versioning](https://semver.org/) compliant with the following syntax 1.a.n where: 1: task number (1 for this stage); a: approach number [1..3]; n: any number you like.
  - [ ] the task's completion has been submitted on the WIKAMP for grading purposes (needs grading). The feedback must contain the tag identifier.
  - [ ] repository contains a program to be used as a starting point - text is in C# and use .NET
  - [ ] build succeeded
  - [ ] The program has layered architecture and contains at least `logic`, and `data` layers
  - [ ] layers are clearly stated using language terms only
- [ ] **Data Layer**
  - [ ] `Data` layer is clearly stated (no database or file access is required)
  - [ ] `Data` API is abstract
  - [ ] layer responsibility is to implement object model representing data of a selected process 
    - [ ] structured data is used to create object model including:
      - [ ] Users: a collection of all actors relevant to the implemented business process (e.g.: readers, customers, suppliers, etc)
      - [ ] Catalog: a dictionary of the goods descriptions (e.g.: books, good )
      - [ ] Process state: description of the current process state (e.g: the current content of the shop, library, etc.)
      - [ ] Events:  description of all events contributing to the process state change in time.
    - [ ] dependency injection is used (additional framework is not required)
- [ ] **Logic Layer**
  - [ ] the layer is clearly stated
  - [ ] the layer API is clearly stated
  - [ ] the layer uses only the abstract `Data` layer API
  - [ ] layer responsibility is to implement the main program functionality of a selected process 
- [ ] **Testing**
  - [ ] the main functionality of the program must be unit-tested - all UTs are green
  - [ ] Unit Test - 2+ testing data generation methods for data layer 
  - [ ] layers are tested independently
  - [ ] only code in the solution is tested
```
