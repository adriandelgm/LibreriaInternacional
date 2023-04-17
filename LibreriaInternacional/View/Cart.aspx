<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LibreriaInternacional.View.Cart" %>

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
        <!--------REP-------->
        <div class="row no-gutters">
            <asp:Repeater ID="repCart" runat="server">
                <ItemTemplate>
                    <!-- Product Area -->
                    <div class="col-12 col-sm-6">
                        <div class="single-product-wrapper">
                            <!-- Product Image -->
                            <div>
                                <a href="InfoBook.aspx?Id=<%# Eval("idBook")%>">
                                    <img src="<%#Eval ("Image")%>" style="width: 300px; height: 400px;" />
                            </div>

                            <!-- Product Description -->
                            <div class="product-description d-flex align-items-center">
                                <!-- Product Meta Data -->
                                <div class="product-meta-data">
                                    <div class="line"></div>
                                    <p class="product-price">₡ <%#Eval ("Price")%></p>
                                    <a href="InfoBook.aspx?Id=<%# Eval("idBook")%>">
                                        <h4><%#Eval ("Title")%> </h4>
                                    </a>
                                </div>
                                <!-- Ratings & Cart -->
                                <div class="ratings-cart text-right">
                                    <div class="ratings">
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                        <i class="fa fa-star" aria-hidden="true"></i>
                                    </div>
                                    <div class="cart">
                                        <button dataid='<%# Eval("idBook")%>' runat="server" onserverclick="btnDelete_ServerClick" data-toggle="tooltip" data-placement="left" title="Eliminar libro de favoritos">
                                            <img src="../css/PageStyle/img/core-img/trash-2.jpg" /></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--------REP-------->
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
