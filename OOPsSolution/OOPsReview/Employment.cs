using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        private SupervisoryLevel _Level;
        private string _Title;  //add a ? for a nullable field (may become standard later on)
        private double _Years;

        /*<Summary>
         * Properties
         * are associated with a single piece of data
         * Properties can be implemented by:
         *      a) fully implemented properties
         *      b) auto implemented properties
         *      fully implemented property usually has additional logic to execute for 
         *      the control over the data; such as validation
         *Fully implemented properties will have a declared data member to store the data
         *
         *Auto implemented properties do not have additional logic
         *Auto implemented properties do not have a declared data member to store data
         *instead the o/s will create on the property's behave a storage area that is
         *accessable ONLY by using the property
         *
         * Property: Title
         * validation: there must be a character string 
         * a property will always have an accessor (get)
         * a property may or may not have a mutator
         *  no mutator the property is considered "read only" and is usually returning a computed value
         *  Example: a FullName is made up of 2 pieces of data FirstName and LastName
         *  has a mutator the property will at some point save the data to storage
         *  the mutator may be public may be public (default or private)
         *      public: accessable only by outside users of the class
         *      private: acessable ONLY within the class
         *      
         *      a property does not have any declare incoming paramenter list
         */

        public string Title
            //referred to as the accessor
            //returns the string associated with this property
        { get { return _Title; } 
          //referred to as the mutator
          //it is within the set that the validation of the data
          //is done to determine if the data is acceptable
          set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                _Title = value;
            } 
        }
    }
}