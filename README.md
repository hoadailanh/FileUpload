# File Upload with Asp .NET Core 2.1 and Angular 5
This application allows a user to upload a csv file in any format and visualize it in a browser.
Tools used: Visual Studio 2017, Node.js, Angular5, Boostrap 4.1.3, ng-boostrap 1.1.2, Asp .NET Core 2.1 Web API
## Instructions
Open FileUpload.sln in visual studio 2017. You should have node.js installed/integrated with VS 2017 for the UI app (angular 5) to download package dependencies. 
Run the app (both UI and API): Build the solution and select FileUpload project as your startup project and run it using ISS in visual studio

If everything goes well, you should see the brower open and point to http://localhost:31238/.

## Test Files & Unit Tests
- There are test csv files in API.Tests/TestCSVFiles that you can use to test the application.
- API Unit Tests: API.Tests hosts unit tests for API business layer
- UI Unit Tests: ClientApp/src/app/components/upload/upload.component.spec.ts contain unit tests for the upload component
- UI e2e Tests: ClientApp/e2e
