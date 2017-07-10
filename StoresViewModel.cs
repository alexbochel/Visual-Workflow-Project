using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisualWorkflowDesktopApp
{
    /// <summary>
    /// This class stores and manipulates the data in the Stores collection. 
    /// 
    /// @author: Alexander James Bochel
    /// @version: 7.10.2017
    /// 
    /// </summary>
    public class StoresViewModel : ObservableCollection<LeadOrder>
    {
        private int numCollectives;
        private int lineSpacing = 100;
        private int titleHeight = 200;
        
        /// <summary>
        /// This constructor currently fills the collection with fake data.  
        /// </summary>
        public StoresViewModel()
        {
            populate();
        }

        /// <summary>
        /// This method allows the boxes to be resized based on its contents. 
        /// </summary>
        /// <param name="order"> The Main order containing the collective orders to be counted. </param>
        public void findBoxSize(LeadOrder order)
        {
            numCollectives = order.collectiveOrderList.Count();
            order.boxSize = numCollectives * lineSpacing + titleHeight;
        }

        /// <summary>
        /// TODO: This method will be deleted once the database tables are setup. 
        /// </summary>
        public void populate()
        {
            LeadOrder leadingFake = new LeadOrder();
            Order orderFake = new Order();
            LeadOrder fake = new LeadOrder();
            Order pFake = new Order();

            leadingFake.orderNumber = 1234;
            leadingFake.quantity = 12;

            fake.orderNumber = 10;
            fake.quantity = 10;

            leadingFake.color = new SolidColorBrush(Colors.IndianRed);
            leadingFake.border = new SolidColorBrush(Colors.DarkRed);
            orderFake.color = new SolidColorBrush(Colors.GreenYellow);
            orderFake.border = new SolidColorBrush(Colors.Green);
            pFake.color = new SolidColorBrush(Colors.IndianRed);
            pFake.border = new SolidColorBrush(Colors.DarkRed);
            fake.color = new SolidColorBrush(Colors.Yellow);
            fake.border = new SolidColorBrush(Colors.Gold);

            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);
            Add(fake);
            fake.collectiveOrderList.Add(pFake);

            findBoxSize(leadingFake);
            findBoxSize(fake);
        }
    }
}
