<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookInfo.aspx.cs" Inherits="LibreriaInternacional.View.BookInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous" />
    <title>Librería Internacional</title>
    <link rel="icon" type="image/x-icon" href="https://cmplima.org.pe/wp-content/uploads/2022/09/Libro-de-reclamaciones-Azul-300x300-1.png" />
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
                                <a class="nav-link" href="Favorites.aspx">Favoritos</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#offcanvasExample" data-bs-toggle="offcanvas" aria-controls="offcanvasExample">Cuenta</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>
        <!--------NAV-------->
        <!--------BODY-------->
        <br />
        <asp:Repeater ID="repInfo" runat="server">
            <ItemTemplate>
                <div class="container">
                    <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="LibreriaInternacional.aspx">Inicio</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Libros</li>
                            <li class="breadcrumb-item active" aria-current="page"><%#Eval ("Title")%></li>
                        </ol>
                    </nav>
                </div>
                <!--------LAYOUT-------->
                <div class="container">
                    <div class="row">
                        <div class="col align-self-start">
                            <img src="<%#Eval ("Image")%>" class="rounded d-block" height="550px" alt="...">
                        </div>
                        <div class="col-8">
                            <h5><%#Eval ("Title")%></h5>
                            <br />
                            <h6>Autor:</h6>
                            <p><%#Eval ("Author")%></p>
                            <h6>ISBN:</h6>
                            <p><%#Eval ("ISBN")%></p>
                            <h6>Fecha de publicación:</h6>
                            <p><%#Eval ("PublishingDate")%></p>
                            <h6>Estado:</h6>
                            <p><%#Eval ("status")%></p>
                            <br />
                            <hr />
                            <div class="container-fluid">
                                <div class="row">
                                    <div class="col">
                                        <h6>Precio: ₡<%#Eval ("Price")%></h6>
                                    </div>
                                    <div class="col">
                                        <button href="#?Id=<%# Eval("idBook")%>" id="btnCart" type="submit" class="btn btn-danger">Añadir a cesta</button>
                                        <button id="btnFav" runat="server" onserverclick="btnFav_ServerClick" type="submit" class="btn btn-danger">Añadir a Favoritos</button>
                                    </div>
                                </div>
                            </div>
                            <hr />
                        </div>
                    </div>
                    <hr />
                    <h6>Descripción</h6>
                    <p><%#Eval ("Description")%></p>
            </ItemTemplate>
        </asp:Repeater>
        <!--------LAYOUT-------->
        <!--------BODY-------->
        <!--------FOOTER-------->
        <footer class="text-center text-white" style="background-color: #f1f1f1;">
            <div class="container pt-4">
                <section class="mb-4">
                    <div class="col align-self-start">
                    </div>
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
