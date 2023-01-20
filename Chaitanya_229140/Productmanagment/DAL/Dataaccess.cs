namespace Productmanagment .DAl;
using Productmanagment.Model;
using MySql.Data.MySqlClient;


public class Dataaccess{

    public static string conststring=@"server=localhost; port=3306; user=root; password=root123; database=productinfo";


    public static List<Product> Getallproduct()
    {
        List<Product> prd=new List<Product>();


        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conststring;

        try{
            con.Open();
            string query="select * from product";

            MySqlCommand cmd=new MySqlCommand(query,con);
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                string name=reader["title"].ToString();
                string des=reader["description"].ToString();
                double price= double.Parse(reader["unitprice"].ToString());
                double  bal=double.Parse(reader["balance"].ToString());

                Product prod=new Product{
                           title =name,
                           description=des,
                           unitprice=price,
                           balance= bal
                   };

                prd.Add(prod);

            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        return prd;
    }

    public static void Update(Product prd,double bal)
    {
         MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conststring;

        try{
            con.Open();
            string query=$"update product set title='{prd.title}',description='{prd.description}', unitprice='{prd.unitprice} where balance={bal}";
            MySqlCommand cmd= new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();

        }catch(Exception e)

        {
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }

    }
    public static void Insert(Product prd)
    {
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conststring;

        try{
            con.Open();
            string query=$" insert into product values('{prd.title}','{prd.description}','{prd.unitprice}','{prd.balance}')";
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();

        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
    }


}