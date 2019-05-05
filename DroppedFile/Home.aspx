<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="theme.css" type="text/css">
    <link rel="shortcut icon" type="image/png" href="/Images/Simple_Comic_zip.png" />
    <script src="jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="code.js"></script>
    <title>DroppedFile.com</title>
</head>



<body class="">



    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-md bg-dark navbar-dark">
            <div class="container">
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbar3SupportedContent">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-center justify-content-center" id="navbar3SupportedContent">
                    <img class="img-fluid d-block" src="Images/logo.png">
                </div>
            </div>
            <div class="container"></div>
            <span class="navbar-text">DroppedFile.com</span>
        </nav>
        <div class="pt-5 text-white bg-secondary">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 text-md-left text-center align-self-center my-5">
                        <h1 class="display-1">Upload Files</h1>
                        <p class="lead text-center">
                            By using DroppedFIle.com you agree to our <a href="/?tos=t">Terms and Conditions</a>.
            <br>
                            File size is restricted to a maximum of 30MB.
                        </p>

                        <div class="row mt-5">
                            <div class="col-md-5 col-6">
                                <%--FILEUPLOAD DIAG HERE--%>
                                <asp:CustomValidator ID="customValidatorUpload" runat="server" ErrorMessage="" ControlToValidate="FileUpload1" ClientValidationFunction="setUploadButtonState();" />
                                <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="True" Font-Size="X-Large" />
                                <br />
                                <br />
                           <asp:Button ID="uploadButton" runat="server" OnClick="uploadButton_Click" Text="Upload" Enabled="false" Font-Bold="True" Font-Size="X-Large" Width="100%" />
                                <br />

                                <%--<a href="#"></a>--%>
                            </div>
                            <div class="col-md-5 col-6">
                                <%--Upload Button HERE--%>

                                <%--<a href="#"></a>--%>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-6">
                        <img class="img-fluid d-block mx-auto" src="Images/Simple_Comic_zip.png">
                    </div>
                </div>
            </div>
            <div class="container bg-dark text-center">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" Font-Size="XX-Large"></asp:LinkButton>
                <asp:Label ID="Label10" runat="server" Font-Size="XX-Large"></asp:Label>
                
                <br />
            </div>
            <div class="container text-center bg-secondary">.</div>
        </div>
        <div class="bg-dark text-white">
            <div class="container">
                <div class="row">
                    <div class="p-4 col-md-3">
                        <h2 class="mb-4 text-secondary">DroppedFile</h2>
                        <p class="text-white">
                            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <div class="p-4 col-md-3">
                        <h2 class="mb-4 text-secondary">Index
            <br>
                        </h2>
                        <ul class="list-unstyled">
                            <a href="/" class="text-white">Home</a>
                            <br>
                            <a href="/?r=t" class="text-white">Report File</a>
                            <br>
                            <a href="/?tos=t" class="text-white">Terms and Conditions</a>
                            <br>
                            <a href="#" class="text-white"></a>
                        </ul>
                    </div>
                    <div class="p-4 col-md-3">
                        <h2 class="mb-4 text-secondary"></h2>
                        <p></p>
                    </div>
                    <div class="p-4 col-md-3">
                        <h2 class="mb-4 text-secondary">Give Us A Tip</h2>
                        <form>
                            <fieldset class="form-group text-white"></fieldset>
                        </form>
                        <div class="row">
                            <div class="col-md-12">
                                <p class="">
                                    <a href="http://bitcoin.org">Bitcoin</a>:&nbsp;3KwkiTj1QhmmUgHkwfWscTHUDbNd9e4QQH 
                <br>
                                    <a href="http://litecoin.com">Litecoin</a>:&nbsp;MDRL7QDPCH6MBMrgbJDL4Ecr3RWUdmtTae
                  <br>
                                    <a href="http://bitcoincash.org">BCH</a>:&nbsp;1Kr2X2tTrRcoUsG7P4YRiLuhGgwPCUA9jj
                  <br>
                                    <a href="http://ethereum.org">Ethereum</a>:&nbsp;0x7f98B6E7e818B54DCC19D5fb02870712BF6BAe7B
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 mt-3">
                        <p class="text-center text-white">© Copyright 2018 Aaron & DroppedFile.com</p>
                    </div>
                </div>
            </div>
        </div>

        <script src="/site_scripts/jquery-3.2.1.slim.min.js"></script>
        <script src="/site_scripts/popper.min.js"></script>
        <script src="/site_scripts/bootstrap.min.js"></script>


    </form>
</body>

</html>
