using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace VisualWorkflowDesktopApp
{
    /// <summary>
    /// This class is the "Main" order. It contains in it in each instance a list of collective orders
    /// that is required to complete the lead order. 
    /// 
    /// @author: Alexander James Bochel
    /// @version: 7.10.2017
    /// 
    /// </summary>
    public class LeadOrder : Order
    {
        /// <summary>
        /// Holds collective orders within each Main order. 
        /// </summary>
        public List<Order> collectiveOrderList { get; set; }
        
        /// <summary>
        /// To determine the size of the box in the view. 
        /// </summary>
        public double boxSize { get; set; }

        /// <summary>
        /// Determines how big the boxes have to be in the View. 
        /// </summary>
        public LeadOrder()
        {
            collectiveOrderList = new List<Order>();
        }
    }
}
