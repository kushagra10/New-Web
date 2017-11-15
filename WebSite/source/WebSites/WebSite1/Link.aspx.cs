using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Link : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
        {
            // Query string value is there so now use it
            var cid = Request.QueryString["ID"];
            Label1.Text = "welcome" + cid;
        }

        var id = Convert.ToString(Request.QueryString["ID"]);


        SqlConnection conn = null;
        /*double val = 0;*/
        string server = "tcp:candidate-test-data.database.windows.net,1433";
        string dbase = "candidate-test-data-source";
        string userid = "candidate";
        string password = "UGOgxXN06GNbY80Oi9KqoKJETgOY5tiV";
        string connection = "Data Source=" + server + ";Initial Catalog=" + dbase
                            + ";User ID=" + userid + ";Password=" + password;

        conn = new SqlConnection(connection);

        conn.Open();
        
        
        SqlDataReader myReader = null;
        

        SqlCommand myCommand = new SqlCommand("SELECT Customer.CustomerID, Customer.FirstName COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, Product.ProductID, Product.Name COLLATE SQL_Latin1_General_CP1_CI_AS AS Product_Name, Product.ProductNumber, Product.Color, Product.StandardCost, Product.Size, Product.Weight, Product.ThumbNailPhoto FROM SalesLT.SalesOrderDetail INNER JOIN SalesLT.Product ON SalesOrderDetail.ProductID = Product.ProductID INNER JOIN SalesLT.SalesOrderHeader ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID INNER JOIN SalesLT.Customer ON SalesOrderHeader.CustomerID = Customer.CustomerID WHERE SalesLT.Customer.CustomerID = @zip", conn);

        myCommand.Parameters.AddWithValue("@zip", id);


        
        

        myReader = myCommand.ExecuteReader();

        /*SqlDataReader reader = SqlCommand.ExecuteReader();*/
        GridView1.DataSource = myReader;
        GridView1.DataBind();

        myReader.Close(); // <- too easy to forget
        myReader.Dispose(); // <- too easy to forget


        SqlDataReader myReader2 = null;
        SqlCommand myCommand2 = new SqlCommand("SELECT TOP 5 COUNT(SalesOrderDetail.ProductID) AS Count, SalesOrderDetail.ProductID, SalesLT.Product.Name FROM SalesLT.Product INNER JOIN SalesLT.ProductCategory ON Product.ProductCategoryID = ProductCategory.ProductCategoryID INNER JOIN SalesLT.SalesOrderDetail ON Product.ProductID = SalesOrderDetail.ProductID INNER JOIN SalesLT.SalesOrderHeader ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID WHERE SalesLT.SalesOrderHeader.CustomerID = @z GROUP BY SalesOrderDetail.ProductID, SalesLT.Product.Name ORDER BY SalesOrderDetail.ProductID, SalesLT.Product.Name", conn);

        myCommand2.Parameters.AddWithValue("@z", id);
        
        myReader2 = myCommand2.ExecuteReader();

        /*SqlDataReader reader = SqlCommand.ExecuteReader();*/
        GridView2.DataSource = myReader2;
        GridView2.DataBind();

        myReader2.Close(); // <- too easy to forget
        myReader2.Dispose(); // <- too easy to forget


        







    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var id = Convert.ToString(Request.QueryString["ID"]);


        SqlConnection conn = null;
        /*double val = 0;*/
        string server = "tcp:candidate-test-data.database.windows.net,1433";
        string dbase = "candidate-test-data-source";
        string userid = "candidate";
        string password = "UGOgxXN06GNbY80Oi9KqoKJETgOY5tiV";
        string connection = "Data Source=" + server + ";Initial Catalog=" + dbase
                            + ";User ID=" + userid + ";Password=" + password;

        conn = new SqlConnection(connection);

        conn.Open();


        SqlDataReader myReader = null;


        SqlCommand myCommand = new SqlCommand("SELECT Customer.CustomerID, Customer.FirstName COLLATE SQL_Latin1_General_CP1_CI_AS AS Expr1, Product.ProductID, Product.Name COLLATE SQL_Latin1_General_CP1_CI_AS AS Product_Name, Product.ProductNumber, Product.Color, Product.StandardCost, Product.Size, Product.Weight, Product.ThumbNailPhoto FROM SalesLT.SalesOrderDetail INNER JOIN SalesLT.Product ON SalesOrderDetail.ProductID = Product.ProductID INNER JOIN SalesLT.SalesOrderHeader ON SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID INNER JOIN SalesLT.Customer ON SalesOrderHeader.CustomerID = Customer.CustomerID WHERE SalesLT.Customer.CustomerID = @zip", conn);

        myCommand.Parameters.AddWithValue("@zip", id);


        /*Getting JSON file*/
        DataTable dt = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(myCommand);
        da.Fill(dt);

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        Dictionary<string, object> row;

        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        string jsondata = serializer.Serialize(rows);

        string path = "C:\\Users\\Public\\" + id + ".json";

        System.IO.File.WriteAllText(@path, jsondata);

    


        /*JSON part ends here. var jsondata contains json data*/


        myReader = myCommand.ExecuteReader();

        /*SqlDataReader reader = SqlCommand.ExecuteReader();*/
        GridView1.DataSource = myReader;
        GridView1.DataBind();
    }

    
}

