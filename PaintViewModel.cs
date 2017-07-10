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
    /// This class implements the logic for the Paint View. It holds a collection of Main orders and displays the
    /// collective orders within each one. 
    /// 
    /// @author: Alexander James Bochel
    /// @version: 7.10.2017
    /// 
    /// </summary>
    public class PaintViewModel : ObservableCollection<LeadOrder>
    {
        private int numCollectives;
        private int lineSpacing = 100;
        private int titleHeight = 200;

        /// <summary>
        /// This constructor currently fills the collection with fake data. 
        /// </summary>
        public PaintViewModel()
        { 
            populate();
        }

        /// <summary>
        /// Finds the necessary height of the box for the UI based on how many collective orders 
        /// are with the Main order. 
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
            Order orderDone = new Order();

            leadingFake.color = new SolidColorBrush(Colors.IndianRed);
            leadingFake.border = new SolidColorBrush(Colors.DarkRed);
            orderDone.status = 0;
            leadingFake.quantity = 20;
            leadingFake.orderNumber = 48327243859;
            
            orderDone.color = new SolidColorBrush(Colors.GreenYellow);
            orderDone.border = new SolidColorBrush(Colors.DarkGreen);

            orderFake.border = new SolidColorBrush(Colors.DarkRed);

            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);
            leadingFake.collectiveOrderList.Add(orderDone);
            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);
            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);
            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);
            Add(leadingFake);
            leadingFake.collectiveOrderList.Add(orderFake);

            findBoxSize(leadingFake);
        }
    }
}
