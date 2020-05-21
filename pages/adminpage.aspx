<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="onlineShop.pages.adminpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../fonts/ht.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <link href="../Css/StyleSheet3.css" rel="stylesheet" />
    <link href="../Css/StyleSheet4.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       


    <div class="container adminpage" id="showInfo" runat="server">
        <h2 style="font-size:50px; font-family: 'Pacifico', cursive;">Welcome</h2>
        <br />
        <div class="row ">
        <button class="btn btn-outline-dark col fonts " id="showCompData" runat="server" onserverclick="showCompData_ServerClick">Companies</button>
         <button class="btn btn-outline-success col fonts"id="showUserData" runat="server" onserverclick="showUserData_ServerClick">Users</button>
          <button class="btn btn-outline-danger col fonts " id="showProductData" runat="server" onserverclick="showProductData_ServerClick">Products</button>
    </div>
        <div class="bg-light " id="contain">

           

        </div>
    </div>
    </form>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>
</body>
</html>
