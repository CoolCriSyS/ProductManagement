<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<B2BProductCatalog.Models.CatalogBuilderModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Catalog Builder
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Catalog Builder</h1>
    
    <% if (Request.IsAuthenticated) { %>
        <p>Add new products to your catalog</p>
        
        <% using (Html.BeginForm()) { %>
            <%= Html.ValidationSummary(true, "Product was not submitted. Please correct the errors and try again.") %>
            
            <div>
                <!-- Not using this for now -->
                <fieldset style="display: none">
                    <legend>Product Information</legend>
                    
                    <div class="editor-label">
                        <%= Html.LabelFor(m => m.Name) %>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextBoxFor(m => m.Name, new { title="Enter product name" }) %>
                        <%= Html.ValidationMessageFor(m => m.Name) %>
                    </div>
                    
                    <div class="editor-label">
                        <%= Html.LabelFor(m => m.Description) %>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextAreaFor(m => m.Description, new { title="Enter a product description"}) %>
                        <%= Html.ValidationMessageFor(m => m.Description) %>
                    </div>
                    
                    <div class="editor-label">
                        <%= Html.LabelFor(m => m.Gender) %>
                    </div>
                    <div class="editor-field">
                        <%= Html.DropDownListFor(m => m.Gender, new SelectList(Model.Gender, "Value", "Text"), "Select a gender")%>
                    </div>
                    <br />
                    
                    <h2>Details</h2>
                    
                    <div id="upperLiningSection">
                        <%= Html.CheckBox("cbUpperLining") %>
                        <h3 class="inline">Upper/Lining</h3>
                        <ul id="upperList" style="display: none;">
                            <li>
                                <%= Html.CheckBox("cbUpperBullet") %> <label id="lblUpperBullet">Add bullet</label>
                                <%= Html.TextBoxFor(m => m.UpperLiningBullet, new { @class="description", hidden = true, title="Enter description" }) %>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <div id="midsoleOutsoleSection">
                        <%= Html.CheckBox("cbMidsoleOutsole") %>
                        <h3 class="inline">Midsole/Outsole</h3>
                        <ul id="midList" style="display: none;">
                            <li>
                                <%= Html.CheckBox("cbMidBullet") %> <label id="lblMidBullet">Add bullet</label>
                                <%= Html.TextBoxFor(m => m.MidsoleOutsoleBullet, new { @class = "description",  hidden = true, title = "Enter description" })%>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <p>
                        <input type="submit" value="Submit" />
                    </p>
                </fieldset>
                
                <fieldset>
                    <legend>Add products</legend>

                    <div class="editor-label">
                        <%= Html.LabelFor(m => m.StockNumbers) %>
                    </div>
                    <div class="editor-field">
                        <%= Html.TextAreaFor(m => m.StockNumbers, new { title="Enter a list of stock numbers"}) %>
                        <%= Html.ValidationMessageFor(m => m.StockNumbers) %>
                    </div>
                    <div>
                        <p style="color: #FF0000;"><%= ViewData["NotFound"] %></p>
                        <p style="color: #00FF00;"><%= ViewData["StylesAdded"]%></p>
                    </div>
                    <div>
                        <input type="submit" value="Submit" />
                    </div>
                
                </fieldset>

                <fieldset style="max-height: 800px;">
                    <legend>Current Catalog</legend>                    
                    <% if (Model.Products.Count > 0) { %>
                        <table style="overflow: scroll;">
                            <thead>
                                <tr>
                                    <th>Product Name</th>
                                    <th>Style Number</th>
                                    <th>Gender</th>
                                    <th>SAP Status</th>
                                    <th>Inventory</th>
                                    <th>Nav Cat 1</th>
                                    <th>Nav Cat 2</th>
                                    <th>Nav Cat 3</th>
                                    <th>Nav Cat 4</th>
                                    <th>Mkt Description</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var product in Model.Products) { %>
                                    <% foreach (var style in product.Styles) { %>
                                    <tr>
                                        <td><%= style.StyleInfos[0].Description %></td>
                                        <td><%= style.StyleNumber %></td>
                                        <td><%= style.StyleInfos[0].GenderDesc %></td>
                                        <td><%= style.StyleInfos[0].Status %></td>
                                        <td><%= style.StyleInfos[0].Inventory %></td>
                                        <td><%= product.Navigation.NavigationInfos[0].Category1 %></td>
                                        <td><%= product.Navigation.NavigationInfos[0].Category2 %></td>
                                        <td><%= product.Navigation.NavigationInfos[0].Category3 %></td>
                                        <td><%= product.Navigation.NavigationInfos[0].Category4 %></td>
                                        <td><%= product.PatternInfos[0].MarketingDescription %></td>
                                    </tr>
                                    <% } %>
                                <% } %>
                            </tbody>
                        </table>
                    <% } else { %>
                        <p>No data to display -- add products above</p>
                    <% } %>
                </fieldset>
            </div>
        <% } %>
        
    <% } else { %>
        <p>Please login to continue.</p>
    <% } %>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#cbUpperLining').click(function() {
                $('#upperList').toggle(this.checked);
            });

            $('#cbMidsoleOutsole').click(function() {
                $('#midList').toggle(this.checked);
            });

            $('#cbUpperBullet').click(function() {
                $('#upperLiningSection .watermark').toggle(this.checked);
                $('#lblUpperBullet').toggle(!this.checked);
                $('#UpperLiningBullet').toggle(this.checked);
            });

            $('#cbMidBullet').click(function() {
                $('#midsoleOutsoleSection .watermark').toggle(this.checked);
                $('#lblMidBullet').toggle(!this.checked);
                $('#MidsoleOutsoleBullet').toggle(this.checked);
            });

            $('#Name').watermark({ "fontSize": "1em", "top": "0", "className": "watermark" });
            $('.description').watermark({ "fontSize": "1em", "top": "-2px", "className": "watermark hide" });
        });
    </script>
</asp:Content>
