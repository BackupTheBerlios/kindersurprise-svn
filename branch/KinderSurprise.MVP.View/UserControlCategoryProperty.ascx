<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCategoryProperty.ascx.cs" Inherits="KinderSurprise.MVP.View.UserControlCategoryProperty" %>
<style type="text/css">
    .style1
    {
        width: 470px;
    }
</style>
<table>
    <tr>
        <td>
            
            &nbsp;</td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:Label ID="LblErrorLabel" runat="server" ForeColor="Red"></asp:Label>
            
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
            
            <asp:Literal ID="LI_Category_Name" runat="server" Text="Name"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TbNameTextBox" runat="server" Width="337px"></asp:TextBox>
            
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
            
            <asp:Literal ID="LI_Category_Description" runat="server" Text="Beschreibung"></asp:Literal>
        </td>
        <td>
            
            &nbsp;</td>
        <td class="style1">
            
            <asp:TextBox ID="TbDescriptionTextBox" runat="server" Width="344px"></asp:TextBox>
            
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
            <asp:Button ID="BTN_NewSerie" runat="server" Text="Neue Serie" />
            <asp:Button ID="BTN_NewCategory" runat="server" Text="neue Kategorie" />
            <br />
            <asp:Button ID="BTN_CategoryDelete" runat="server" Text="Kategorie Löschen" />
            <asp:Button ID="BTN_CategoryUpdate" runat="server" Text="Kategorie Bestätigen" />
            <asp:Button ID="BTN_CategoryCancel" runat="server" Text="Abbrechen" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
