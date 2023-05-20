<%@ page language="C#" autoeventwireup="true" inherits="LogIn, App_Web_nzht2k3i" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ESCUELA DE SEGURIDA INFORMATICA </title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-image: url('imagen/craiyon_103333_un_logo_de_un_colegio_de_sistema_de_seguridad_de_la_informacion.png');
            background-repeat: no-repeat;
            background-size: cover;
            font-family: Arial, sans-serif;
        }
        
        .container {
            text-align: center;
            background-color: rgba(255, 255, 255, 0.8);
            padding: 20px;
            border-radius: 10px;
            max-width: 400px;
        }
        
        h1 {
            color: #333;
        }
        
        p {
            color: #666;
        }
        
        /* Agrega más estilos según tus necesidades */
    </style>
</head>
<body>
   <div class="container">
       <h1>INGRESO</h1>
       <p>
    <form id="form1" runat="server">
    <table>
        <strong>LOG IN</strong>
        <tr>
            <td>
                <asp:Label ID="lblUsuario" Text="Usuario:" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPass" Text="Password:" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" type="password" pattern="(?=.*\d)(?=.*[a-zA-Z]).{8,}"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogIn" runat="server" Text="LogIn" OnClick="btnLogIn_Click" />
            </td>
            <td>
                <asp:Label ID="lblERROR" runat="server"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="btnRegistrarCliente" runat="server" Text="Registro Estudiante" OnClick="btnRegistrarCliente_Click" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnConsulta" runat="server" Text="Consulta pedido" 
        onclick="btnConsulta_Click" />
    </form>
    </p>
   </div>
</body>
</html>
