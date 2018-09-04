# File Upload with Asp .NET Core 2.1 and Angular 5
Source code is also avaialbe at: https://github.com/hoadailanh/FileUpload.git

## Instructions
Tools used: Visual Studio 2017, Node.js, Angular5, Boostrap 4.1.3, ng-boostrap 1.1.2, Asp .NET Core 2.1 Web API

Runing the app: Unzip and open FileUpload.sln in visual studio 2017. Build the solution and select FileUpload project as your startup project
and run it using IIS in visual studio. You should have node.js installed/integrated with VS 2017 for the UI app (angular 5) to download package dependencies. 

Alternatively, you can run "npm install" in FileUpload\ClientApp to download package dependencies.

If everything goes well, you should see the brower open and point to http://localhost:31238/.

## Unit Tests
- API Unit Tests: API.Tests hosts unit tests for API business layer
- UI Unit Tests: ClientApp/src/app/components/upload/upload.component.spec.ts contain unit tests for the upload component
- UI e2e Tests: ClientApp/e2e
