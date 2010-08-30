<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="KinderSurprise.MVP.View.Default" %>
<%@ Register TagName="FigurProperty" Src="~/UserControlFigurProperty.ascx" TagPrefix="Tab" %>
<%@ Register TagName="SerieProperty" Src="~/UserControlSerieProperty.ascx" TagPrefix="Tab" %>
<%@ Register TagName="CategoryProperty" Src="~/UserControlCategoryProperty.ascx" TagPrefix="Tab" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    
    <h2>
        Übersicht</h2>
    <p>
        Bitte wählen Sie hier das gewünschte Objekt
    </p>
    <table>
        <tr>
            <td> 
                <asp:TreeView ID="TV_Overview" runat="server" ImageSet="Simple" 
                    ShowLines="True">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                        HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                        HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>    
            </td>
            <td>
            </td>
            <td>
               <asp:Menu ID="Menu_TabMenu" Width="168px" runat="server" Orientation="Horizontal" >
                    <Items>
                        <asp:MenuItem Text="Eigenschaften" Value="0"></asp:MenuItem>
                        <asp:MenuItem Text="Lager" Value="1"></asp:MenuItem>
                    </Items>
                </asp:Menu>

                <asp:MultiView ID="MV_Category" runat="server">
                    <asp:View ID="MV_Category_Properties" runat="server">
                        <Tab:CategoryProperty ID="UC_CategoryProperty" runat="server" />
                    </asp:View>
                </asp:MultiView>

                <asp:MultiView ID="MV_Serie" runat="server">
                    <asp:View ID="MV_Serie_Properties" runat="server">
                        <Tab:SerieProperty ID="UC_SerieProperty" runat="server" /> 
                    </asp:View>
                    <asp:View ID="MV_Serie_Store" runat="server">
                    </asp:View>
                </asp:MultiView>

                <asp:MultiView ID="MV_Figur" runat="server">
                    <asp:View ID="MV_Figur_Properties" runat="server">
                        <Tab:FigurProperty ID="UC_FigurProperty" runat="server" /> 
                    </asp:View>
                    <asp:View ID="MV_Figur_Store" runat="server">
                   </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td> 
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
