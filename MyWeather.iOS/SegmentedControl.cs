using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyWeather.iOS
{
    [Register("SegmentedControl")]
    public class SegmentedControl : UIKit.UISegmentedControl
    {
         
        public SegmentedControl(params string[] options) 
            : base()
        {
            for(int i = 0; i < options.Length; i++)
            {
                InsertSegment(options[i], i, false);
            }
            SelectedIndex = 0;
            ValueChanged += (s, e) =>
            {
                SelectedIndex = (int)SelectedSegment;
            };
        }
       

        int index;
        /// <summary>
        /// Border thickness of circle image
        /// </summary> 
		[Export("selectedindex")]
        public int SelectedIndex
        {
 			get 
 			{ 
 				return index; 
			} 
 			set 
 			{ 
 				WillChangeValue("selectedindex");
                index = value;
                SelectedSegment = value;
                DidChangeValue("selectedindex");
            } 
 		} 

    }
}
