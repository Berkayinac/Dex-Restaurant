using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WhyChooseOurRestaurant();
        }

        public void WhyChooseOurRestaurant()
        {
            lbl_WhyChooseOurRestaurantV1.Text = "Erdemlilik";
            lbl_WhyChooseOurRestaurantDescriptionV1.Text = "Biraz risk olmadan hayatın ne tadı olur?";

            lbl_WhyChooseOurRestaurantV2.Text = "Sadakat";
            lbl_WhyChooseOurRestaurantDescriptionV2.Text = "Asa sihirbazı seçer Bay Potter";

            lbl_WhyChooseOurRestaurantV3.Text = "Aydınlık";
            lbl_WhyChooseOurRestaurantDescriptionV3.Text = "Mutluluk en karanlık zamanlarda bile vardır. Yeter ki ışığı açmayı unutmayın.";
        }
    }
}