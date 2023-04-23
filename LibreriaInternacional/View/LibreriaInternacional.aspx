<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibreriaInternacional.aspx.cs" Inherits="LibreriaInternacional.LibreriaInternacional" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.min.js" integrity="sha384-7VPbUDkoPSGFnVtYi0QogXtr74QeVeeIs99Qfg5YCF+TidwNdjvaKZX19NZ/e6oz" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous"/>
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
                        <form class="d-flex" role="search">
                            <input class="form-control me-2" type="search" runat="server" id="txtSearchedBook" placeholder="Search" aria-label="Buscar"/>
                            <button class="btn btn-outline-success" id="btnSearch" runat="server" onserverclick="btnSearch_ServerClick">Search</button>
                        </form>
                    </div>
                </div>
            </nav>
        </div>
        <!--------NAV-------->
        <!--------BODY-------->
        <br />
        <!--------AD-------->
        <div>
            <div class="container text-center">
                <div class="row">
                    <div class="col">
                    </div>
                    <div class="col-8">
                        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <img src="../Images/p1.png" class="d-block w-100" alt="..."/>
                                </div>
                                <div class="carousel-item">
                                    <img src="../Images/p2.png" class="d-block w-100" alt="..."/>
                                </div>
                                <div class="carousel-item">
                                    <img src="../Images/p3.png" class="d-block w-100" alt="..."/>
                                </div>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <img src="https://img.freepik.com/vector-gratis/concepto-dia-mundial-libro-dibujado-mano_23-2148481517.jpg" class="card-img-top" alt="..."/>
                            <div class="card-body">
                                <p class="card-text">¡Celebrá el día del libro con nosotros!</p>
                                <hr />
                                <p class="card-text">Eventos especiales para niños en nuestros centros de venta el día 23 de Abril</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--------AD-------->
        <br />
        <hr />
        <p class="text-center" style="font-size: 25px;">Explora nuestro catálogo de libros</p>
        <hr />
        <!--------REP-------->
        <div class="text-center">
            <div class="row container-fluid">
                <asp:Repeater ID="repBooks" runat="server">
                    <HeaderTemplate>
                        <div class="container-fluid">
                            <div class="row">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="card text-center" style="width: 18rem; height: 35rem; margin-left: 5px; margin-right: 5px; border: none">
                            <img src="<%# Eval("Image")%>" class="card-img" style="height: 400px; width: 270px;" alt="..." />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Title")%></h5>
                                <hr />
                                <a href="BookInfo.aspx?id=<%# Eval("idBook")%>" class="btn btn-outline-warning">Ver más ₡<%# Eval("Price")%></a>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
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
        <!--------OFFCANVA-------->
        <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
            <div id="offCanvaHeader" class="offcanvas-header">
                <h5 class="offcanvas-title" id="offcanvasExampleLabel">Login</h5>
                <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
            </div>
            <div class="offcanvas-body">
                <div class="card" id="cardLogin" runat="server">
                    <div class="card-body">
                        <div class="form-group">
                            <label class="form-label mt-4">Login form</label>
                            <div class="form-floating mb-3">
                                <input type="email" runat="server" class="form-control" id="txtEmail" value="jesusadri.delgado@gmail.com" placeholder="name@example.com" />
                                <label for="floatingInput">Email address</label>
                            </div>
                            <div class="form-floating">
                                <input type="text" runat="server" class="form-control" value="Admin$1234" id="txtPassword" placeholder="Password" />
                                <label for="floatingPassword">Password</label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <button id="btnLogin" class="btn btn-primary" runat="server" onserverclick="btnLogin_ServerClick">Login</button>
                    </div>
                </div>
                <div hidden="hidden" id="cardUser" runat="server">
                    <div class="form-group">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-4">
                                <div class="row">
                                    <div class="row">
                                        <h5 id="lblName" runat="server" class="mb-1"></h5>
                                        <div class="d-flex pt-1">
                                            <button type="button" class="btn btn-outline-primary me-1 flex-grow-1">View profile</button>
                                            <button id="btnLogout" runat="server" type="button" class="btn btn-primary flex-grow-1" onserverclick="btnLogout_ServerClick">Logout</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--------OFFCANVA-------->
    </form>
</body>
</html>
