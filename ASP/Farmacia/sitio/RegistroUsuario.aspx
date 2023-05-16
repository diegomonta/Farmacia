<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroUsuario.aspx.cs"
    Inherits="RegistroUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro Cliente</title>
    <style>
        body {
            background-color: #f2f2f2;
            font-family: Arial, sans-serif;
        }
        
        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
        
        .title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }
        
        .form-group {
            margin-bottom: 15px;
        }
        
        .form-group label {
            display: inline-block;
            width: 100px;
            font-weight: bold;
        }
        
        .form-group input[type="text"],
        .form-group input[type="password"] {
            width: 200px;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 3px;
            font-size: 14px;
        }
        
        .btn {
            display: inline-block;
            padding: 8px 12px;
            background-color: #337ab7;
            color: #fff;
            font-size: 14px;
            text-decoration: none;
            border-radius: 3px;
            transition: background-color 0.3s ease;
        }
        
        .btn:hover {
            background-color: #23527c;
        }
        
        .error {
            color: #d9534f;
            margin-top: 10px;
        }
    </style>
</head>
<body>
   <div class="container">
        <div class="title">REGISTRO ESTUDIANTE</div>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="txtUsuario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtPass">Password:</label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtDireccionFacturacion">Curso que cursa:</label>
                <asp:TextBox ID="txtDireccionFacturacion" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtTelefono">Telefono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn" />
            </div>
                <td>
                    <asp:Label ID="lblERROR" runat="server" />
                </td>
        </form>
    </div>
</body>
</html>
