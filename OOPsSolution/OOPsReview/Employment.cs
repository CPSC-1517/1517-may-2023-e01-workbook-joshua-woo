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
          // by default sets are a default
          set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                _Title = value;
            } 
        }
        public SupervisoryLevel Level
        { 

        get { return _Level; }

            set
            {
                /*
                 * a private set means that the property can only be set by code within the
                 * class definition
                 * an advantage of doing this is increasing security on the field
                 * as any change is under the control of the class definition
                 * 
                 * validate the value given as an enum is actually defined
                 * 
                 * A user of this class could send in an integer value that was type
                 * cast as this enum datatype BUT have a non defined value
                 * 
                 * to test for a defined enum value use Enum.IsDefined(typeof(xxxx), value)
                 * where xxxx is the name of the enum datatype
                 */
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                throw new ArgumentException($"Supervisory level is invalid: {value}");
                }
                _Level = value;
            } 
        }
        public double Years
        {
            get { return _Years; } // used on the right side of an assignment statement or in an expression
            set
            {
                //if (value < 0) //using a Utilities generic method to do this test
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _Years = value;
            }
            /*
             * this property is an example of an auto-implemented property
             * there is no validation within the property
             * there is no private data member for this property
             * the system will generate an internal storage area for the data
             * and handle the setting and getting from that storage area 
             * the private set means that the property will only be able to be set via constructor or method
             * auto-implemented properties can have either a public or private set
             * using a public or private set is a design decision
             */
        }
        public DateTime StartDate { get; private set; }

        /*
         * Constructors
         * 
         * the purpose of a constructor is to create an instance of your class in a known state
         * 
         * does a class definition need a constructor? No
         * If a class definition does not have a constructor then the system will
         * create the instance and assign the system default value to the data member
         * and/or auto implemented property
         * if you have no constructor the common phrase is "using a system constructor"
         * 
         * 
         * Default Constructor
         * you can apply your own literal values for your data members and/or auto-implemented properties
         * that differ from the system default values
         * why? you may have data that is validated and using the system default values would cause an exception
         * 
         * I you code a constructor in your class you are responsible for all constructors in your class
         */
        public Employment()
        {
            //this constructor will be used o""n creating an instance using
            //Employment myInstance=new Employment ();
            //A practice that I personally use is to avoid reffering my data members directly
            //specifcally if the property contains validation
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Now;  
            /*optionally one could set years to zero but that is the system default
             value for a numeric, therefore one does not need to assign a value
            unless you wish to*/
        }

        //Greedy Constructor
        /*
         * a greedy constructor is on that accepts a parameter list of values to 
         * assign to your instance data on creation of the instance
         * generally your greedy constructor contains a perameter on the signature
         * for each data member you have in your class definition
         */

        /*all optional perameters must appear after non-optional parameters in your parameters list
        in this example we ill use years as an optional parameter
         */
        public Employment(string title, SupervisoryLevel level, DateTime startdate, double years =0.0)
        {
            Title = title;
            Level = level;
            Years = years;
            /*
             *this example to demonstrate where your can place validation for
             *properties have are auto-implemented
             *validation start date must not exist in the future
             *validation can be done anywhere in your class
             *since the property is auto-implemented and has a private set
             *validation can be done in the constructor or a method
             *that alters the property. It would not be an
             *auto-implemented property but a fully implemented property
             *Today has a time of 00.00:000 AM
             *.Now has a specific time of day execution 18
             */
        }
    }
}