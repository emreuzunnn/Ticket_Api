namespace api.Controllers
{
    using api.Models;
    using Microsoft.Data.SqlClient;

    public class databaseController
    {

        SqlConnection bag = new SqlConnection("Server=EMRE;Database=Ticket;Trusted_Connection=True; TrustServerCertificate=True;");
        SqlCommand cmd = new SqlCommand();
        public databaseController() { 
        cmd.Connection = bag;

        
        }
        public void add_cards(peoplecards Card)
        {
           
            
                bag.Open();
                cmd.CommandText = "insert into kartlar (cardno,cardtur,bakiye,adsoyad,tckmlik)values('" + Card.cardno + "','" + Card.cardtype + "',"+Card.total_money.ToString().Replace(',','.')+",'" + Card.frist_last_name + "','" + Card.tc_kimlik + "')";
                cmd.ExecuteNonQuery();
                bag.Close();
              

            

        }
        public peoplecards cards_query(string tckimlik)
        {bag.Open();
            cmd.CommandText = "select * from kartlar where tckmlik='" + tckimlik+"'";
            SqlDataReader reader=cmd.ExecuteReader();
  
            peoplecards retur_cards= new peoplecards();
            while (reader.Read()) {

                retur_cards.cardno = reader[0].ToString();
                retur_cards.cardtype = reader[1].ToString();
                retur_cards.total_money = double.Parse(reader[2].ToString());
                retur_cards.frist_last_name = reader[3].ToString();
                retur_cards.tc_kimlik = reader[4].ToString();

            }
            reader.Close();
            bag.Close();
           return retur_cards;
        }


        
    }
}
