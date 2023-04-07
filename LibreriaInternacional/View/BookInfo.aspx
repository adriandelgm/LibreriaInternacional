<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookInfo.aspx.cs" Inherits="LibreriaInternacional.View.BookInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" integrity="sha384-qKXV1j0HvMUeCBQ+QVp7JcfGl760yU08IQ+GpUo5hlbpg51QRiuqHAJz8+BrxE/N" crossorigin="anonymous"></script>
    <link rel="stylesheet" id="theme_link" href="https://cdnjs.cloudflare.com/ajax/libs/bootswatch/5.1.2/lux/bootstrap.min.css"/>
    <link href="../css/Books.css" rel="stylesheet" />
    <title>Librería Internacional</title>
    <link rel="icon" type="image/x-icon" href="https://cmplima.org.pe/wp-content/uploads/2022/09/Libro-de-reclamaciones-Azul-300x300-1.png"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="repBook" runat="server">
                <HeaderTemplate>
                    <div class="container">
                        <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="card" style="width: 18rem; margin-left: 1px">
                        <img src="<%# Eval("Image")%>" class="card-img-top" alt="..."/>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Title")%></h5>
                            <p class="card-text"><%# Eval("Description")%></p>
                            <a href="BookInfo.aspx?id=<%# Eval("ISBN")%>" class="btn btn-primary">Buy by $<%# Eval("Price")%></a>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                        </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
