using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        /*
         * static classes are not instantiated by the outside user (developer/code)
         * static class items are referenced using: classname.xxxx
         * methods within this class have the keyword static in their signature
         * static classes are shared between all outside users at the same time
         * Do not consider saving data within a static class because you cannot be certain
         * it will be there when you use the class again
         * consider placing generic re-usable methods with a static class
         * 
         * sample of a generic method: numeric is a zero or a positive value
         */
        public static bool IsZeroOrPositive(double value)
        {
            /*
             * a structure method (apply to loops, ect) will have a single entry point
             * and a single exit point
             * in this course you will avoid where possible multiple returns from a method
             * in this course you will avoid using a break to exit a loop structure or if structure
             */
            bool valid = true;
            if (value < 0) 
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroOrPositive(int value)
        {
            /*
             * a structure method (apply to loops, ect) will have a single entry point
             * and a single exit point
             * in this course you will avoid where possible multiple returns from a method
             * in this course you will avoid using a break to exit a loop structure or if structure
             */
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
        public static bool IsZeroOrPositive(decimal value)
        {
            /*
             * a structure method (apply to loops, ect) will have a single entry point
             * and a single exit point
             * in this course you will avoid where possible multiple returns from a method
             * in this course you will avoid using a break to exit a loop structure or if structure
             */
            bool valid = true;
            if (value < 0.0m)
            {
                valid = false;
            }
            return valid;
        }
    }
}
