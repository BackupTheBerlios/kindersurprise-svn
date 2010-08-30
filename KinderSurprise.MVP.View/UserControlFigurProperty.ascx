<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlFigurProperty.ascx.cs" Inherits="KinderSurprise.MVP.View.UserControlFigurProperty" %>
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
            
            <asp:TextBox ID="TB_Figur_Name" runat="server" Width="343px"></asp:TextBox>
            
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
            
            <asp:TextBox ID="TB_Figur_Description" runat="server" Width="344px"></asp:TextBox>
            
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
            
            <asp:Literal ID="LI_Serie_Price" runat="server" Text="Preis:"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TB_Figur_Price" runat="server" Width="143px"></asp:TextBox>
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
            
            <asp:Literal ID="LI_Figur_Choose_Serie" runat="server" Text="Serie"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:DropDownList ID="DDL_Figur_Choose_Serie" runat="server">
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
            <br />
            <asp:Button ID="BTN_Cancel" runat="server" Text="Abbrechen" />
            <asp:Button ID="BTN_Save" runat="server" Text="Speichern" />
            <asp:Button ID="BTN_Delete" runat="server" Text="Löschen" />
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
</table>
