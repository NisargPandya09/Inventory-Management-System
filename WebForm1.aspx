
<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">         <!--A form to insert product to make entry when a new product arrives --> 
    <form class="form-horizontal" id="insform" runat="server">
<div class="modal fade"  id="ins" role="dialog" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                <h4>Insert Form<button type="button" class="close" data-dismiss="modal" onclick="insert_ResetClick"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label for="pname1" class="col-lg-5 control-label">Product Name</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="pname1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="pname1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="part1" class="col-lg-5 control-label">PART</label>
                    <div class="col-lg-7">
                        <!--select class="form-control" id="part1">-->
                            <asp:DropDownList ID="part1" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">PART:1</asp:ListItem>
                                <asp:ListItem>PART:2</asp:ListItem>
                                <asp:ListItem>PART:3</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="isdin1" class="col-lg-5 control-label">IS/DIN</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="isdin1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="isdin1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="dia1" class="col-lg-5 control-label">Diameter</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="dia1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="dia1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="len1" class="col-lg-5 control-label">Length</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="len1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="len1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="grade1" class="col-lg-5 control-label">Grade</label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="grade1" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">8.8</asp:ListItem>
                                <asp:ListItem>10.9</asp:ListItem>
                                <asp:ListItem>12.9</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="plating1" class="col-lg-5 control-label">Plating</label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="plating1" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">BLACK</asp:ListItem>
                                <asp:ListItem>WHITE</asp:ListItem>
                                <asp:ListItem>YELLOW</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="rackpos1" class="col-lg-5 control-label">Rack Position</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="rackpos1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="rackpos1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="price1" class="col-lg-5 control-label">Price</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="price1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="price1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="qty1" class="col-lg-5 control-label">Quantity</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="qty1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="qty1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="suplier1" class="col-lg-5 control-label">Product Supplier</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="suplier1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="suplier1" />-->
                    </div>
                </div>
                <div class="form-group">
                    <label for="minavl1" class="col-lg-5 control-label">Minimum Quantity Required</label>
                    <div class="col-lg-7">
                        <asp:TextBox ID="minavl1" CssClass="form-control" runat="server"></asp:TextBox>
                        <!--<input type="text" class="form-control" id="minavl1" />-->
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:button ID="ins_submit" CssClass="btn btn-primary" runat="server" onclick="insertSubmit_Click" Text="SUBMIT"/>
                <asp:button ID="ins_reset" runat="server" CssClass="btn btn-default" Text="RESET" OnClick="insertReset_Click" />
            </div>
            </div>
        </div>
    </div>

        <div class="modal fade" id="bcd" role="dialog" data-backdrop="static">                <!--A form for Barcode generation of new product-->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>BARCODE READER<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="pname5" class="col-lg-5 control-label">Product Code</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="pcode5" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="pcode5_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="bcd_submit" CssClass="btn btn-primary" runat="server" OnClick="bcd_submit_Click" Text="SUBMIT" />
                    </div>
                </div>
            </div>
        </div>
        
    <div class="modal fade" id="upd" role="dialog" data-backdrop="static" aria-hidden="true"> <!--A form to update information of any product of inventory-->
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>Update product information<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="pname2" class="col-lg-5 control-label">Product Name</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="pname2" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="part2" class="col-lg-5 control-label">PART</label>
                        <div class="col-lg-7">
                            <!--select class="form-control" id="part1">-->
                            <asp:DropDownList ID="part2" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">PART:1</asp:ListItem>
                                <asp:ListItem>PART:2</asp:ListItem>
                                <asp:ListItem>PART:3</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="isdin2" class="col-lg-5 control-label">IS/DIN</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="isdin2" CssClass="form-control" runat="server"></asp:TextBox>
                            <!--<input type="text" class="form-control" id="isdin1" />-->
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="dia2" class="col-lg-5 control-label">Diameter</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="dia2" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="len2" class="col-lg-5 control-label">Length</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="len2" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group">
                        <label for="grade2" class="col-lg-5 control-label">Grade</label>
                        <div class="col-lg-7">
                            <asp:DropDownList ID="grade2" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">8.8</asp:ListItem>
                                <asp:ListItem>10.9</asp:ListItem>
                                <asp:ListItem>12.9</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="plating" class="col-lg-5 control-label">Plating</label>
                        <div class="col-lg-7">
                            <asp:DropDownList ID="plating2" CssClass="form-control" runat="server">
                                <asp:ListItem Selected="True">BLACK</asp:ListItem>
                                <asp:ListItem>WHITE</asp:ListItem>
                                <asp:ListItem>YELLOW</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="rackpos2" class="col-lg-5 control-label">Rack Position</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="rackpos2" CssClass="form-control" runat="server"></asp:TextBox>
                            <!--<input type="text" class="form-control" id="rackpos1" />-->
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="price2" class="col-lg-5 control-label">Price</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="price2" CssClass="form-control" runat="server"></asp:TextBox>
                            <!--<input type="text" class="form-control" id="price1" />-->
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="qty2" class="col-lg-5 control-label">Quantity</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="qty2" CssClass="form-control" runat="server"></asp:TextBox>
                            <!--<input type="text" class="form-control" id="qty1" />-->
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="suplier2" class="col-lg-5 control-label">Product Supplier</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="suplier2" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="minavl2" class="col-lg-5 control-label">Minimum Quantity Required</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="minavl2" CssClass="form-control" runat="server"></asp:TextBox>
                            <!--<input type="text" class="form-control" id="minavl1" />-->
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <!--<asp:button ID="upd_submit" CssClass="btn btn-primary" Text="GET PRODUCT INFO" OnClick="upd_submit_Click" runat="server" />-->
                    <asp:button ID="upd_update" CssClass="btn btn-primary" Text="UPDATE" OnClick="upd_update_Click" runat="server" />
                    <asp:button ID="upd_reset" CssClass="btn btn-default" Text="RESET" OnClick="upd_reset_Click" runat="server" />
                </div>
             </div>
        </div>
    </div>

    <div class="modal fade" id="del" role="dialog" data-backdrop="static">                    <!--A form that takes product name, diameter and length to delete any item from record-->
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4>UPDATE Product<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="pname3" class="col-lg-5 control-label">Product Name</label>
                        <div class="col-lg-7">
                            <asp:DropDownList ID="pname3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pname" DataValueField="Pname" AutoPostBack="true" OnSelectedIndexChanged="pname3_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Pname] FROM [Pcode]">
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                    <label for="dia3" class="col-lg-5 control-label">Diameter</label>
                    <div class="col-lg-7">
                        <asp:DropDownList ID="dia3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource5" DataTextField="Diameter" DataValueField="Diameter" AutoPostBack="true" OnSelectedIndexChanged="pname3_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Diameter] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Pname]=@pname">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="pname3" Name="pname" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="len3" class="col-lg-5 control-label">Length</label>
                        <div class="col-lg-7">
                            <asp:DropDownList ID="len3" CssClass="form-control" runat="server" DataSourceID="SqlDataSource6" DataTextField="Length" DataValueField="Length" AutoPostBack="true" OnSelectedIndexChanged="pname3_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Length] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Diameter]=@dia">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="dia3" Name="dia" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="pname3" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="del_submit" CssClass="btn btn-primary" runat="server" OnClick="del_submit_Click" Text="SUBMIT" />
                        <asp:button ID="del_reset" CssClass="btn btn-default" runat="server" OnClick="del_reset_Click" Text="RESET" />
                    </div>
                </div>
         </div>
    </div>

    <div class="modal fade" id="upd2" role="dialog" data-backdrop="static">                   <!--A form to add or dispatch any item -->
        <div class="modal-dialog">
            <div class="modal-content">
                    <div class="modal-header">
                        <h4>ADD-DISPATCH QUANTITY<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="pname6" class="col-lg-5 control-label">Product Name</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="pname6" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pname" DataValueField="Pname" AutoPostBack="true" OnSelectedIndexChanged="pname6_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="dia6" class="col-lg-5 control-label">Diameter</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="dia6" CssClass="form-control" runat="server" DataSourceID="SqlDataSource7" DataTextField="Diameter" DataValueField="Diameter" AutoPostBack="true" OnSelectedIndexChanged="pname6_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Diameter] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Pname]=@pname">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="pname6" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="len6" class="col-lg-5 control-label">Length</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="len6" CssClass="form-control" runat="server" DataSourceID="SqlDataSource8" DataTextField="Length" DataValueField="Length" AutoPostBack="true" OnSelectedIndexChanged="pname6_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Length] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Diameter]=@dia">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="dia6" Name="dia" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="pname6" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="qty6" class="col-lg-5 control-label">QUANTITY TO ADD OR DISPATCH</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="qty6" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="upd2_add" CssClass="btn btn-primary" runat="server" OnClick="upd2_add_Click" Text="ADD" />
                        <asp:button ID="upd2_dispatch" CssClass="btn btn-primary" runat="server" OnClick="upd2_dispatch_Click" Text="DISPATCH" />
                    </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="sea" role="dialog" data-backdrop="static">                    <!--A form to search any product from records that takes product name, diameter and length as product parameters -->  
        <div class="modal-dialog">
            <div class="modal-content">
                    <div class="modal-header">
                        <h4>Search Product<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="pname4" class="col-lg-5 control-label">Product Name</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="pname4" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pname" DataValueField="Pname" AutoPostBack="true" OnSelectedIndexChanged="pname4_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="dia4" class="col-lg-5 control-label">Diameter</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="dia4" CssClass="form-control" runat="server" DataSourceID="SqlDataSource9" DataTextField="Diameter" DataValueField="Diameter" AutoPostBack="true" OnSelectedIndexChanged="pname4_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Diameter] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Pname]=@pname">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="pname4" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="len4" class="col-lg-5 control-label">Length</label>
                            <div class="col-lg-7">
                            <asp:DropDownList ID="len4" CssClass="form-control" runat="server" DataSourceID="SqlDataSource10" DataTextField="Length" DataValueField="Length" AutoPostBack="true" OnSelectedIndexChanged="pname4_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Length] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Diameter]=@dia">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="dia4" Name="dia" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="pname4" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="sea_submit" CssClass="btn btn-primary" runat="server" OnClick="sea_submit_Click" Text="SUBMIT" />
                        <asp:button ID="sea_reset" CssClass="btn btn-default" runat="server" OnClick="sea_reset_Click" Text="RESET" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="rep1" role="dialog" data-backdrop="static">               <!--A form for purchase, sales and dead-stock report generation-->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>REPORT GENERATION<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="frm_date1" class="col-lg-5 control-label">From Date</label>
                            <div class='col-lg-7'>
                                <asp:TextBox ID="frm_date1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="to_date" class="col-lg-5 control-label">To Date</label>
                            <div class='col-lg-7'>
                                <asp:TextBox ID="to_date1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="rep1_purchase" CssClass="btn btn-primary" runat="server" OnClick="rep1_purchase_Click" Text="PURCHASE" />
                        <asp:button ID="rep1_sales" CssClass="btn btn-primary" runat="server" OnClick="rep1_sales_Click" Text="SALES" />
                        <asp:button ID="rep1_deadstk" CssClass="btn btn-primary" runat="server" OnClick="rep1_deadstk_Click" Text="DEAD STOCK" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="party_led" role="dialog" data-backdrop="static">          <!-- A form for party ledger report generation that gives information about the transaction details according to a particular company  --> 
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>PARTY LEDGER REPORT<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="frm_date2" class="col-lg-5 control-label">From Date</label>
                            <div class='col-lg-7'>
                                <asp:TextBox ID="frm_date2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="to_date2" class="col-lg-5 control-label">To Date</label>
                            <div class='col-lg-7'>
                                <asp:TextBox ID="to_date2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="to_date2" class="col-lg-5 control-label">COMPANY</label>
                            <div class='col-lg-7'>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Cname] FROM [Supplier];">
                                </asp:SqlDataSource>
                                <asp:DropDownList ID="company2" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="Cname" DataValueField="Cname"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="party_led_submit" CssClass="btn btn-primary" runat="server" OnClick="party_led_submit_Click" Text="SUBMIT" />
                        </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="min_avl" role="dialog" data-backdrop="static">            <!--A form that gives information about the products below minimum availability -->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>LIST OF PRODUCTS BELOW MINIMUM AVAILABILITY<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "true" BorderStyle="Outset">
                            <headerstyle cssclass="GridViewHeader" forecolor="#ffffff" BackColor="Black" verticalalign="Bottom" Width="30" />
	                        <rowstyle cssclass="GridViewRow" verticalalign="Top" />
	                        <alternatingrowstyle cssclass="GridViewAlternatingRow" BackColor="#bbbbbb" verticalalign="Top" />
                        </asp:GridView> 
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="min_avl_submit" CssClass="btn btn-primary" runat="server" OnClick="minavl_Click" Text="SHOW" />
                        <asp:button ID="min_avl_print" CssClass="btn btn-success" runat="server" OnClick="min_avl_print_Click" Text="PRINT" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="deadstk_result" role="dialog" data-backdrop="static">     <!--A form that gives information of non-moving products of inventory--> 
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>LIST OF DEAD STOCK PRODUCTS<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns = "true" BorderStyle="Outset">
                            <headerstyle cssclass="GridViewHeader" forecolor="#ffffff" BackColor="Black" verticalalign="Bottom" Width="30" />
	                        <rowstyle cssclass="GridViewRow" verticalalign="Top" />
	                        <alternatingrowstyle cssclass="GridViewAlternatingRow" BackColor="#bbbbbb" verticalalign="Top" />
                        </asp:GridView>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="deadstk_ok" CssClass="btn btn-primary" runat="server" Text="SHOW" />
                        <asp:button ID="deadstk_print" CssClass="btn btn-success" runat="server" OnClick="deadstk_print_Click" Text="PRINT" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="spl" role="dialog" data-backdrop="static">                <!--A form that takes details of suppliers-->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>INSERT SUPPLIER DETAILS<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="cname7" class="col-lg-5 control-label">COMPANY NAME</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cname7" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cadd7" class="col-lg-5 control-label">COMPANY ADDRESS</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cadd7" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cemail7" class="col-lg-5 control-label">E-MAIL</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cemail7" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="phno7" class="col-lg-5 control-label">Phone no.</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="phno7" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="spl_submit" CssClass="btn btn-primary" runat="server" OnClick="spl_submit_Click" Text="ADD" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="cst" role="dialog" data-backdrop="static">                <!--A form that takes details of customer -->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>INSERT CUSTOMER DETAILS<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="coid8" class="col-lg-5 control-label">COMPANY NAME</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cname8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cadd8" class="col-lg-5 control-label">COMPANY ADDRESS</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cadd8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cemail8" class="col-lg-5 control-label">COMPANY E-MAIL</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cemail8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="cst8" class="col-lg-5 control-label">CST</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="cst8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div><div class="form-group">
                            <label for="vat8" class="col-lg-5 control-label">VAT</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="vat8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div><div class="form-group">
                            <label for="cemail8" class="col-lg-5 control-label">PHONE NO.</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="phno8" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="cst_submit" CssClass="btn btn-primary" runat="server" OnClick="cst_submit_Click" Text="ADD" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="sal_inv" role="dialog" data-backdrop="static">            <!--A form that generates sales invoice-->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>SALES INVOICE<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="col-lg-5 control-label">INVOICE NUMBER</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_num9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">INVOICE DATE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_date9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">TERMS OF CONDITION</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_toc9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">ORDER NO.</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_odno9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESPATCHED THROUGH</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_dth9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESTINATION</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_des9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">OTHER REFERENCES</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_oref9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DELIVERY NOTE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_dnot9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">SUPPLIER REFERENCE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_sref9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">MOTOR VEHICLE NO.</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_vno9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESPATCHED DOCUMENT NO.</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_ddoc9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESPATCHED DATE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="in_ddate9" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:button ID="in_submit" CssClass="btn btn-primary" runat="server" OnClick="in_submit_Click" Text="SUBMIT" />
                        <asp:button ID="in_reset" CssClass="btn btn-default" runat="server" OnClick="in_reset_Click" Text="RESET" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="sal_odr" role="dialog" data-backdrop="static">            <!--A form that takes sales order details-->
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>SALES ORDER<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="col-lg-5 control-label">COMPANY ID</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="company_id" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">ORDER DATE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="order_date" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">STATUS</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="Status" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESPATCHED</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="Despatched" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESTINATION</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="destin" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">OTHER REFERENCES</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="other_ref" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">MODE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="mod" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">TERMS OF DELIVERY</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="term" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">BUYER'S REFERENCE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="buy" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="modal-footer">
                        <asp:button ID="sal_odr_submit" CssClass="btn btn-primary" runat="server" OnClick="sal_odr_submit_Click" Text="SUBMIT" />
                        <asp:button ID="sal_order_reset" CssClass="btn btn-default" runat="server" OnClick="sal_order_reset_Click" Text="RESET" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="sod" role="dialog" data-backdrop="static">                <!--A form that takes information of the product to be added in sales order--> 
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>SALES ORDER DETAILS<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="col-lg-5 control-label">PRODUCT NAME</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="pname11" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pname" DataValueField="Pname" AutoPostBack="true" OnSelectedIndexChanged="pname11_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DIAMETER</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="dia11" CssClass="form-control" runat="server" DataSourceID="SqlDataSource11" DataTextField="Diameter" DataValueField="Diameter" AutoPostBack="true" OnSelectedIndexChanged="pname11_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Diameter] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Pname]=@pname">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="pname11" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">LENGTH</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="len11" CssClass="form-control" runat="server" DataSourceID="SqlDataSource12" DataTextField="Length" DataValueField="Length" AutoPostBack="true" OnSelectedIndexChanged="pname11_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Length] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Diameter]=@dia">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="dia11" Name="dia" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="pname11" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">QUANTITY</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="qty11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DESPATCHED</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DUE DATE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="due11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">STATUS</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="status11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">RATE</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="rate11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DISCOUNT</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="disc11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">AMOUNT</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="amt11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">PER</label>
                            <div class="col-lg-7">
                                <asp:TextBox ID="per11" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                        <asp:button ID="sod_submit" CssClass="btn btn-primary" runat="server" OnClick="sod_submit_Click" Text="SUBMIT" />
                        <asp:button ID="sod_reset" CssClass="btn btn-default" runat="server" OnClick="sod_reset_Click" Text="RESET" />
                        </div>
                        </div>
                </div>
            </div>

            <div class="modal fade" id="pur_odr" role="dialog" data-backdrop="static">        <!--A form that takes information about the purchase order-->
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4>PURCHASE ORDER<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="col-lg-5 control-label">COMPANY</label>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="cname12" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 control-label">ORDER</label>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="odr12" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 control-label">ORDER DATE</label>
                                    <div class="col-lg-7">
                                <asp:TextBox ID="o_date12" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 control-label">STATUS</label>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="sta12" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-5 control-label">INVOICE NUMBER</label>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="inv_no12" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        
                            <div class="modal-footer">
                                <asp:button ID="pur_odr_submit" CssClass="btn btn-primary" runat="server" OnClick="pur_odr_submit_Click" Text="SUBMIT" />
                                <asp:button ID="pur_ode_reset" CssClass="btn btn-default" runat="server" OnClick="pur_odr_reset_Click" Text="RESET" />
                            </div>
                        </div>
                    </div>
               </div>
            </div>

        <div class="modal fade" id="pod" role="dialog" data-backdrop="static">                <!--A form that takes information of the product to be added in the purchase order --> 
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4>PURCHASE ORDER DETAILS<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label class="col-lg-5 control-label">PRODUCT NAME</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="pname13" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pname" DataValueField="Pname" AutoPostBack="true" OnSelectedIndexChanged="pname13_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">DIAMETER</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="dia13" CssClass="form-control" runat="server" DataSourceID="SqlDataSource13" DataTextField="Diameter" DataValueField="Diameter" AutoPostBack="true" OnSelectedIndexChanged="pname13_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource13" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Diameter] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Pname]=@pname">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="pname13" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-5 control-label">LENGTH</label>
                            <div class="col-lg-7">
                                <asp:DropDownList ID="len13" CssClass="form-control" runat="server" DataSourceID="SqlDataSource14" DataTextField="Length" DataValueField="Length" AutoPostBack="true" OnSelectedIndexChanged="pname13_SelectedIndexChanged"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource14" runat="server" ConnectionString='Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\rushi\Documents\Visual Studio 2012\Projects\WebApplication5\WebApplication5\Project.mdb"' ProviderName="System.Data.OleDb" SelectCommand="SELECT DISTINCT [Length] FROM [Product],[Pcode] WHERE [Pcode.Pname]=[Product.Pname] AND [Product.Diameter]=@dia">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="dia13" Name="dia" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="pname13" Name="pname" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">QUANTITY</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="qty13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">CREATED DATE</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="cre_date13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">SUBMITTED DATE</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="sub_date13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">EXPECTED DATE</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="exp_date13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">PAYMENT DATE</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="pmt_date13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">AMOUNT</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="amt13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">PAYMENT METHOD</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="pmt_met13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">APPROVED DATE</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="apr_date13" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                        
                    <div class="modal-footer">
                        <asp:button ID="pod_submit" CssClass="btn btn-primary" runat="server" OnClick="pod_submit_Click" Text="SUBMIT" />
                        <asp:button ID="pod_reset" CssClass="btn btn-default" runat="server" OnClick="pod_reset_Click" Text="RESET" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
