<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ProductCRUD.aspx.cs" Inherits="eBuyAntiquesStore2.admin.ProductCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
 
    <asp:GridView ID="GridView1" runat="server" EmptyDataText="Record is empty" AutoGenerateColumns="False" DataKeyNames="itemId" DataSourceID="SqlDataSource3" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="itemId" InsertVisible="False" SortExpression="itemId">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("itemId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("itemId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemName" SortExpression="itemName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("itemName") %>'></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvEditName" runat="server" 
                    ErrorMessage="Name is a required field"
                    ControlToValidate="TextBox1" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemDescription" SortExpression="itemDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("itemDescription") %>'></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvEditDesc" runat="server" 
                    ErrorMessage="Description is a required field"
                    ControlToValidate="TextBox2" Text="*" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("itemDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemWeight" SortExpression="itemWeight">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("itemWeight") %>'></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvEditWeight" runat="server" 
                    ErrorMessage="Weight is a required field"
                    ControlToValidate="TextBox3" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
                    
                
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("itemWeight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemAge" SortExpression="itemAge">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("itemAge") %>'></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvEditAge" runat="server" 
                    ErrorMessage="Age is a required field"
                    ControlToValidate="TextBox4" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
                
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("itemAge") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="addedDate" SortExpression="addedDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("addedDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("addedDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="categoryId" SortExpression="categoryId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("categoryId") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("categoryId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemImage" SortExpression="itemImage">
                <EditItemTemplate>
                     <asp:Image ID="img_user" runat="server" ImageUrl='<%# Bind("itemImage") %> ' Height="80px" Width="100px" />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                     </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("itemImage") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="quantity" SortExpression="quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("quantity") %>'></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvEditQuan" runat="server" 
                    ErrorMessage="quantity is a required field"
                    ControlToValidate="TextBox8" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="itemPrice" SortExpression="itemPrice">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("itemPrice") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEditPrice" runat="server" 
                    ErrorMessage="Price is a required field"
                    ControlToValidate="TextBox9" Text="*" ForeColor="Red">
                </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("itemPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ValidationGroup="Insert"  ID="ValidationSummary1" ForeColor="Red" runat="server" />
    
    <asp:ValidationSummary   ID="ValidationSummary2" ForeColor="Red" runat="server" />
    
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ebuyAntiquesStoreConnectionString %>" SelectCommand="SELECT * FROM [ItemMaster]" DeleteCommand="DELETE FROM [ItemMaster] WHERE [itemId] = @itemId" InsertCommand="INSERT INTO [ItemMaster] ([itemName], [itemDescription], [itemWeight], [itemAge], [addedDate], [categoryId], [itemImage], [quantity], [itemPrice]) VALUES (@itemName, @itemDescription, @itemWeight, @itemAge, @addedDate, @categoryId, @itemImage, @quantity, @itemPrice)" UpdateCommand="UPDATE [ItemMaster] SET [itemName] = @itemName, [itemDescription] = @itemDescription, [itemWeight] = @itemWeight, [itemAge] = @itemAge, [addedDate] = @addedDate, [categoryId] = @categoryId, [itemImage] = @itemImage, [quantity] = @quantity, [itemPrice] = @itemPrice WHERE [itemId] = @itemId">
        <DeleteParameters>
            <asp:Parameter Name="itemId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="itemName" Type="String" />
            <asp:Parameter Name="itemDescription" Type="String" />
            <asp:Parameter Name="itemWeight" Type="Single" />
            <asp:Parameter Name="itemAge" Type="Int32" />
            <asp:Parameter DbType="Date" Name="addedDate" />
            <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="itemImage" Type="String" />
            <asp:Parameter Name="quantity" Type="Int32" />
            <asp:Parameter Name="itemPrice" Type="Single" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="itemName" Type="String" />
            <asp:Parameter Name="itemDescription" Type="String" />
            <asp:Parameter Name="itemWeight" Type="Single" />
            <asp:Parameter Name="itemAge" DbType="Date" />
            <asp:Parameter DbType="Date" Name="addedDate" />
            <asp:Parameter Name="categoryId" Type="Int32" />
            <asp:Parameter Name="itemImage" Type="String" />
            <asp:Parameter Name="quantity" Type="Int32" />
            <asp:Parameter Name="itemPrice" Type="Single" />
            <asp:Parameter Name="itemId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
 
</asp:Content>
