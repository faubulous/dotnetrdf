/*
dotNetRDF is free and open source software licensed under the MIT License

-----------------------------------------------------------------------------

Copyright (c) 2009-2015 dotNetRDF Project (dotnetrdf-develop@lists.sf.net)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is furnished
to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using VDS.RDF.Specifications;

namespace VDS.RDF.Compatibility
{
#if SILVERLIGHT
    public static class SilverlightIOCompatibility
    {
        public static bool IsHexEncoding(String value, int index)
        {
            if (index + 2 >= value.Length) return false;
            return value[0] == '%' && TurtleSpecsHelper.IsHex(value[1]) && TurtleSpecsHelper.IsHex(value[2]);
        }

        public static char HexUnescape(String value, ref int index)
        {
            if (index + 2 >= value.Length) throw new ArgumentException("Malformed Percent Encoded Escape");
            if (value[index] != '%') throw new ArgumentException("Malformed Percent Encoded Escape");
            index = index + 3;
            return UnicodeSpecsHelper.ConvertToChar(value.Substring(index + 1, 2));
        }
    }
#endif
}