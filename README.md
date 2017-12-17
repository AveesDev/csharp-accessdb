# csharp-accessdb
C# Library to easily execute SQL queries to a Microsoft Access Database

# How to use
1.  Add "AccessDatebase.dll" as a reference to your project.
2.  Add "using AccessDatebase;" to your namespace.
3.  Initialize the database connection by using 
```
    DatabaseConnection.Initialize("Database location here");
```
# How to read records from database
1.   Ensure you've initalized the database connection
2.   Use the function SqlRead to retrieve a string list e.g. :
```
     List <"string"> records = DatabaseConnection.SqlRead("SELECT * FROM Clients);
```
3.   Each columns data will be seperated with a ':' so use string.split(':')[index] to seperate the cell values.
# How to insert, update etc 
1.  Ensure you've initalized the database connection
2.  Use the function SqlUpdate.
3.  Ensure that any column names in the SQL queries are enclosed within square brackets otherwise it'll throw a syntax error. Example:
```
   INSERT INTO clients([username], [password]) VALUES("admin", "password");
```

------------
#Code Example:

```
        void ReadLogins()
        {
            DatabaseConnection.Initialize(@"C:\database.accdb");
            List<string> records =  DatabaseConnection.SqlRead("SELECT * FROM clients");

            foreach(string rec in records)
            {
                MessageBox.Show("Username: " + rec.Split(':')[0] + Environment.NewLine +
                                "Password: " + rec.Split(':')[1]);
            }
        }
        
```        
