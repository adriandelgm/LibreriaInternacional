<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LibreriaInternacional.View.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--------NAV-------->
        <div>
            <nav class="navbar navbar-expand-lg bg-light">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">
                        <img height="50px" width="200px" src="https://neurobrand.net/wp-content/uploads/2023/01/Libreria-INternacional-1-1024x252.png" alt="alt" />
                    </a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="LibreriaInternacional.aspx">Libros</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Cart.aspx">Cesta</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link disabled">Usuarios</a>
                            </li>
                        </ul>
                        <form class="d-flex" role="search">
                            <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                            <button class="btn btn-outline-success" type="submit">Search</button>
                        </form>
                    </div>
                </div>
            </nav>
        </div>
        <!--------NAV-------->
        <!--------BODY-------->
        <br />
        <!--------BODY-------->
        <!--------FOOTER-------->
        <footer class="text-center text-white" style="background-color: #f1f1f1;">
            <div class="container pt-4">
                <section class="mb-4">
                    <p class="text-center text-dark">
                        CORREO ELECTRÓNICO: servicioweb@libreriainternacional.com
TELÉFONO: 800-LIBRERÍA(542-73742)
                    </p>
                </section>
            </div>
            <div class="text-center text-dark p-3" style="background-color: rgba(0, 0, 0, 0.2);">
                © 2020 Copyright:
    <a class="text-dark" href="...">LibreriaInternacional</a>
            </div>
        </footer>
        <!--------FOOTER-------->
    </form>
</body>
</html>
