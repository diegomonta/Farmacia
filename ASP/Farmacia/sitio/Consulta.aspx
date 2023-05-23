<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Consulta" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recuperación de Contraseña</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            font-size: 24px;
            margin-bottom: 10px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"] {
            padding: 5px;
            width: 300px;
        }

        .btn {
            display: inline-block;
            padding: 8px 16px;
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }

        .btn:hover {
            background-color: #45a049;
        }

        .message {
            margin-top: 10px;
            font-size: 14px;
            font-weight: bold;
        }

        .error {
            color: #FF0000;
        }

        .success {
            color: #008000;
        }
    </style>
</head>
<body>
    <form id="formRecuperarContraseña" runat="server">
        <div class="container">
            <h2>Recuperar Contraseña</h2>
            <div id="pnlRecuperarContraseña" runat="server">
                <div class="form-group">
                    <label for="txtUsuario">Usuario:</label>
                    <asp:TextBox ID="txtUsuario" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnRecuperarContraseña" runat="server" Text="Recuperar Contraseña" OnClick="btnRecuperarContraseña_Click" />
                    <asp:Button ID="btnLogOut" runat="server" Text="LogOut"  CssClass="btn logout-btn" OnClick="btnLogOut_Click" />
                    <asp:Label ID="lblERROR" runat="server" CssClass="error" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>