[![Build Status](https://dev.azure.com/cloud5mins/AzUnzipEverything/_apis/build/status/FBoucher.AzUnzipEverything?branchName=master)](https://dev.azure.com/cloud5mins/AzUnzipEverything/_build/latest?definitionId=23&branchName=master)  [![Serverless Library](https://img.shields.io/badge/Serverless%20Library-%E2%9C%94%EF%B8%8Fyes-blue?style=flat&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFUAAABVCAMAAAAPK1hoAAAAgVBMVEUAZ7gAXrUAVbMAUbMAZLgAX7z/vgD80Rb////+vA7/1AEAWrXL2Ov9yBL3+/61x+J3nM2IqNMAbbwATLHf6POguNrV4O9GgcKUr9XEpGPasmiovdwicbhhjsdogKDRsVrav0/80QqYlYmyn3ru9PpJdqj3uguDjJXsyTLotDfCsG7PqiWtAAAE30lEQVR4AcWZ3XLbvg7EQRJK3VLftGX3WKmb1FF7+v4P+I+pQIygdSznpjuTO+c34IpYgRRtbqnsql297+mifl/vqq7c3NINan5og/WGmUYxG29De8g/T81rZw3TUmysq/PPUMsjW0PXZSwfyzup5cF5TogMyoWmvId6dLMy+fl/WCd7XE3tWk8zZX++JT2806/Mt906ahN4DuUf375M+pr08P+MiEOzgrqVQpOyv1eoL0yv8u32FjV3TFr85WmCFq+0Yfx7XT9Fscs/pu4CLcS/VamyfiZR2H1EbRwtlZ0StXhH/ZGo5Jrr1NoS0pMqNa0/ydbXqA2EZs+q1EGvf8Q2mLpzBKk/ExWtX+R2iJoHCOUePqvvGWmFfEndqkqxAVLpgKIsbBfUlnXaiQFPqtRB1q9TkltNbbwKur6OUc0v70uVR3VZP3Pdq6j0zZzaBSK9Uc6X8rNf4FkNsbDzciuGTqho/fYQN4W5xNXT0tXfTGTiIz9Y4IFQjx5AN41JcSWlyvrJNBuA9cdELR2CVn6MK+3q8AaoENaVE/VgwHauHBGxMiCuP6OoUIHmMYeRqkt1xwQFBjycsumXI/boFsWSuAqgyoCo4aFnvSrBirMjlfkdtBKoiisp9TnDZomYR2puAVTndaHWfx1r80itDYlsgqq8llZ9YbqBNXWkuvSTXP0kbYBp/XOxvAXyd5QLNbcAquNKWvW70jOTbdJ/iQU0bVa2CarzOvXVXENPJNjc8rRlKUYAhHKv+kpJAlFjud1QGeSdrqDv4+orUnoh2nqGDSV1NkJ9p6ESV/KspFw0EPgR2/mx9o4qH6HbBZRSXmtkGogUdhuxvqKdAVBlQKGUugxizY5qxlAxAAh2mX+csFzTnjFU4kpLXB5Symgs76nHUIkroFnKQmxP5HM4ZLBAtIr0lsHY3BORO8tLSo2Xc03UcVMREIdIOru4u0YDghpZTqe/p9PPSX+k1NRUWmYfSbEDmM5oeONsLhlhUlNpcR9BZ+ZxTNkkLFYaYQo5ZYBKywTticzjG9YSlrSEDLAvfBW6Zb4w9yyNAcdi1RLSVBAqvcV7qlnmCoDVmVCopoJQ4jrmAMBiA+LoSvwhNOZA5WWsB1hlQKE2FYTGzOqsJC/AqkxQmwpDY76WIWUZnI9TJhT66IKhFEp5b6U23tT+igGS1BCaT1Bu5R2LsNoA2VQYajmNhbN5gAzEigFgUyEo2Xw+u7DflxorQ+wFqpIaQ8npOYtMwioDCpTU/nEJNfViJiTTnjV2NECSGsS0QMUAmV8B9tHPLh0KkNQQyoxmbWJO2GSANBWGolm7VHnN2xFrkgHFsqkMhJIr4RkmDR2PPA2xktQQis8wulhi043/IVN8sWwqmyuolIrPhmns7KwYAJrKdgjqj/gcK9iqPO/5zQDUVLw/l5XON27hmTvJs+c3A4qHgZZiz56UQofuB/C1E0xqJN+guwx87VSgpEbiduW9S/ZqAEpqKLdFd0TYgAIkNVTI8X0WNAAkNZTbrbh7k3Mc2FRQtllzTyjnuIHWQes77jS/gZkayTWr7l/FgO+roGG36q5YDBh4BZNdfse9NvdPa5rKt9t77uD5eUVTcWju+17AK0z1bXfftw3ubzaVccf7v8N8DGVvD+W//2Z0//etf/0t7vPfDf8DSCylI22trFIAAAAASUVORK5CYII=)](https://serverlesslibrary.net/sample/9a3f2929-4e4b-4386-ae22-93154e5d2f4c)

# AzUnzipEverything

A simple Azure Function to Unzip files from a blob storage to another one

This current version only supports ".zip"

## How to deploy

To deploy all the resources in your Azure subscription, just click on the **Deploy to Azure** button

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FFBoucher%2FAzUnzipEverything%2Fmaster%2Fdeployment%2FdeployAzure.json?WT.mc_id=cloud5mins-github-frbouche" target="_blank"><img src="https://azuredeploy.net/deploybutton.png"/></a>

Fill-up the form and voila! It will be automatically deployed in your Azure subscription. If you don't own an Azure subscription already, you can create your **free** account today. It comes with 200$ credit, so you can experience almost everything without spending a dime. 
[Create your free Azure account today](https://azure.microsoft.com/en-us/free?WT.mc_id=tohack-github-frbouche)

Learn more on [how to deploy you Azure Function automatically or using the Azure Resource Manager (ARM) template](https://docs.microsoft.com/en-us/azure/azure-functions/functions-infrastructure-as-code?WT.mc_id=cloud5mins-github-frbouche)

![CreationForm][CreationForm]

## How to use it.

You can upload files to an Azure Blob storage using many different tool and code, but for this quick introduction let's use the Azure Portal.

Once [deployed](https://github.com/FBoucher/AzUnzipEverything#how-to-deploy), open the Azure portal [portal.azure.com](https://portal.azure.com?WT.mc_id=cloud5mins-youtube-frbouche)

1. navigate the resource Group you just deployed (ex: demoAzUnzipEverything).

    ![resourceGroup][resourceGroup]

1. Select the **Storage Account** that starts by "dropzone".
1. Click on **Blobs**, in the middle of the screen.
1. Click on the **input-files**. 
1. Click on the Upload button, and you can now upload a zip file.

    ![uploadFile][uploadFile]

1. After a few second the files you be Unzipped into the blob storage **output-files**.


## Continuous Integration (CI)

As you can see by the status badge [![Build Status](https://dev.azure.com/cloud5mins/AzUnzipEverything/_apis/build/status/FBoucher.AzUnzipEverything?branchName=master)](https://dev.azure.com/cloud5mins/AzUnzipEverything/_build/latest?definitionId=23&branchName=master) at the top of the page this project is automatically build at every push. 

Have a look, the [Azure DevOps](https://dev.azure.com/cloud5mins/AzUnzipEverything/) project is **public**! 


### Create a Continuous Integration, Continuous Deployment (CI-CD) for your Azure Function

In this video, I show you how to write an Azure Resource Manager (#ARM) template to deploy automatically your serverless Azure Function to Azure. It can be then used with a "Deploy to Azure" button from GitHub or any website, or in an Azure Pipeline to complete a Continuous Integration, Continuous Deployment (CI-CD) solution.

[![FunctionCICD][FunctionCICD]](https://www.youtube.com/watch?v=GRztpy337kU)


There is also a **written version** if you prefer reading: http://www.frankysnotes.com/2019/07/four-ways-to-deploy-your-azure-function.html



## TODOs

A GitKraken [Glo board](https://app.gitkraken.com/glo/board/XRYx_9FgZwAVbri7) is also available.

- [ ] Add Support for .rar
- [X] Add ARM template
- [X] Add a Deploy to Azure button

## More details

I have a [blob post](https://www.frankysnotes.com/2019/02/how-to-unzip-automatically-your-files.html) about this Azure Function. 

I also have a video where I build and test the function.

[![Auto-UnzipFunction_YT][Auto-UnzipFunction_YT]](https://www.youtube.com/watch?v=GRztpy337kU)
  

I also have an extended version where I introduce more the Visual Studio Extension to work with Azure Function. And explain more details about the Azure Function V2.

[![AzureFunctionWithVSCode_YT][AzureFunctionWithVSCode_YT]](https://www.youtube.com/watch?v=t9PvXWEzU-o)




[CreationForm]: /medias/CreationForm.png "Creation Form"
[resourceGroup]: /medias/resourceGroup.png "Select the ResourceGroup"
[uploadFile]: /medias/uploadFile.png "Upload Zip file"
[FunctionCICD]: /medias/AzureFunctionCICD_YT.png "YouTube thumbnail"
[Auto-UnzipFunction_YT]: /medias/Auto-UnzipFunction_YT.png "YouTube thumbnail"
[AzureFunctionWithVSCode_YT]: /medias/AzureFunctionWithVSCode_YT.png "YouTube thumbnail"