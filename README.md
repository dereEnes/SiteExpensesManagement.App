```
dereEnes/SiteExpensesManagement.App
```
# PatikaDev-Logo-Net-Bootcamp Graduation Project
Aparments management app with .Net Core 3.1 MVC & API. API only for payment bring user credit card, add credit card info, check balance etc. Rest of the things in .Net core web app. There are a lot of pages; CRUD for apartments,cars, rooms, bills and dues also there is a page for sending messages to admin.

### This is my UML class diagram
![uml](https://user-images.githubusercontent.com/78616137/164682631-64f86b6f-254d-4e90-ab0c-e1f0c65e5b8c.JPG)



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
### Then users can pay the dues,bills with clicking the "Öde" button. <hr/>
![userBills](https://user-images.githubusercontent.com/78616137/164439988-6ae15e12-626c-4b6c-9ee0-583cd57477c5.JPG)
### The "Öde" button redirects user to this page, and here user can make an payment with his/her credit card. The card info showed below comes from API according the userId <hr/>
![ödeme ekranı](https://user-images.githubusercontent.com/78616137/164679721-1832544e-ccc4-4d92-b82c-67beb06c10b6.JPG)
### And Users can see their paid dues and bills

![userpayments](https://user-images.githubusercontent.com/78616137/164471994-12bf3255-ba6d-4768-aef1-ffa35d98ea39.JPG)

### Here is the mongoDb side
![mongoDb](https://user-images.githubusercontent.com/78616137/164678859-fb194ab0-bbfd-4f57-a8bb-fb8c18c5e2de.JPG)

### User also can send message to admin, show forwarded Messages, can see if message has been read by the admin.<hr/>
![sendmessage](https://user-images.githubusercontent.com/78616137/164444857-a99fb972-2651-4ff1-ba7c-bca8b1f1599e.JPG)
![mesajlarım](https://user-images.githubusercontent.com/78616137/164684385-64d304d1-de9a-41b1-9ba9-7aa453e5cd8a.JPG)
![messageDetail](https://user-images.githubusercontent.com/78616137/164445253-402c04d6-4d7b-4688-bfe3-beedb9075869.JPG)
## These are the messages that comes from users

![adminmesaj](https://user-images.githubusercontent.com/78616137/164685308-af3e988b-694b-49f6-9a37-c5a36a384afe.JPG)

### Admin Can Show users, Update users, Delete Users <hr/>

![listusers](https://user-images.githubusercontent.com/78616137/164453451-4a2437e6-a2c1-43ec-9a11-6a8d05e3d972.JPG)
![updateuser](https://user-images.githubusercontent.com/78616137/164453491-03736f90-2d34-475f-a807-6d88d6f61bca.JPG)


