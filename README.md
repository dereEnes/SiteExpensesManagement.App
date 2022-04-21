```
dereEnes/SiteExpensesManagement.App
```
# PatikaDev-Logo-Net-Bootcamp Graduation Project
Aparments management app with .Net Core 3.1 MVC & API. API only for payment. Rest of the thing in .Net core web app. There are pages; CRUD for apartments,cars, rooms, bills and dues also there is a page for sending messages to admin.

### Topics
* FluentValidation
* AutoMapper
* EntityFrameworkCore
* Generic Repository
* UnitOfWork
* ASP.Net Identity
* MongoDb

### Getting Started
#### Clone Repo
git clone https://github.com/dereEnes/SiteExpensesManagement.App.git

Register
* Admin can register new person from this page
* All fields are required
* Email Validation
* If result successfull then redirect to Index page where listing all users <hr/>
![register](https://user-images.githubusercontent.com/78616137/164430655-2da36a91-ac1b-4403-96b8-ede8df80c98b.JPG)

### After that, admin can add an apartment to this user this page <hr/>
![daireOluştur](https://user-images.githubusercontent.com/78616137/164431034-1298b758-099f-4486-8540-a247e9e9c2bc.JPG)
### Admin can show apartments list, details,update, delete page <hr/>
![apartmanListele](https://user-images.githubusercontent.com/78616137/164431736-deda35e4-2985-48aa-879d-ef908cadfe7a.JPG)
![apartmentUpdate](https://user-images.githubusercontent.com/78616137/164431878-308a178c-fc06-4c5c-849b-a754d97d3ddc.JPG)
![apartmentDelete](https://user-images.githubusercontent.com/78616137/164432030-8b7f5210-7494-410d-a101-1e13bccef4c2.JPG)
### Admin can add bill And Dues for an apartment only, for whole block and for all apartments in this site (Textbox show according the selected combobox value)<hr/>
![AddDues1](https://user-images.githubusercontent.com/78616137/164438358-5c5e99e0-5390-4c52-b5cc-1089d4b32de9.JPG)
![addDues2](https://user-images.githubusercontent.com/78616137/164438406-36cd9a7b-7876-4d0d-8c1c-7518cb3accf5.JPG)
![addDues3](https://user-images.githubusercontent.com/78616137/164438443-0f819cc4-20f4-4d01-9d34-4626a3625bd1.JPG)
![dues](https://user-images.githubusercontent.com/78616137/164439485-7c4a48ce-82fa-4acb-ab28-d743958b80ed.JPG)
### Then users can pay the dues,bills with clicking the "Öde" button,
![userBills](https://user-images.githubusercontent.com/78616137/164439988-6ae15e12-626c-4b6c-9ee0-583cd57477c5.JPG)
### The "Öde" button redirect user to this page, and here user can make an payment with his/her credit card. The card info showed below comes from API according the userId
![paymentdetail](https://user-images.githubusercontent.com/78616137/164440418-fc2dcf70-a8c2-4601-bb0b-029c7e1cbcdc.JPG)


