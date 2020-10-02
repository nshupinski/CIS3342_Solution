<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Bookstore._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.0/css/bulma.min.css"/>
    <link rel="stylesheet" href="css/bookstore_stylesheet.css"/>

    <title>Bookstore</title>

</head>
<body>

    <!--Hero-->
    <section class="hero is-primary">
        <div class="hero-body">
        <div class="container">
            <h1 class="title">
            Welcome To Dr. Jenkin's Backyard Bookstore Vista 
            </h1>
            <h2 class="subtitle">
            ...Where Books Are!
            </h2>
        </div>
        </div>
    </section>

    <!--Navbar-->
    <nav class="navbar" role="navigation" aria-label="main navigation">
          <div id="navbarBasicExample" class="navbar-menu">
            <div class="navbar-start">
              <a class="navbar-item is-centered">
                Book Search
              </a>

              <a class="navbar-item is-centered">
                Management Report
              </a>
            </div>
          </div>
        </nav>


    <form id="bookForm" runat="server">
        <div class="infoSection">
            <div class="columns">
                <div class="column">
                    <!--Student ID-->
                    <asp:Label ID="lblID" runat="server" Text="Student ID"></asp:Label>
                    <asp:TextBox id="txtID" runat="server" class="input is-rounded" type="text" Placeholder="Student ID"></asp:TextBox>
            
                    <!--Name-->
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox id="txtName" runat="server" class="input is-rounded" type="text" Placeholder="Name"></asp:TextBox>
                </div>
                <div class="column">
                    <!--Address-->
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox id="txtAddress" runat="server" class="input is-rounded" type="text" Placeholder="Address"></asp:TextBox>

                    <!--Phone Number-->
                    <asp:Label ID="lblPhone" runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox id="txtPhone" runat="server" class="input is-rounded" type="text" Placeholder="Phone number"></asp:TextBox>
                </div>
            </div>

            <!--Campus-->
            <asp:Label class="campusList" runat="server" Text="Campus"></asp:Label><br />
            <asp:DropDownList ID="campusList" class="campusList" name="campusList" runat="server">
                <asp:ListItem  value="main">Main </asp:ListItem>
                <asp:ListItem  value="TUCC">TUCC </asp:ListItem>
                <asp:ListItem  value="ambler">Ambler </asp:ListItem>
                <asp:ListItem  value="tokyo">Tokyo </asp:ListItem>
                <asp:ListItem  value="rome">Rome </asp:ListItem>
            </asp:DropDownList>

        </div>

        <div class="formDiv">
            <asp:GridView ID="gvOrderBooks" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chBoxOrder" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Authors" HeaderText="Authors" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:TemplateField AccessibleHeaderText="Book Type" HeaderText="Book Type">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddbType" runat="server">
                                <asp:ListItem>Hard Cover</asp:ListItem>
                                <asp:ListItem>Paper-Back</asp:ListItem>
                                <asp:ListItem>e-Book</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rent or Buy">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddbRentBuy" runat="server">
                                <asp:ListItem>Rent</asp:ListItem>
                                <asp:ListItem>Buy</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ControlStyle Width="60%" />
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="80%" />
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnOrder" CssClass="orderBtn is-centered" runat="server" Text="Place Order" OnClick="btnOrder_Clicked" padding="15" />

        </div>
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="Title" />
                <asp:BoundField DataField="isbn" HeaderText="ISBN" />
                <asp:BoundField DataField="bookType" HeaderText="Book Type" />
                <asp:BoundField DataField="rentOrBuy" HeaderText="Rent/Buy" />
                <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Base Price" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="totalCost" DataFormatString="{0:c}" HeaderText="Total Cost" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
