[![Build Status](https://dev.azure.com/cloud5mins/AzUnzipEverything/_apis/build/status/FBoucher.AzUnzipEverything?branchName=master)](https://dev.azure.com/cloud5mins/AzUnzipEverything/_build/latest?definitionId=23&branchName=master)

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



## Continuous Integration (CI)

As you can see by the status badge [![Build Status](https://dev.azure.com/cloud5mins/AzUnzipEverything/_apis/build/status/FBoucher.AzUnzipEverything?branchName=master)](https://dev.azure.com/cloud5mins/AzUnzipEverything/_build/latest?definitionId=23&branchName=master) at the top of the page this project is automatically build at every push. 

Have a look, the [Azure DevOps](https://dev.azure.com/cloud5mins/AzUnzipEverything/) project is **public**! 

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

### More! 

You can do so much more with the [Azure Function](https://docs.microsoft.com/en-us/azure/azure-functions/?WT.mc_id=cloud5mins-github-frbouche)! Don't hesitate to consult the [Microsoft documentation](https://docs.microsoft.com/en-us/azure/azure-functions/?WT.mc_id=cloud5mins-github-frbouche) to learn all the different scenarios, best practices, and code snippets.

## TODOs

A GitKraken [Glo board](https://app.gitkraken.com/glo/board/XRYx_9FgZwAVbri7) is also available.

- [ ] Add Support for .rar
- [X] Add ARM template
- [X] Add a Deploy to Azure button

## More details

I have a [blob post](https://www.frankysnotes.com/2019/02/how-to-unzip-automatically-your-files.html) about this Azure Function. 

I also have a video where I build and test the function.

[![Unzip Automatically Files with Azure Function v2
](https://img.youtube.com/vi/GRztpy337kU/0.jpg)](https://www.youtube.com/watch?v=GRztpy337kU)
  
https://youtu.be/GRztpy337kU

I also have an extended version where I introduce more the Visual Studio Extension to work with Azure Function. And explain more details about the Azure Function V2.

[![Deploy an Azure Function V2 (to unzip automatically your files) with Visual Studio Code
](https://img.youtube.com/vi/t9PvXWEzU-o/0.jpg)](https://www.youtube.com/watch?v=t9PvXWEzU-o)

https://youtu.be/t9PvXWEzU-o


[CreationForm]: /medias/CreationForm.png "Creation Form"
[resourceGroup]: /medias/resourceGroup.png "Select the ResourceGroup"
[uploadFile]: /medias/uploadFile.png "Upload Zip file"