using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Timers;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;

namespace VisualWorkflowDesktopApp
{
    /// <summary>
    /// TODO: This class will be deleted once FabViewModel is complete.  
    /// 
    /// @author: Alexander James Bochel
    /// @version: 7.10.2017
    /// 
    /// </summary>
    public class OrderViewModel : ObservableCollection<Order>
    {
        public SolidColorBrush brush { get; set; }
        public Timer timer { get; set; }
        int timerCount { get; set; }

        /// <summary>
        /// The constructor currently populates the collection with fake data. 
        /// </summary>
        public OrderViewModel()
        {
            populateCollection();
            timerCount = 0;
            timer = new Timer(500);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // This next line safely removes an item from the observable collection. 
            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => Remove(this[timerCount])));
            changeStatus();

            if (timerCount > 20)
            {
                timer.Enabled = false;
            }

            timerCount++;
        }

        /// <summary>
        /// This method changes the status/color of the box to green. 
        /// </summary>
        public void changeStatus()
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() => this[timerCount].status = 2)); // Change back if I delete the orders
            OnPropertyChanged("status");
            OnPropertyChanged("color");
            OnPropertyChanged("border");
        }

        // This method populates the collection with lead orders and production orders. This method puts fake ones 
        // and will be re-done when the database is connected in order to create the real order collections. 
        public void populateCollection()
        {
            int numLead = 2;

            for (int i = 0; i < numLead; i++)
            {
                LeadOrder leadOrder = new LeadOrder();
                leadOrder.orderNumber = 1234;

                leadOrder.color = new SolidColorBrush(Colors.IndianRed);
                leadOrder.border = new SolidColorBrush(Colors.DarkRed);

                //Add(leadOrder);

                for (int j = 0; j < 5; j++)
                {
                    Order prodOrder = new Order();
                    prodOrder.material = "Material" + j.ToString();
                    prodOrder.orderNumber = j + 10;
                    prodOrder.quantity = 1 + j;

                    prodOrder.color = new SolidColorBrush(Colors.IndianRed);
                    prodOrder.border = new SolidColorBrush(Colors.DarkRed);

                    //Add(prodOrder);
                }
            }

            numLead = 4;

            for (int i = 0; i < numLead; i++)
            {
                LeadOrder leadOrder = new LeadOrder();
                leadOrder.orderNumber = 1234;

                leadOrder.color = new SolidColorBrush(Colors.IndianRed);
                leadOrder.border = new SolidColorBrush(Colors.DarkRed);

                //Add(leadOrder);

                for (int j = 0; j < 10; j++)
                {
                    Order prodOrder = new Order();
                    prodOrder.material = "Material" + j.ToString() + j.ToString();
                    prodOrder.orderNumber = j + 20;
                    prodOrder.quantity = 10 + j;

                    prodOrder.color = new SolidColorBrush(Colors.IndianRed);
                    prodOrder.border = new SolidColorBrush(Colors.DarkRed);

                    Add(prodOrder);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Allows the Order class to notify the UI that a change has occurred. 
        /// </summary>
        /// <param name="propertyName"> Name for the property being changed. </param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
