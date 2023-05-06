# LuxeLane Fullstack

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

## About
The e-commerce website project provides a comprehensive range of features for both customers and administrators. The application includes options for both light and dark modes, catering to user preferences. Users can browse and sort products by category or price, add products to their cart, and register for an account or log in with their email and password. Logged-in customers can create new products, while administrators have the additional capabilities of creating, deleting, and editing products. The application also allows users to remove products from their cart and update the quantities of products within the cart. By developing this project, I gained a deeper understanding of the React lifecycle, state management with Redux, and authentication using JWT token in .NET. I also learned how to integrate TypeScript with React for improved error suggestions and connect the front-end with the back-end. This experience allowed me to apply various technologies in a real-world setting and understand how to integrate different components into a seamless and user-friendly application, contributing to my growth as a developer.

## Technology
* Frontend: SASS, TypeScript, React, Redux Toolkit. Live demo [https://luxelane.netlify.app/](https://luxelane.netlify.app/). 
* Frontend repository [https://github.com/HungHoang108/luxelane](https://github.com/HungHoang108/luxelane)
* Backend: ASP .NET Core, Entity Framework Core, Docker, Azure, PostgreSQL. Live demo [https://luxelane.azurewebsites.net](https://luxelane.azurewebsites.net/swagger/index.html).

## Run the app with Docker
Ensure that you have Docker Desktop installed. Then run below commands on the terminal:
- docker pull hunghoang108/lux1:latest
- docker run -p 8080:80 hunghoang108/lux1

Note: The process of containerizing the database is still ongoing.

## Run the app with Github repository
- Step 1: Fork and clone the project to your local machine
- Step 2: Cd to cinemaApi repository and install all nescessary nuget packages
- Step 3: In the appsettings.Development.json file, add your local database address to DefaultConnection
- Step 4: run command 'dotnet watch' to run the project

## How to test the app
- Step 1: Cd to backend.Test repository and install all nescessary nuget packages
- Step 2: run command 'dotnet test'

## Project Structure

```
fs13-FullStack
├─ .git
├─ .gitignore
├─ backend
│  ├─ appsettings.Template.json
│  ├─ Authorizatioin
│  │  └─ SameUserIdRequirement.cs
│  ├─ backend.csproj
│  ├─ Controllers
│  │  ├─ AddressController.cs
│  │  ├─ BaseController.cs
│  │  ├─ CategoryController.cs
│  │  ├─ OrderController.cs
│  │  ├─ OrderProductController.cs
│  │  ├─ ProductController.cs
│  │  └─ UserController.cs
│  ├─ Db
│  │  ├─ ConfigExtension.cs
│  │  ├─ DataContext.cs
│  │  └─ DataContextSaveChangesInterceptor.cs
│  ├─ DTOs
│  │  ├─ AddressDto.cs
│  │  ├─ CategoryDto.cs
│  │  ├─ OrderDto.cs
│  │  ├─ OrderProductDto.cs
│  │  ├─ ProductDto.cs
│  │  └─ UserDto.cs
│  ├─ Helpers
│  │  ├─ IntExtension.cs
│  │  └─ ServiceException.cs
│  ├─ Mapping
│  │  └─ MappingProfile.cs
│  ├─ Middlewares
│  │  └─ ErrorHandlerMiddleware.cs
│  ├─ Models
│  │  ├─ Address.cs
│  │  ├─ BaseModel.cs
│  │  ├─ Category.cs
│  │  ├─ Enum
│  │  │  └─ OrderStatus.cs
│  │  ├─ Image.cs
│  │  ├─ Order.cs
│  │  ├─ OrderProduct.cs
│  │  ├─ Product.cs
│  │  └─ User.cs
│  ├─ Program.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ Repositories
│  │  ├─ AddressRepo
│  │  │  ├─ AddressRepo.cs
│  │  │  └─ IAddressRepo.cs
│  │  ├─ BaseRepo
│  │  │  ├─ BaseRepo.cs
│  │  │  └─ IBaseRepo.cs
│  │  ├─ CategoryRepo
│  │  │  ├─ CategoryRepo.cs
│  │  │  └─ ICategoryRepo.cs
│  │  ├─ OrderProductRepo
│  │  │  ├─ IOrderProductRepo.cs
│  │  │  └─ OrderProductRepo.cs
│  │  ├─ OrderRepo
│  │  │  ├─ IOrderRepo.cs
│  │  │  └─ OrderRepo.cs
│  │  └─ ProductRepo
│  │     ├─ IProductRepo.cs
│  │     └─ ProductRepo.cs
│  └─ Services
│     ├─ AddressService
│     │  ├─ AddressService.cs
│     │  └─ IAddressService.cs
│     ├─ BaseService
│     │  ├─ BaseService.cs
│     │  └─ IBaseService.cs
│     ├─ CategoryService
│     │  ├─ CategoryService.cs
│     │  └─ ICategoryService.cs
│     ├─ OrderProductService
│     │  ├─ IOrderProductService.cs
│     │  └─ OrderService.cs
│     ├─ OrderService
│     │  ├─ IOrderService.cs
│     │  └─ OrderService.cs
│     ├─ ProductService
│     │  ├─ IProductService.cs
│     │  └─ ProductService.cs
│     └─ UserService
│        ├─ ITokenService.cs
│        ├─ IUserService.cs
│        ├─ JwtTokenService.cs
│        └─ UserService.cs
├─ backend.Test
│  ├─ AddressRepoTests.cs
│  ├─ backend.Test.csproj
│  └─ Usings.cs
├─ fs13-FullStack.sln
└─ README.md

```