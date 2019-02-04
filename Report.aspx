<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="theme.css" type="text/css">
    <link rel="shortcut icon" type="image/png" href="/Images/Simple_Comic_zip.png" />
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
                        <h1 class="display-1 text-center" contenteditable="false">Report File
            <br>
                        </h1>
                        <center>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="DroppedFile.com" Width="35%"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Report Link" OnClick="Button1_Click" />
                <br />
                <asp:Label ID="Label1" runat="server" Visible="true" Font-Size="X-Large"></asp:Label>
                </center>
                    </div>
                    <div class="col-md-6">
                        <img class="img-fluid d-block mx-auto" src="Images/Simple_Comic_zip.png">
                    </div>
                </div>
            </div>
            <div class="container"></div>
        </div>
        <div class="bg-dark text-white">
            <div class="container">
                <div class="row">
                    <div class="p-4 col-md-3">
                        <h2 class="mb-4 text-secondary">DroppedFile</h2>
                        <p class="text-white"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></p>
                        
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
                        <p class="text-center text-white">© Copyright 2018 DroppedFile.com</p>
                    </div>
                </div>
            </div>
        </div>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    </form>
</body>

</html>
