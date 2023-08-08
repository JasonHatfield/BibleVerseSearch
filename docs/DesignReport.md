# Design Report

## Technical Approach

The Bible Verse Search application was designed and implemented using a multi-layered architecture, which separates concerns into distinct layers, improving maintainability and scalability. The application is built on the ASP.NET Core MVC framework, which naturally supports this architecture.

The application consists of the following layers:

1. **Presentation Layer**: This layer is responsible for handling user interactions and displaying data to the user. It includes the Controllers and Views in the MVC architecture.

2. **Business Logic Layer**: This layer contains the business rules and logic of the application. It acts as an intermediary between the Presentation and Data Access Layers.

3. **Data Access Layer**: This layer interacts with the database, performing CRUD operations. It abstracts the underlying database operations from the rest of the application.

The application also utilizes the Data Access Object (DAO) design pattern, which provides a simple, consistent API for database operations, further decoupling the database from the rest of the application.

The application is built with object-oriented programming (OOP) principles. It uses classes and interfaces to model real-world entities and behaviors, and encapsulation to hide implementation details and maintain state.

## Classes, Methods, and Variables

The application includes several classes, each with its own responsibilities:

1. `HomeController`: This controller handles HTTP requests and responses. It uses the `VerseBLL` class to fetch data and pass it to the views.

2. `VerseBLL`: This class contains the business logic for fetching verses. It uses the `IVerseDAO` interface to interact with the database.

3. `VerseDAO`: This class implements the `IVerseDAO` interface and provides methods for fetching verses from the database.

4. `Verse`: This class represents a Bible verse. It includes properties for the book, chapter, verse number, text, and testament.

The application also includes several methods and variables. For a comprehensive list, please refer to the UML diagram and source code.

## Impact on Christian Community

The Bible Verse Search application provides an easy-to-use tool for searching Bible verses, which can aid in Bible study and personal devotion. By allowing users to search the Old Testament, New Testament, or both, it provides flexibility and caters to a wide range of study needs.

The application also has strong customer service aspects. It provides clear error messages for invalid data entry, ensuring users understand how to use the application correctly. It also provides a user-friendly interface, making it accessible to users of all technical skill levels.

In terms of problem-solving capabilities, the application provides a solution to the problem of finding specific verses in the Bible. By allowing users to search for specific words or phrases, it makes it easier to find relevant verses for study or reference.

## Screenshots

<div align="center">

### Home Page
<img src="./images/Screenshot%202023-08-08%20141614.png" width="600" style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);">

---

### Search Page
<img src="./images/Screenshot%202023-08-08%20141918.png" width="600" style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);">

---

### Error Message
<img src="./images/Screenshot%202023-08-08%20141945.png" width="600" style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);">

---

### Old Testament Search
<img src="./images/Screenshot%202023-08-08%20142020.png" width="600" style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);">

---

### New Testament Search
<img src="./images/Screenshot%202023-08-08%20142035.png" width="600" style="box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);">

</div>

---


## Entity-Relationship Diagram

The Bible Verse Search application uses a single table in the database, `t_asv`, which contains the following columns:

- `b`: The book of the Bible, represented as an integer. This column is a foreign key that references the `key_english` table, which contains the names of the books.
- `c`: The chapter number, represented as an integer.
- `v`: The verse number, represented as an integer.
- `t`: The text of the verse, represented as a string.

The `t_asv` table is related to the `key_english` table through the `b` column. Each row in the `t_asv` table represents a single verse in the Bible.


key_english

| b   | n       | 
| --- | ---     |
| 1   | Genesis |
| 2   | Exodus  |
| ... | ...     |

t_asv

| b   | c  | v | t |
| --- | --- | --- | --- |
| 1   | 1 | 1 | In the beginning God created the heavens and the earth. |
| 2   | 1 | 2 | And the earth was without form, and void; and darkness... |
| ... | ... | ... | ... |


In this diagram, `b` in `t_asv` is a foreign key that references `b` in `key_english`. This relationship allows the application to display the name of the book for each verse.