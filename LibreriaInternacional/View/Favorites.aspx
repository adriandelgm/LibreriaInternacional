<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="LibreriaInternacional.View.Favorites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
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
        <div class="container">
            <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="LibreriaInternacional.aspx">Inicio</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Favoritos</li>
                </ol>
            </nav>
        </div>
        <!--------REP-------->
        <div class="container">
            <asp:Repeater ID="repFavorites" runat="server">
                <ItemTemplate>
                    <div class="card" style="border: none">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">

                                <div class="card">
                                    <div class="row g-0">
                                        <div class="col-md-4">
                                            <img src="<%#Eval ("Image")%>" class="rounded d-block" height="90px" alt="...">
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <h6 class="card-title"><%# Eval("Title")%>
                                                    <button dataid='<%# Eval("Id")%>' runat="server" onserverclick="btnDeleteFav_ServerClick" data-toggle="tooltip" data-placement="left" title="Eliminar libro de favoritos">
                                                        <img height="15px" width="15px" src="https://cdn4.iconfinder.com/data/icons/linecon/512/delete-512.png" alt="alt" /></button></h6>
                                                <p class="card-text"><small class="text-muted"><%#Eval ("Author")%> <%#Eval ("ISBN")%> ₡<%#Eval ("Price")%></small></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </li>
                        </ul>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <!--------REP-------->
        </div>
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
