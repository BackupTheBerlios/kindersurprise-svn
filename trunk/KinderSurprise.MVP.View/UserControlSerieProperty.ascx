<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlSerieProperty.ascx.cs" Inherits="KinderSurprise.MVP.View.UserControlSerieProperty" %>
<style type="text/css">
    .style1
    {
        width: 341px;
    }
</style>
<table>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:Label ID="LBL_ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            <asp:Literal ID="LI_Serie_Name" runat="server" Text="Name"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TB_Serie_Name" runat="server" Width="344px"></asp:TextBox>
            
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            <asp:Literal ID="LI_Serie_Description" runat="server" Text="Beschreibung"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TB_Serie_Description" runat="server" Width="344px"></asp:TextBox>
            
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            Publiziert 
            im Jahre</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TB_PubYear" runat="server" MaxLength="4"></asp:TextBox>
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            <asp:Literal ID="LI_Serie_Choose_Category" runat="server" Text="Category"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:DropDownList ID="DDL_Serie_Choose_Category" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:Button ID="BTN_NewFigur" runat="server" Text="Neue Figur" />
            <asp:Button ID="BTN_NewSerie" runat="server" Text="Neue Serie" />
            <br />
            <asp:Button ID="BTN_Save" runat="server" Text="Speichern" />
            <asp:Button ID="BTN_Cancel" runat="server" Text="Abbrechen" />
            <asp:Button ID="BTN_Delete" runat="server" Text="Löschen" />
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
</table>
