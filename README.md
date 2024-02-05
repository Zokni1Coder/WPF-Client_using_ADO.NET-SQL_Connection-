# WPF-Client_using_ADO.NET-SQL_Connection-

## This is one of my projects from the second semester of university.

## Classes

### User class

#### Fields

1. nev (the user name)
- String
- I did not add any rules, but we can use a simple regex that will check if it only contains letters
- Duplicate names are not allowed

2. kod (password)
- String

3. adminE (Admin or not)
- Bool
- True if the user hase admin rights

### versenyzo class (Driver class)

#### Fields

1. rajtszam (racing number)
- Integer
- The value must be in the [1-99] range
- Duplicate numbers are not allowed

2. nev (name)
- String
- Duplicate names are not allowed

3. csapat (team)
- String
- All options are actually in one Array, but we can also use Enums

4. szuletesiEv (Birth date)
- Integer
- The value must be in the [(Current year - 100), (Current year - 18)]

## Windows

| Windows |
| ------- |
| Login page |
| Registration page |
| Main page |

## Methods

| Login page | Registration page | Main page |
| ---------- | ------------ ---- | --------- |
| bejelentkezesClick() | foglalt() | fillcombos() |
| nyitas() | Button_Click() | Button_Click() |
| Button_Click() | | Button_Click() |
| | | Button_Click_1() |
| | | foglalt() |
| | | Button_Click_2() |
| | | torlesGomb_Click() |
| | | lista_SelectionChanged() |
| | | Button_Click_3() |
| | | Button_Click_4() |
| | | Button_Click_5() |

### Methods on Login page

1. bejelentkezesClick()
- This check whether  a correct username and password were provided
- In cases where the user doesn't have admin rights, the insert, delete, and add features are unavailable

2. nyitas()
- Hide the current window and open the Main window

3. Button_Click()
- This opens the Registration window

### Methods on Registration page

1. foglalt()
- This checks if the username is already in use

2. Button_Click()
- This inserts the new user into the database
- It checks whether the username is not in use, the admin password is correct (it its not empty) and the two given passwords are the same
- In case the registration is successful, it opens the Login window; otherweise, it shows a MessageBox about unsuccessful registration

### Methods on Main page

1. fillcombos()
- Selects all driver from the database
- Fills or refreshs the ComboBoxes, the ListView and the GridView with the correct datas

2. Button_Click()
- Shows every driver in the database (It simply calls the fillcombos() method) 

3. Button_Click_1()
- Used to search for a driver with their racing number
- Displays only the data of the found driver in the ListView and in the GridView

4. foglalt()
- Checks whether the racing number or the name is already in use

5. Button_Click_2()
- Used to insert a new driver in the database
- Checks whether the racing number is in the [1,99] range or already in use
- Checks if the name is already in use 
- Checks if the driver's age is in the [(Current year - 100),(Current year - 18)] range
- In case the insertion is unsuccessful, shows a MessageBox with informations

6. torlesGomb_Click()
- Used to delete the driver from the database
- Updates the ComboBoxes, ListView and GridView (Calls the fillcombos() method)

7. lista_SelectionChanged()
- When the user clicks on one element (driver) in the ListView, the TextBoxes' content will change to the driver's data

8. Button_Click_3()
- Used to modify the data of a driver, except the racing number and the name
- The criteria for the driver's age are the same
- In case, the modification is unsuccessful, shows informations in the MessageBox 
- Finally updates the ComboBoxes, the ListView and the GridView (with fillcombos() method)

9. Button_Click_4()
- Used to quit the program

10. Button_Click_5()
- Used to switch user accounts