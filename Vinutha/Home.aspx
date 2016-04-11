<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
        <td rowspan="5" valign="top">
            <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
        </td>
    </tr>
   
    <tr>
        <td>Welcome <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            
        </td>
    </tr>
 <tr>
     <td>
         <asp:FileUpload ID="FileUpload1" runat="server" />
     </td>
     <td>
          <asp:Button id="UploadButton" 
            Text="Upload file"
            OnClick="UploadButton_Click"
            runat="server" CssClass="btn">
        </asp:Button>
     </td>
 </tr>
        <tr>
            <td>
                 <asp:Label id="UploadStatusLabel"
           runat="server">
        </asp:Label>  
                <br />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View all uploaded files</asp:LinkButton>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Click on the files to get the main contents" ForeColor="Blue"></asp:Label>
        <hr />
                <asp:TreeView ID="TreeView1" runat="server" NodeIndent="15">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>
        <asp:Label id="LengthLabel"
           runat="server">
        </asp:Label>  

        <br /><br />

        <asp:Label id="ContentsLabel"
           runat="server">
        </asp:Label>  
                <br /><br />
                 <asp:PlaceHolder id="PlaceHolder1"
            runat="server">
        </asp:PlaceHolder>        
            </td>
        </tr>
</table>
    </div>
    </form>
</body>
</html>
