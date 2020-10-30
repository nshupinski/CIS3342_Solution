<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRestaurants.aspx.cs" Inherits="Restaurant_Review.MyRestaurants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Restaurants</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.1/css/bulma.min.css"/>
    <link rel="stylesheet" href="Style Sheets/MyRestaurants_Stylesheet.css" />

</head>
<body>
    <!--Navbar-->
    <nav class="navbar is-danger" role="navigation" aria-label="main navigation">
          <div class="navbar-menu">
              <div class="navbar-brand">
                <a class="navbar-item" href="Default.aspx">
                  <p style ="font-family:'Times New Roman', Times, serif; border-style: solid; padding: 5px;">Rusty Spork</p>
                </a>
                  <p id="username_display" runat="server"></p>
                  <a id="btnMyReviews" runat="server" href="MyReviews.aspx" style="visibility: hidden"> My Reviews</a>
                  <a id="btnMyRestaurants" runat="server" href="MyRestaurants.aspx" style="visibility: hidden"> My Restaurants</a>
            </div>
            <div class="navbar-end">
              <a class="navbar-item is-centered" onclick="logOut()" href="Login.aspx" runat="server">      
                  Log Out
              </a>
            </div>
          </div>
        </nav>

    <form id="form1" runat="server">
        <div class="gvBackground">
            <asp:GridView ID="gvMyRestaurants" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvMyRestaurants_RowCancelingEdit" OnRowEditing="gvMyRestaurants_RowEditing" OnRowUpdating="gvMyRestaurants_RowUpdating" OnRowDeleting="gvMyRestaurants_RowDeleting" OnSelectedIndexChanged="gvMyRestaurants_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Restaurant_Id" HeaderText="Restaurant ID" ReadOnly="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText="Description" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Category" HeaderText="Category" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Image" HeaderText="Image" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4em" />
                    </asp:BoundField>

                    <asp:CommandField ButtonType="Button" HeaderText="Edit Review" ShowEditButton="True" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" HeaderText="Delete Review" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                </Columns>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
