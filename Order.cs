using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace VisualWorkflowDesktopApp
{
    /// <summary>
    /// This model class contains information regarding every order that is processed in the factory. 
    /// 
    /// @author: Alexander James Bochel
    /// @version: 7.10.2017
    /// 
    /// </summary>
    public class Order : INotifyPropertyChanged
    {

        private long _orderNumber;
        private string _material;
        private int _quantity;
        private SolidColorBrush _color;
        private SolidColorBrush _border;
        private int _status;

        /// <summary>
        /// Getter/Setter: Identification of the collective and main orders. 
        /// </summary>
        public long orderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }

        /// <summary>
        /// Getter/Setter: The material in which the specific order is made out of. 
        /// </summary>
        public string material
        {
            get { return _material; }
            set { _material = value; }
        }

        /// <summary>
        /// Getter/Setter: The amount needed of each order. 
        /// </summary>
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        /// <summary>
        /// Getter/Setter: Background color of the Order box. 
        /// </summary>
        public SolidColorBrush color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Getter/Setter: Border color of the Order box. 
        /// </summary>
        public SolidColorBrush border
        {
            get { return _border; }
            set { _border = value; }
        }

        /// <summary>
        /// Getter/Setter: Current status of the part in the factory. If the status changes so do the colors of the Order 
        /// and the UI is notified.  
        /// 0: Red - Not started
        /// 1: Yellow - In process
        /// 2: Green - Finished
        /// </summary>
        public int status
        {
            get { return _status; }
            set
            {
                _status = value;
                
                if (_status == 2)
                {
                    color = new SolidColorBrush(Colors.GreenYellow);
                    border = new SolidColorBrush(Colors.Green);
                    OnPropertyChanged("status");
                    OnPropertyChanged("color");
                    OnPropertyChanged("border");
                }
                else if (_status == 1)
                {
                    color = new SolidColorBrush(Colors.Yellow);
                    border = new SolidColorBrush(Colors.Gold);
                    OnPropertyChanged("status");
                    OnPropertyChanged("color");
                    OnPropertyChanged("border");
                }
                else
                {
                    color = new SolidColorBrush(Colors.Red);
                    border = new SolidColorBrush(Colors.DarkRed);
                    OnPropertyChanged("status");
                    OnPropertyChanged("color");
                    OnPropertyChanged("border");
                }
            }
        }

        /// <summary>
        /// Default constructor sets the status to false upon creation. 
        /// </summary>
        public Order()
        {
            _status = 0;
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
