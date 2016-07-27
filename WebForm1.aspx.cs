using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using iTextSharp.text.xml.simpleparser;
using iTextSharp.tool.xml;

namespace WebApplication3
{
    public class prcode                                                                  /* Class with a method to generate Prcode*/
    {
        public string c;
        public Int32 getcode(String pname, Int32 dia, Int32 len)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            OdbcCommand cmd = new OdbcCommand();
            cmd.CommandText = "select ID from Pcode where Pname = ?";
            cmd.Connection = con;
            cmd.Parameters.Add(new OdbcParameter("Pname", pname));
            OdbcDataReader dr3 = cmd.ExecuteReader();
            dr3.Read();
            Int32 f = dr3.GetInt32(0);
            String s = "0";
            String s1 = f.ToString();
            if ((s1.Length) == 1)
            {
                s1 = s + s1;
            }

            String d = dia.ToString();
            if ((d.Length) == 1)
            {
                d = s + d;
            }

            String l = len.ToString();
            if ((l.Length) == 1)
            {
                l = s + s + l;
            }

            else if ((l.Length) == 2)
            {
                l = s + l;
            }
            c = s1 + d + l;
            Int32 code = Convert.ToInt32(c);
            con.Close();
            return code;
        }
    }

    public partial class WebForm1 : System.Web.UI.Page                                   /*Class of webform */
                                                                                          
    {
        OdbcConnection con;
        Int32 code, avl, Avail;
        static Int32 id11=1,id13=1,id14 = 1,id15=1,id16=1,id17=1,id18=1;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void insertReset_Click(object sender, EventArgs e)                     /*Method that resets the insert form*/
        {
            pname1.Text = null;
            isdin1.Text = null;
            part1.Text = "PART:1";
            dia1.Text = null;
            len1.Text = null;
            plating1.Text = "BLACK";
            grade1.Text = "8.8";
            rackpos1.Text = null;
            price1.Text = null;
            qty1.Text = null;
            suplier1.Text = null;
            minavl1.Text = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openinsModal();", true);

        }
        protected void insertSubmit_Click(object sender, EventArgs e)                    /*Method for the operation when submit button is clicked in insert form*/ 
        {
            String s = pname1.Text;
            con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            OdbcCommand cmd = new OdbcCommand("select * from Pcode where Pname = ?", con);
            cmd.Parameters.Add(new OdbcParameter("Pname", s));

            OdbcDataReader dr = cmd.ExecuteReader();
            int id;
            if (!dr.Read())
            {
                OdbcCommand cmd1 = new OdbcCommand("select * from Pcode", con);
                OdbcDataReader dr1 = cmd1.ExecuteReader();
                // dr1.Read();
                id = 1;
                while (dr1.Read())
                    id++;
                dr1.Close();
                cmd1.CommandText = "insert into Pcode(Pname) values(?)";
                //cmd1.Parameters.Add(new OdbcParameter("ID", id));
                cmd1.Parameters.Add(new OdbcParameter("Pname", s));
                int n = cmd1.ExecuteNonQuery();
                //  TextBox1.Text = id.ToString();
            }


            dr.Close();
            Int32 dia = Convert.ToInt32(dia1.Text);
            Int32 len = Convert.ToInt32(len1.Text);
            String part = part1.SelectedValue;
            Int32 isdn = Convert.ToInt32(isdin1.Text);
            Int32 avl = Convert.ToInt32(qty1.Text);
            Int32 rate = Convert.ToInt32(price1.Text);
            String rl = rackpos1.Text;
            String coname = suplier1.Text;
            Double gr = Convert.ToDouble(grade1.SelectedValue);
            String pl = plating1.SelectedValue;
            Int32 minavl = Convert.ToInt32(minavl1.Text);
            con.Close();
            prcode pr = new prcode();
            
            Int32 code = pr.getcode(s, dia, len);
            con.Open();

            cmd.CommandText = "select Cid from Supplier where Cname ='" + coname + "'";
            // cmd.Parameters.Add(new OdbcParameter("Cname", coname));
            dr = cmd.ExecuteReader();
            dr.Read();
            Int32 coid = dr.GetInt32(0);
            // TextBox1.Text = coid.ToString();
            dr.Close();
            cmd = new OdbcCommand("select * from Rack where Rlocation = ?", con);
            cmd.Parameters.Add(new OdbcParameter("Rlocation", rl));

            dr = cmd.ExecuteReader();
            if (!dr.Read())
            {
                OdbcCommand cmd1 = new OdbcCommand("select * from Rack", con);
                OdbcDataReader dr1 = cmd1.ExecuteReader();
                // dr1.Read();
                while (dr1.Read())
                    id14++;
                dr1.Close();
                cmd1.CommandText = "insert into Rack values(?,?)";
                cmd1.Parameters.Add(new OdbcParameter("Rid", id14));
                cmd1.Parameters.Add(new OdbcParameter("Rlocation", rl));
                int n = cmd1.ExecuteNonQuery();
                // TextBox1.Text = id.ToString();
            }
            dr.Close();
            cmd.CommandText = "select Rid from Rack where Rlocation = '" + rl + "'";
            // cmd.Parameters.Add(new OdbcParameter("Rlocation", rl));
            dr = cmd.ExecuteReader();
            dr.Read();
            Int32 rid = dr.GetInt32(0);
            dr.Close();

            OdbcCommand cmd2 = new OdbcCommand("insert into Product values(?,?,?,?,?,?,?,?,?,?,?,?,?)", con);
            //cmd.CommandText = "insert into Product values(?,?,?,?,?,?,?,?,?)";
            cmd2.Parameters.Add(new OdbcParameter("Prcode", code));
            cmd2.Parameters.Add(new OdbcParameter("Pname", s));
            cmd2.Parameters.Add(new OdbcParameter("Cid", coid));
            cmd2.Parameters.Add(new OdbcParameter("Rid", rid));
            cmd2.Parameters.Add(new OdbcParameter("Part", part));
            cmd2.Parameters.Add(new OdbcParameter("ISDIN", isdn));
            cmd2.Parameters.Add(new OdbcParameter("Diameter", dia));
            cmd2.Parameters.Add(new OdbcParameter("Length", len));
            cmd2.Parameters.Add(new OdbcParameter("Availability", avl));
            cmd2.Parameters.Add(new OdbcParameter("Price", rate));
            cmd2.Parameters.Add(new OdbcParameter("Grade", gr));
            cmd2.Parameters.Add(new OdbcParameter("Plating", pl));
            cmd2.Parameters.Add(new OdbcParameter("Min_Availability", minavl));

            int n1 = cmd2.ExecuteNonQuery();

            con.Close();

            string barCode = Convert.ToString(code);                                     /*To generate the barcode of a product*/
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();

            using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    System.Drawing.Font oFont = new System.Drawing.Font("IDAutomationHC39M", 16);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                PlaceHolder1.Controls.Add(imgBarCode);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openinsModal();", true);
        }

        protected void upd_submit_Click(object sender, EventArgs e)
        {


        }

        protected void upd_reset_Click(object sender, EventArgs e)                       /* Method to reset the update form*/
        {
            pname2.Text = null;
            isdin2.Text = null;
            part2.Text = "PART:1";
            dia2.Text = null;
            len2.Text = null;
            plating2.Text = "BLACK";
            grade2.Text = "8.8";
            rackpos2.Text = null;
            price2.Text = null;
            qty2.Text = null;
            suplier2.Text = null;
            minavl2.Text = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openupdModal();", true);

        }

        protected void del_reset_Click(object sender, EventArgs e)                       /*Method to reset the delete item form*/ 
        {
            pname3.Text = null;
            dia3.Text = null;
            len3.Text = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opendelModal();", true);
        }

        protected void sea_submit_Click(object sender, EventArgs e)                      /*Method to search the product*/
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            String s = pname4.Text;
            Int32 dia = Convert.ToInt32(dia4.Text);
            Int32 len = Convert.ToInt32(len4.Text);

            prcode pr = new prcode();
            Int32 code = pr.getcode(s, dia, len);

            OdbcCommand cmd = new OdbcCommand("select Product.Pname,Diameter,Length,Availability from Product,Pcode where Product.Pname=Pcode.Pname AND Prcode =" + code, con);


            OdbcDataReader dr = cmd.ExecuteReader();

            Response.Write("<div class=\"modal\" id=\"sea_result\" data-show=\"true\">");
            Response.Write("<div class=\"modal-dialog\">");
            Response.Write("<div class=\"modal-content\">");
            Response.Write("<div class=\"modal-header\">");
            Response.Write("<h4>SEARCH RESULT<button type=\"button\" class=\"close\" data-dismiss=\"modal\" onclick=\"insert_ResetClick\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button></h4></div>");
            Response.Write("<div class=\"modal-body\"> ");
            Response.Write("<Table class=\"table table-bordered table-striped\">");
            Response.Write("<tr>");
            Response.Write("<th>Product Name</th>");
            Response.Write("<th>Diameter</th>");
            Response.Write("<th>Length</th>");
            Response.Write("<th>Availability</th>");
            Response.Write("</tr>");
            if (dr.Read())
            {

                Response.Write("<Tr>");
                Response.Write("<Td>" + dr.GetString(0) + "</td>");
                Response.Write("<Td>" + dr.GetString(1) + "</td>");
                Response.Write("<Td>" + dr.GetString(2) + "</td>");
                Response.Write("<Td>" + dr.GetString(3) + "</td>");
                Response.Write("</Tr>");

            }

            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<div class=\"modal-footer\" ");
            Response.Write("<asp:button ID=\"sea_result_OK\" CssClass=\"btn btn-primary\" runat=\"server\" Text=\"OK\" /> ");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opensearesultModal();", true);

        }

        protected void del_submit_Click(object sender, EventArgs e)                      /*method to delete any item from record*/
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            String s = pname3.Text;
            Int32 dia = Convert.ToInt32(dia3.Text);
            Int32 len = Convert.ToInt32(len3.Text);

            prcode pr = new prcode();
            Int32 code = pr.getcode(s, dia, len);

            OdbcCommand cmd = new OdbcCommand("select Cname,Rlocation,Part,ISDIN,Diameter,Length,Availability,Price,Grade,Plating,Min_Availability,Pname from Product,Rack,Supplier where  Product.Cid=Supplier.Cid and Product.Rid=Rack.Rid and Product.Prcode =" + code, con);

            OdbcDataReader dr = cmd.ExecuteReader();
            dr.Read();
            upd_reset_Click(sender,e);
            pname2.Text = dr.GetString(11);
            suplier2.Text = dr.GetString(0);
            rackpos2.Text = dr.GetString(1);
            part2.SelectedValue = dr.GetString(2);
            isdin2.Text = dr.GetInt32(3).ToString();
            dia2.Text = dr.GetInt32(4).ToString();
            len2.Text = dr.GetInt32(5).ToString();
            qty2.Text = dr.GetInt32(6).ToString();
            price2.Text = dr.GetDouble(7).ToString();
            plating2.SelectedValue = dr.GetString(9);
            grade2.SelectedValue = dr.GetDouble(8).ToString();
            minavl2.Text = dr.GetInt32(10).ToString();
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openupdModal();", true);
        }

        protected void upd_update_Click(object sender, EventArgs e)                      /*Method to update information of any product*/ 
        {
            OdbcConnection con1 = new OdbcConnection("DSN=project2.mdb");
            con1.Open();
            String s = pname2.Text;
            Int32 dia = Convert.ToInt32(dia2.Text);
            Int32 len = Convert.ToInt32(len2.Text);
            prcode pr = new prcode();
            Int32 code = pr.getcode(s, dia, len);

            String p = part2.SelectedValue;
            Int32 isd = Convert.ToInt32(isdin2.Text);
            Int32 a = Convert.ToInt32(qty2.Text);
            Int32 pri = Convert.ToInt32(price2.Text);
            String pla = plating2.SelectedValue;
            Double g = Convert.ToDouble(grade2.SelectedValue);
            Int32 minavl = Convert.ToInt32(minavl2.Text);
            String str = "update Product set Part='" + p + "',ISDIN=" + isd + ",Availability=" + a + ",Price=" + pri + ",Plating='" + pla + "',Grade=" + g + ",Min_Availability=" + minavl + "  where Prcode =" + code + "";
            OdbcCommand cmd1 = new OdbcCommand(str, con1);
            int n2 = cmd1.ExecuteNonQuery();
            con1.Close();

            pname3.Text = null;
            dia3.Text = null;
            len3.Text = null;
        }

        protected void bcd_submit_Click(object sender, EventArgs e)
        {
            Int32 pid;
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            if(pcode5.Text.Length==6)
                pid = Convert.ToInt32(pcode5.Text.ElementAt(0)) - 48;
            else
                pid=Convert.ToInt32(pcode5.Text.Substring(0,2));
            Int32 code = Convert.ToInt32(pcode5.Text);

            OdbcCommand cmd = new OdbcCommand("select Cname,Rlocation,Part,ISDIN,Diameter,Length,Availability,Price,Grade,Plating,Min_Availability,Product.Pname from Product,Rack,Supplier,Pcode where  Product.Cid=Supplier.Cid and Product.Rid=Rack.Rid and Pcode.ID=" + pid + "and Product.Prcode =" + code +"", con);

            OdbcDataReader dr = cmd.ExecuteReader();
            dr.Read();

            pname2.Text = dr.GetString(11);
            suplier2.Text = dr.GetString(0);
            rackpos2.Text = dr.GetString(1);
            part2.SelectedValue = dr.GetString(2);
            isdin2.Text = dr.GetInt32(3).ToString();
            dia2.Text = dr.GetInt32(4).ToString();
            len2.Text = dr.GetInt32(5).ToString();
            qty2.Text = dr.GetInt32(6).ToString();
            price2.Text = dr.GetDouble(7).ToString();
            plating2.SelectedValue = dr.GetString(9);
            grade2.SelectedValue = dr.GetDouble(8).ToString();
            minavl2.Text = dr.GetInt32(10).ToString();
            dr.Close();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openupdModal();", true);
        }

        protected void upd2_add_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            prcode pr = new prcode();
            String s = pname6.Text;
            Int32 dia = Convert.ToInt32(dia6.Text);
            Int32 len = Convert.ToInt32(len6.Text);
            Int32 code = pr.getcode(s, dia, len);
            // TextBox1.Text = code.ToString();
            OdbcCommand cmd = new OdbcCommand("select Availability from Product where Prcode= ?", con);
            cmd.Parameters.Add(new OdbcParameter("Prcode", code));
            OdbcDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Int32 avl = dr.GetInt32(0);
            Int32 q = Convert.ToInt32(qty6.Text);
            avl = avl + q;
            string str = "update Product set Availability=" + avl + "  where Prcode =" + code + "";
            OdbcCommand cmd1 = new OdbcCommand(str, con);
            int n2 = cmd1.ExecuteNonQuery();
        }

        protected void upd2_dispatch_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            prcode pr = new prcode();
            String s = pname6.Text;
            Int32 dia = Convert.ToInt32(dia6.Text);
            Int32 len = Convert.ToInt32(len6.Text);
            Int32 code = pr.getcode(s, dia, len);
            // TextBox1.Text = code.ToString();
            OdbcCommand cmd = new OdbcCommand("select Availability,Min_Availability from Product where Prcode= ?", con);
            cmd.Parameters.Add(new OdbcParameter("Prcode", code));
            OdbcDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Int32 avl = dr.GetInt32(0);
            Int32 mavl = dr.GetInt32(1);
            //Quantity.Text = mavl.ToString();
            //TextBox1.Text = avl.ToString();
            Int32 q = Convert.ToInt32(qty6.Text);
            avl = avl - q;
            if (avl <= mavl)
            {
                if (avl < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "My Script", "confirm('Sorry, there is not enough stock to complete this transaction...');", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "My Script", "confirm('Quantity will be less than the minimum availability level. Delete Anyway???');", true);
                    string confirmValue = Request.Form["confirm_value"];
                    if (confirmValue == "Yes")
                    {
                    }
                    else
                    {
                        return;
                    }
                }
            }
            string str = "update Product set Availability=" + avl + "  where Prcode =" + code + "";
            OdbcCommand cmd1 = new OdbcCommand(str, con);
            int n2 = cmd1.ExecuteNonQuery();
            dr.Close();
        }

        protected void rep1_purchase_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            DateTime D1 = Convert.ToDateTime(frm_date1.Text);
            DateTime D2 = Convert.ToDateTime(to_date1.Text);

            OdbcCommand cmd1 = new OdbcCommand();
            cmd1.CommandText = "SELECT Prcode,SUM(Quantity),SUM(Payment_Amount),Cname,MONTH(Order_date) FROM Purchase_order,Purchase_Order_Details,Customer WHERE Purchase_Order_Details.Order_id=Purchase_order.Order_id AND Customer.Cid=Purchase_order.Cid AND Purchase_order.Order_date BETWEEN #" + D1 + "# AND #" + D2 + "# GROUP BY MONTH(Order_date),Purchase_Order_Details.Prcode,Customer.Cname;";
            cmd1.Connection = con;
            OdbcDataReader dr = cmd1.ExecuteReader();
            Response.Write("<div class=\"modal\" id=\"rep_result\" data-show=\"true\">");
            Response.Write("<div class=\"modal-dialog\">");
            Response.Write("<div class=\"modal-content\">");
            Response.Write("<div class=\"modal-header\">");
            Response.Write("<h4>SALES REPORT<button type=\"button\" class=\"close\" data-dismiss=\"modal\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button></h4></div>");
            Response.Write("<div class=\"modal-body\"> ");
            Response.Write("<Table class=\"table table-bordered table-striped\">");
            Response.Write("<tr>");
            Response.Write("<th>Product Name</th>");
            Response.Write("<th>Quantity</th>");
            Response.Write("<th>Amount</th>");
            Response.Write("<th>Company</th>");
            Response.Write("<th>MONTH</th>");
            Response.Write("</tr>");
            while (dr.Read())
            {

                Response.Write("<Tr>");
                Response.Write("<Td>" + dr.GetString(0) + "</td>");
                Response.Write("<Td>" + dr.GetString(1) + "</td>");
                Response.Write("<Td>" + dr.GetString(2) + "</td>");
                Response.Write("<Td>" + dr.GetString(3) + "</td>");
                Response.Write("<Td>" + dr.GetString(4) + "</td>");
                Response.Write("</Tr>");
            }

            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<div class=\"modal-footer\" ");
            Response.Write("<asp:button ID=\"sea_result_OK\" CssClass=\"btn btn-primary\" runat=\"server\" Text=\"OK\" /> ");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            dr.Read();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openrep_resModal();", true);

        }

        protected void rep1_sales_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            DateTime D1 = Convert.ToDateTime(frm_date1.Text);
            DateTime D2 = Convert.ToDateTime(to_date1.Text);

            OdbcCommand cmd1 = new OdbcCommand();
            cmd1.CommandText = "SELECT Product,Diameter,Length,SUM(Quantity),SUM(Amount),Cname,MONTH(Order_date) FROM Sales_order,Sales_Details,Supplier WHERE Sales_Details.Order_id=Sales_order.Order_id AND Supplier.Cid=Sales_order.Cid AND Sales_order.Order_date BETWEEN #" + D1 + "# AND #" + D2 + "# GROUP BY MONTH(Order_date),Product,Supplier.Cname;";
            cmd1.Connection = con;
            OdbcDataReader dr = cmd1.ExecuteReader();
            Response.Write("<div class=\"modal\" id=\"rep_result\" data-show=\"true\">");
            Response.Write("<div class=\"modal-dialog\">");
            Response.Write("<div class=\"modal-content\">");
            Response.Write("<div class=\"modal-header\">");
            Response.Write("<h4>SALES REPORT<button type=\"button\" class=\"close\" data-dismiss=\"modal\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button></h4></div>");
            Response.Write("<div class=\"modal-body\"> ");
            Response.Write("<Table class=\"table table-bordered table-striped\">");
            Response.Write("<tr>");
            Response.Write("<th>Product Name</th>");
            Response.Write("<th>Diameter</th>");
            Response.Write("<th>Length</th>");
            Response.Write("<th>Quantity</th>");
            Response.Write("<th>Amount</th>");
            Response.Write("<th>Company</th>");
            Response.Write("<th>MONTH</th>");
            Response.Write("</tr>");
            while (dr.Read())
            {
                
                Response.Write("<Tr>");
                Response.Write("<Td>" + dr.GetString(0) + "</td>");
                Response.Write("<Td>" + dr.GetString(1) + "</td>");
                Response.Write("<Td>" + dr.GetString(2) + "</td>");
                Response.Write("<Td>" + dr.GetString(3) + "</td>");
                Response.Write("<Td>" + dr.GetString(4) + "</td>");
                Response.Write("</Tr>");
            }

            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<div class=\"modal-footer\" ");
            Response.Write("<asp:button ID=\"sea_result_OK\" CssClass=\"btn btn-primary\" runat=\"server\" Text=\"OK\" /> ");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            dr.Read();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openrep_resModal();", true);
        }

        protected void spl_submit_Click(object sender, EventArgs e)
        {
            String s;
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            //   Response.Redirect("WebForm6.aspx?val1=" + part.Text + "&val2=" + isdin.Text + "&val3=" + avail.Text + "&val4=" + price.Text + "&val5=" +plating.Text+ "&val6="+Grade.Text );
            con.Open();
            s = '1' + id15.ToString();
            String name = cname7.Text;
            Int32 cid = Convert.ToInt32(s);
            String addr = cadd7.Text;
            String email = cemail7.Text;

            OdbcCommand cmd = new OdbcCommand("insert into Supplier values(?,?,?,?,?)", con);
            cmd.Parameters.Add(new OdbcParameter("Cid", cid));
            cmd.Parameters.Add(new OdbcParameter("Cname", name));
            cmd.Parameters.Add(new OdbcParameter("Address", addr));
            cmd.Parameters.Add(new OdbcParameter("Email", email));
            cmd.Parameters.Add(new OdbcParameter("Email", phno7.Text));

            id15++;
            int n = cmd.ExecuteNonQuery();
            con.Close();

            //coid7.Text = null;
            cname7.Text = null;
            cadd7.Text = null;
            cemail7.Text = null;
        }

        protected void cst_submit_Click(object sender, EventArgs e)
        {
            String s;
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();

            String name = cname8.Text;
            String addr = cadd8.Text;
            String email = cemail8.Text;
            String CST = cst8.Text;
            String VAT = vat8.Text;
            String Phone = phno8.Text;
            s = '2' + id16.ToString();
            Int32 cid = Convert.ToInt32(s);
            OdbcCommand cmd = new OdbcCommand("insert into Customer values(?,?,?,?,?,?,?)", con);
            cmd.Parameters.Add(new OdbcParameter("Cid", cid));
            cmd.Parameters.Add(new OdbcParameter("Cname", name));
            cmd.Parameters.Add(new OdbcParameter("Address", addr));
            cmd.Parameters.Add(new OdbcParameter("Email", email));
            cmd.Parameters.Add(new OdbcParameter("CST", CST));
            cmd.Parameters.Add(new OdbcParameter("VAT", VAT));
            cmd.Parameters.Add(new OdbcParameter("Phone no", Phone));
            id16++;
            int n = cmd.ExecuteNonQuery();
            con.Close();
            //coid8.Text = null;
            cname8.Text = null;
            cadd8.Text = null;
            cst8.Text = null;
            vat8.Text = null;
            phno8.Text = null;
            cemail8.Text = null;
        }

        protected void in_submit_Click(object sender, EventArgs e)
        {
            Response.Write("<div class=\"modal fade\" id=\"sales_invoice\" style=\"font-size:12\" data-show=\"true\">");
            Response.Write("<div class=\"modal-dialog modal-lg\">");
            Response.Write("<div class=\"modal-content\">");
            Response.Write("<div class=\"modal-header\">");
            Response.Write("<h4>SALES INVOICE<button type=\"button\" class=\"close\" data-dismiss=\"modal\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button></h4></div>");
            Response.Write("<div class=\"modal-body\" id=\"sales_invoice_body\" runat=\"server\"> ");
            Response.Write("<center><b>TAX INVOICE</b><br>(ISSUE OF INVOICE UNDER RULE 11 OF CENTRAL EXCISE RULES 2002)");
            Response.Write("<Table class=\"table table-bordered\" style=\"font-size:12\">");
            Response.Write("<tr>");
            Response.Write("<td  colspan=7 style=\"margin:0;border-collapse:collapse\"><b>DEV ENTERPRISE CORPORATION (UNIT-II)</b><br><b>Plot No.157/A/1/WS-1,Opp.B.I.Patel Elecon Hall,Phase-1,G.I.D.C Estate,Vitthal Udhyognagar-388121.(Guj).</b><br><center>Phone:02692-229221,229121/Email:dev_sai40@yahoo.in</center><br>VAT TIN     :<right>Range:      </right><br>CST No.     :<right>Division        :</right><br>Excise Regn No.:<right>Commisionerate:<br>PAN/Income Tax No.:</right></td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2 rowspan=4>Cosignee<br><b>ELECOM EPC PROJECTS LIMITED</b><br>POST BOX NO.33<br>ANAND SOJITRA ROAD<br>VALLABH VIDYA NAGAR<br>DIST       :ANAND <br>VAT TIN     :Range      :<br>CST No.     :     Division        :<br>Excise Regn No.        :Commisionerate     :</th>");
            Response.Write("<td colspan=2>Invoice No.</td>");
            Response.Write("<td colspan=3>Dated</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Buyer's Order No.</td>");
            Response.Write("<td colspan=3>Dated</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Delivery Note</td>");
            Response.Write("<td colspan=3>Dated</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Supplier's Ref./Order No.</td>");
            Response.Write("<td colspan=3>Dispatch Document No.</td>");
           
            Response.Write("</tr>");

            Response.Write("<tr>");
            Response.Write("<td colspan=2 rowspan=4>Buyer(if other than cosignee)<br><b>ELECOM EPC PROJECTS LIMITED</b><br>POST BOX NO.33<br>ANAND SOJITRA ROAD<br>VALLABH VIDYA NAGAR<br>DIST:ANAND<br>VAT TIN     :<br>Range:      <br>CST No.     :<br>Division        :<br>Excise Regn No.:<br>Commisionerate:</th>");
            Response.Write("<td colspan=2>Dispatched Through</td>");
            Response.Write("<td colspan=3>Destination</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Date and Time of issu of Invoice</td>");
            Response.Write("<td colspan=3>Motor Vehicle No.</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Date and Time of Removal of Goods</td>");
            Response.Write("<td colspan=3 rowspan=2>Authenticated By</td>");
            Response.Write("</tr>");
            Response.Write("<tr>");
            Response.Write("<td colspan=2>Mode/Terms of Payment</td>");
            Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td width=7px>Sr No.</td>");
                Response.Write("<td>Description of Goods</td>");
                Response.Write("<td width=30px>Tariff/HSN Classification</td>");
                Response.Write("<td>Quantity</td>");
                Response.Write("<td>Rate</td>");
                Response.Write("<td>Per</td>");
                Response.Write("<td>Amount</td>");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td></td>");
                Response.Write("<td>Total</td>");
                Response.Write("<td></td>");
                Response.Write("<td></td>");
                Response.Write("<td></td>");
                Response.Write("<td></td>");
                Response.Write("<td></td>");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td colspan=7>Amount Chargeable(in words):</td>");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td colspan=7>Amount of Duty</td>");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td colspan=7>Serial no.");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td colspan=7>Declaration:We declare that this invoice shows the actual price of goods described and that all particulars are true and correct.</td>");
                Response.Write("</tr>");

                Response.Write("<tr>");
                Response.Write("<td colspan=3>Excise Declaration: We declare to the best of our knowledge and belief that the particulars stated herein are true and correct and there is no additional consideration accruning to us either directly or andirectly in any other than the amounts indicated here.</td>");
                Response.Write("<td colspan=4><center>for<b>DEV ENTERPRISE CORPORATION (UNIT-II)</b></center><br><br><br><left>Authorized Signatory</left><td>");
                Response.Write("</tr>");

            Response.Write("</table>");
            Response.Write("<center> SUBJECT TO ANAND JURISDICTION<br>This is a Computer Generated Invoice</center>");
            Response.Write("</div>");
            Response.Write("<div class=\"modal-footer\">");
            Response.Write("<button id=\"sales_inv_print\" class=\"btn btn-success\" runat=\"server\" onclick=\"sales_inv_print_Click\">PRINT</button>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opensalinvModal();", true);
        }

        protected void sales_inv_print_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=sales-invoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //sales_invoice_body.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void in_reset_Click(object sender, EventArgs e)
        {

        }

        protected void sal_odr_submit_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();

            Int32 cid = Convert.ToInt32(company_id.Text);
            DateTime o_date = Convert.ToDateTime(order_date.Text);
            String sta = Status.Text;
            String s;

            String bref = buy.Text;
            String oref = other_ref.Text;
            String des_th = Despatched.Text;
            String terms = term.Text;

            String mode = mod.Text;
            String dest = destin.Text;

            s = id17.ToString();
            s = 'S' + s;
            id17++;
            OdbcCommand cmd = new OdbcCommand("insert into Sales_order values(?,?,?,?,?,?,?,?,?,?)", con);
            cmd.Parameters.Add(new OdbcParameter("Order_id", s));
            cmd.Parameters.Add(new OdbcParameter("Cid", cid));
            cmd.Parameters.Add(new OdbcParameter("Order_Date", o_date));
            cmd.Parameters.Add(new OdbcParameter("Status", sta));
            cmd.Parameters.Add(new OdbcParameter("Buyer's Ref_No", bref));
            cmd.Parameters.Add(new OdbcParameter("Mode", mode));
            cmd.Parameters.Add(new OdbcParameter("Dispatched through", des_th));
            cmd.Parameters.Add(new OdbcParameter("Destination", dest));
            cmd.Parameters.Add(new OdbcParameter("Other References", oref));
            cmd.Parameters.Add(new OdbcParameter("Terms of Delivery", terms));
            int n = cmd.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opensodModal();", true);

        }

        protected void sal_order_reset_Click(object sender, EventArgs e)
        {

        }

        protected void sod_submit_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            prcode pr = new prcode();
            Int32 code = pr.getcode(pname11.Text, Convert.ToInt32(dia11.Text), Convert.ToInt32(len11.Text));
            OdbcCommand cmd1 = new OdbcCommand("select * from Product where Prcode=?", con);
            cmd1.Parameters.Add(new OdbcParameter("Prcode", code));
            OdbcDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                OdbcCommand cmd = new OdbcCommand("insert into Sales_Details values(?,?,?,?,?,?,?,?,?,?,?)", con);
                cmd.Parameters.Add(new OdbcParameter("ID", id11));
                //cmd.Parameters.Add(new OdbcParameter("Order_id", order_id.Text));
                cmd.Parameters.Add(new OdbcParameter("Product", pname11.Text));
                cmd.Parameters.Add(new OdbcParameter("Prcode", code));
                cmd.Parameters.Add(new OdbcParameter("Quantity", Convert.ToInt32(qty11.Text)));
                cmd.Parameters.Add(new OdbcParameter("Due_date", Convert.ToDateTime(due11.Text)));
                cmd.Parameters.Add(new OdbcParameter("Status", status11.Text));
                cmd.Parameters.Add(new OdbcParameter("Rate", Convert.ToInt32(rate11.Text)));
                cmd.Parameters.Add(new OdbcParameter("Discount", Convert.ToInt32(disc11.Text)));
                cmd.Parameters.Add(new OdbcParameter("Amount", Convert.ToInt32(amt11.Text)));
                cmd.Parameters.Add(new OdbcParameter("per", per11.Text));
                int n = cmd.ExecuteNonQuery();
                id11++;
                pname11.Text = "";
                dia11.Text = "";
                len11.Text = "";
                qty11.Text = "";
                due11.Text = "";
                status11.Text = "";
                rate11.Text = "";
                disc11.Text = "";
                amt11.Text = "";
                per11.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opensodModal();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "My Script", "confirm('Invalid Product');", true);
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    // TextBox1.Text = avl.ToString();

                }
                else
                {

                }

            }
            con.Close();
        }

        protected void sod_reset_Click(object sender, EventArgs e)
        {

        }

        protected void pur_odr_submit_Click(object sender, EventArgs e)
        {
            String s;
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();

            String comp = cname12.Text;
            OdbcCommand cmd1 = new OdbcCommand("select Cid from Supplier where Cname=?", con);
            cmd1.Parameters.Add(new OdbcParameter("Cname", comp));
            OdbcDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            Int32 cid = dr.GetInt32(0);
            s = id18.ToString();
            s = 'P' + s;
            id18++;
            OdbcCommand cmd = new OdbcCommand("insert into Purchase_order values(?,?,?,?,?,?)", con);
            cmd.Parameters.Add(new OdbcParameter("Order_id", s));
            cmd.Parameters.Add(new OdbcParameter("Cid", Convert.ToInt32(cid)));
            cmd.Parameters.Add(new OdbcParameter("Order", odr12.Text));
            cmd.Parameters.Add(new OdbcParameter("Order_date", Convert.ToDateTime(o_date12.Text)));
            cmd.Parameters.Add(new OdbcParameter("Status", sta12.Text));
            cmd.Parameters.Add(new OdbcParameter("Invoice_No",inv_no12.Text));
            int n = cmd.ExecuteNonQuery();

            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openpodModal();", true);

        }

        protected void pur_odr_reset_Click(object sender, EventArgs e)
        {

        }

        protected void pod_submit_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();

            prcode pr = new prcode();
            Int32 code = pr.getcode(pname13.Text, Convert.ToInt32(dia13.Text), Convert.ToInt32(len13.Text));

            OdbcCommand cmd = new OdbcCommand("insert into Purchase_Order_Details values(?,?,?,?,?,?,?,?,?,?,?)", con);
            cmd.Parameters.Add(new OdbcParameter("ID", id13));
            //cmd.Parameters.Add(new OdbcParameter("Order_id", oid12.Text));

            cmd.Parameters.Add(new OdbcParameter("Prcode", code));
            cmd.Parameters.Add(new OdbcParameter("Quantity", Convert.ToInt32(qty13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Creation_date", Convert.ToDateTime(cre_date13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Submitted_date", Convert.ToDateTime(sub_date13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Expected_date", Convert.ToDateTime(exp_date13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Payment_date", Convert.ToDateTime(pmt_date13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Payment_Amount", Convert.ToInt32(amt13.Text)));
            cmd.Parameters.Add(new OdbcParameter("Payment_Method", pmt_met13.Text));
            cmd.Parameters.Add(new OdbcParameter("Approved_date", Convert.ToDateTime(apr_date13.Text)));
            int n = cmd.ExecuteNonQuery();
            id13++;
            pname13.Text = "";
            dia13.Text = "";
            len13.Text = "";
            qty13.Text = "";
            cre_date13.Text = "";
            sub_date13.Text = "";
            exp_date13.Text = "";
            pmt_date13.Text = "";
            amt13.Text = "";
            pmt_met13.Text = "";
            apr_date13.Text = "";

            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openpodModal();", true);

        }

        protected void pod_reset_Click(object sender, EventArgs e)
        {

        }

        protected void pname2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openupdModal();", true);
        }

        protected void pname3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opendelModal();", true);
        }

        protected void pname4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openseaModal();", true);
        }

        protected void sea_reset_Click(object sender, EventArgs e)
        {
            pname4.Text = null;
            dia4.Text = null;
            len4.Text = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openseaModal();", true);
        }
        string p_name, c_name;
        void getvalues(Int32 p, Int32 c)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            OdbcCommand cmd1 = new OdbcCommand("select cname from Supplier where Cid =" + c + "",con);
            OdbcDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            c_name = dr1.GetString(0);
            dr1.Close();
            String p1 = p.ToString();
            if (p1.Length == 7)
                p1 = p1.Substring(0, 2);
            else
                p1 = p1.Substring(0, 1);
            p = Convert.ToInt32(p1);
            cmd1.CommandText = "select Pname from Pcode where ID=" + p + "";
           OdbcDataReader dr2 = cmd1.ExecuteReader();
            dr2.Read();
            p_name = dr2.GetString(0);
            dr2.Close();
        }
        protected void minavl_Click(object sender, EventArgs e)
        {
            Int32 cid, pid,i=0;
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            OdbcCommand cmd = new OdbcCommand("select Pname,Cname,Diameter,Length,Grade,Plating,Availability,Min_Availability from Product,Supplier where Product.Cid=Suplier.Cid AND Availability <= Min_Availability",con);
            OdbcDataReader dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Company");
            dt.Columns.Add("Diameter");
            dt.Columns.Add("Length");
            dt.Columns.Add("Grade");
            dt.Columns.Add("Plating");
            dt.Columns.Add("Availability");
            dt.Columns.Add("Minimum Availability");
            OdbcCommand cmd1= new OdbcCommand();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    pid = dr.GetInt32(0);
                    cid = dr.GetInt32(1);
                    getvalues(pid, cid);
                    dt.Rows.Add();
                    dt.Rows[i]["Product"] = dr.GetString(0);
                    dt.Rows[i]["Company"] = dr.GetString(1);
                    dt.Rows[i]["Diameter"] = dr.GetInt32(2);
                    dt.Rows[i]["Length"] = dr.GetInt32(3);
                    dt.Rows[i]["Grade"] = dr.GetDouble(4);
                    dt.Rows[i]["Plating"] = dr.GetString(5);
                    dt.Rows[i]["Availability"] = dr.GetInt32(6);
                    dt.Rows[i]["Minimum Availability"] = dr.GetInt32(7);
                    i++;
                    /*htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + p_name+ "</td>");
                    htmlTable.Append("<td>" + c_name + "</td>");
                    /* htmlTable.Append("<td>" +dr["Rid"] + "</td>");
                    htmlTable.Append("<td>" + dr["Part"] + "</td>");
                    htmlTable.Append("<td>" + dr["ISDIN"] + "</td>");*/
                    /* htmlTable.Append("<td>" + dr["Diameter"] + "</td>");
                     htmlTable.Append("<td>" + dr["Length"] + "</td>");
                     htmlTable.Append("<td>" + dr["Grade"] + "</td>");
                     htmlTable.Append("<td>" + dr["Plating"] + "</td>");
                     htmlTable.Append("<td>" + dr["Availability"] + "</td>");
                     // htmlTable.Append("<td>" + dr["Price"] + "</td>");
                     htmlTable.Append("<td>" + dr["Min_Availability"] + "</td>");
                     htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    PlaceHolder2.Controls.Add(new Literal { Text = htmlTable.ToString() });*/
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                       dr.Close();
                       dr.Dispose();
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openminavlModal();", true);
            }
        }

        protected void rep1_deadstk_Click(object sender, EventArgs e)
        {
            Int32 cid, pid,i=0;
            OdbcConnection con = new OdbcConnection("DSN=Project");
            con.Open();
            DateTime fr = Convert.ToDateTime(frm_date1.Text);
            DateTime too = Convert.ToDateTime(to_date1.Text);
            OdbcCommand cmd = new OdbcCommand("select Product.Prcode from Product WHERE NOT EXISTS (select DISTINCT Invoice_Details.Prcode from Invoice_Details,Invoices where Invoice_Details.Invoice_no = Invoices.Invoice_no AND Invoices.Cid=Product.Cid AND Invoices.Order_ID LIKE 'S%' AND Product.Prcode=Invoice_Details.Prcode AND Product.Grade=Invoice_Details.Grade AND Product.Plating=Invoice_Details.Plating AND Invoices.Invoice_Date BETWEEN #" + fr + "# AND #" + too + "#;);", con);
            OdbcDataReader dr = cmd.ExecuteReader();
            OdbcCommand cmd1 = new OdbcCommand();
            // OdbcDataReader dr1;
            while (dr.Read())
            {
                cmd1.CommandText = "select Prcode,Cid,Diameter,Length,Grade,Plating,Availability from Product where Prcode=" + dr.GetInt32(0) + ";";
                cmd1.Connection = con;
                OdbcDataReader dr1 = cmd1.ExecuteReader();
                dt = new DataTable();
                dt.Columns.Add("Product");
                dt.Columns.Add("Company");
                dt.Columns.Add("Diameter");
                dt.Columns.Add("Length");
                dt.Columns.Add("Grade");
                dt.Columns.Add("Plating");
                dt.Columns.Add("Availability");
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        pid = dr1.GetInt32(0);
                        cid = dr1.GetInt32(1);
                        getvalues(pid, cid);
                        dt.Rows.Add();
                        dt.Rows[i]["Product"] = p_name;
                        dt.Rows[i]["Company"] = c_name;
                        dt.Rows[i]["Diameter"] = dr1.GetInt32(2);
                        dt.Rows[i]["Length"] = dr1.GetInt32(3);
                        dt.Rows[i]["Grade"] = dr1.GetDouble(4);
                        dt.Rows[i]["Plating"] = dr1.GetString(5);
                        dt.Rows[i]["Availability"] = dr1.GetInt32(6);
                        i++;
                   /* 
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + p_name + "</td>");
                        htmlTable.Append("<td>" + c_name + "</td>");
                        /* htmlTable.Append("<td>" +dr["Rid"] + "</td>");
                         htmlTable.Append("<td>" + dr["Part"] + "</td>");
                      htmlTable.Append("<td>" + dr["ISDIN"] + "</td>");
                        htmlTable.Append("<td>" + dr1["Diameter"] + "</td>");
                        htmlTable.Append("<td>" + dr1["Length"] + "</td>");
                        htmlTable.Append("<td>" + dr1["Grade"] + "</td>");
                        htmlTable.Append("<td>" + dr1["Plating"] + "</td>");
                        htmlTable.Append("<td>" + dr1["Availability"] + "</td>");*/

                    }
                }
                dr1.Close();
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            dr.Close();
            dr.Dispose();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opendeadstkModal();", true);
        }

        protected void pname13_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openpodModal();", true);
        }

        protected void pname11_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "opensodModal();", true);
        }

        protected void pname6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openupd2Modal();", true);
        }

        protected void pcode5_TextChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openbcdModal();", true);

        }

        void generatetable(GridView gv)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 10f, 0f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        { }

        protected void min_avl_print_Click(object sender, EventArgs e)
        {
            generatetable(GridView1);
        }

        protected void deadstk_print_Click(object sender, EventArgs e)
        {
            generatetable(GridView2);
        }

        protected void party_led_submit_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection("DSN=project2.mdb");
            con.Open();
            DateTime D1 = Convert.ToDateTime(frm_date2.Text);
            DateTime D2 = Convert.ToDateTime(to_date2.Text);
            String cname = company2.SelectedValue;
            OdbcCommand cmd1 = new OdbcCommand();
            cmd1.CommandText = "SELECT Product,SUM(Quantity),SUM(Amount),Cname,MONTH(Order_date) FROM Sales_order,Sales_Details,Supplier WHERE Sales_Details.Order_id=Sales_order.Order_id AND Supplier.Cid=Sales_order.Cid AND Sales_order.Order_date BETWEEN #" + D1 + "# AND #" + D2 + "# AND Supplier.Cname='" + cname +"'GROUP BY MONTH(Order_date),Product,Supplier.Cname;";
            cmd1.Connection = con;
            OdbcDataReader dr = cmd1.ExecuteReader();
            Response.Write("<div class=\"modal\" id=\"party_led_result\" data-show=\"true\">");
            Response.Write("<div class=\"modal-dialog\">");
            Response.Write("<div class=\"modal-content\">");
            Response.Write("<div class=\"modal-header\">");
            Response.Write("<h4>PARTY LEDGER REPORT<button type=\"button\" class=\"close\" data-dismiss=\"modal\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button></h4></div>");
            Response.Write("<div class=\"modal-body\"> ");
            Response.Write("<Table class=\"table table-bordered table-striped\">");
            Response.Write("<tr>");
            Response.Write("<th>Product Name</th>");
            Response.Write("<th>Quantity</th>");
            Response.Write("<th>Amount</th>");
            Response.Write("<th>Company</th>");
            Response.Write("<th>MONTH</th>");
            Response.Write("</tr>");
            while (dr.Read())
            {

                Response.Write("<Tr>");
                Response.Write("<Td>" + dr.GetString(0) + "</td>");
                Response.Write("<Td>" + dr.GetString(1) + "</td>");
                Response.Write("<Td>" + dr.GetString(2) + "</td>");
                Response.Write("<Td>" + dr.GetString(3) + "</td>");
                Response.Write("<Td>" + dr.GetString(4) + "</td>");
                Response.Write("</Tr>");
            }

            Response.Write("</table>");
            Response.Write("</div>");
            Response.Write("<div class=\"modal-footer\" ");
            Response.Write("<asp:button ID=\"party_led_OK\" CssClass=\"btn btn-primary\" runat=\"server\" Text=\"OK\" /> ");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
            dr.Read();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openparty_led_resModal();", true);
        }
    }
}