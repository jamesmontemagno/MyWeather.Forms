using Foundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeather.iOS
{
    [Register("KVOSegmentedControl")]
    public class KVOSegmentedControl : UIKit.UISegmentedControl
    {
        public KVOSegmentedControl(string option1, string option2) 
            : base(new []{ option1, option2})
        {
            KVOSelected = 0;
        }

        int _kVOValue; 
		[Export("kvoselected")] 
 		public int KVOSelected 
 		{ 
 			get 
 			{ 
 
 
 				return _kVOValue; 
			} 
 			set 
 			{ 
 
 
 				WillChangeValue(nameof(KVOSelected).ToLower());
                SelectedSegment = value;
 				_kVOValue = value; 
				DidChangeValue(nameof(KVOSelected).ToLower()); 
			} 
 		} 

    }
}
