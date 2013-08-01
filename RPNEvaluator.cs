/*
    Copyright (C) 2013 Bartosz Kazmierczak
    
    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation; either version 2 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    public delegate void Function(Stack<double> stack);
    public interface IPlugin
    {
        void LoadFunctions(Dictionary<String, Function> dictionary);
    }
    static class RPNEvaluator
    {
        private static Dictionary<String, Function> functions = ListFunctions();

        public static void Evaluate(String expression, Stack<double> stack)
        {
            if (expression == String.Empty) return;
            String[] parts = expression.Split(' ');
            foreach (String part in parts)
            {
                if (part == String.Empty) continue;
                double num = 0;
                if (double.TryParse(part, out num))
                {
                    stack.Push(num);
                }
                else if (part == "e")
                {
                    stack.Push(Math.E);
                }
                else if (part == "pi")
                {
                    stack.Push(Math.PI);
                }
                else
                {
                    Function function = functions[part];
                    if (function == null)
                        throw new Exception("Unknown expression \"" + part + "\"");
                    function(stack);
                }
            }
        }

        private static Dictionary<String, Function> ListFunctions()
        {
            Dictionary<String, Function> dict = new Dictionary<String, Function>();

            dict.Add("+", new Function(add));
            dict.Add("-", new Function(subtract));
            dict.Add("*", new Function(multiply));
            dict.Add("/", new Function(divide));
            dict.Add("^", new Function(power));
            dict.Add("pow", new Function(power));
            dict.Add("%", new Function(mod));
            dict.Add("mod", new Function(mod));

            dict.Add("root", new Function(root));
            dict.Add("sqrt", new Function(sqrt));
            dict.Add("log", new Function(log));
            dict.Add("abs", new Function(abs));
            dict.Add("sgn", new Function(sgn));

            dict.Add("sin", new Function(sin));
            dict.Add("cos", new Function(cos));
            dict.Add("tg", new Function(tg));
            dict.Add("ctg", new Function(ctg));
            dict.Add("sec", new Function(sec));
            dict.Add("csc", new Function(csc));

            dict.Add("dup", new Function(dup));
            dict.Add("swap", new Function(swap));
            dict.Add("pop", new Function(pop));

            foreach (string path in System.IO.Directory.GetFiles("./plugins", "*.dll"))
            {
                try
                {
                    Assembly assembly = System.Reflection.Assembly.LoadFrom(path);
                    Type[] types = assembly.GetTypes();
                    Type plugin = null;
                    bool moreThanOnePlugin = false;
                    foreach (Type type in types)
                    {
                        if (type.GetInterface("RPNCalculator.IPlugin") == null)
                            continue;
                        if (plugin != null)
                        {
                            moreThanOnePlugin = true;
                            break;
                        }
                        plugin = type;
                    }
                    if (moreThanOnePlugin)
                    {
                        System.Windows.Forms.MessageBox.Show(String.Format("Plugin {0} contains more than one plugin core class. Skipping.", path));
                        continue;
                    }
                    if (plugin == null)
                    {
                        System.Windows.Forms.MessageBox.Show(String.Format("Plugin {0} does not contain a core plugin class. Skipping.", path));
                        continue;
                    }
                    MethodInfo loader = plugin.GetMethod("LoadFunctions");
                    
                    ConstructorInfo constructor = plugin.GetConstructor(new Type[0]);
                    IPlugin pluginInstance = (IPlugin)constructor.Invoke(new object[0]);
                    loader.Invoke(pluginInstance, new object[1] { dict });
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Loading plugin \"" + path + "\" failed.\n\n" + e.ToString());
                    continue;
                }
            }

            return dict;
        }

#region Basic Math
        public static void add(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(num1 + num2);
        }
        public static void subtract(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(num1 - num2);
        }
        public static void multiply(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(num1 * num2);
        }
        public static void divide(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            if (num2 == 0)
                throw new DivideByZeroException();
            stack.Push(num1 / num2);
        }
        public static void power(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(Math.Pow(num1, num2));
        }
        public static void mod(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            if (num2 == 0)
                throw new DivideByZeroException();
            stack.Push(num1 % num2);
        }
#endregion

#region Basic Functions
        public static void root(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(Math.Pow(num1, (1D / num2)));
        }
        public static void sqrt(Stack<double> stack)
        {
            double num1 = stack.Pop();
            stack.Push(Math.Sqrt(num1));
        }
        public static void log(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(Math.Log(num1, num2));
        }
        public static void abs(Stack<double> stack)
        {
            double num1 = stack.Pop();
            stack.Push(num1 >= 0 ? num1 : -num1);
        }
        public static void sgn(Stack<double> stack)
        {
            double num1 = stack.Pop();
            stack.Push(num1 > 0 ? 1 : num1 < 0 ? -1 : 0);
        }
#endregion

#region Trigonometry
        public static void sin(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(Math.Sin(num1));
        }
        public static void cos(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(Math.Cos(num1));
        }
        public static void tg(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(Math.Tan(num1));
        }
        public static void ctg(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(1D / Math.Tan(num1));
        }
        public static void sec(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(1D / Math.Cos(num1));
        }
        public static void csc(Stack<double> stack)
        {
            double num1 = stack.Pop();
            if (RPNCalculator.Properties.Settings.Default.AngleUnit == (byte)AngleUnit.Degree)
                num1 *= Math.PI / 180D;
            stack.Push(1D / Math.Sin(num1));
        }
#endregion

#region Stack Operations
        public static void dup(Stack<double> stack)
        {
            stack.Push(stack.Peek());
        }
        public static void swap(Stack<double> stack)
        {
            double num1 = stack.Pop();
            double num2 = stack.Pop();
            stack.Push(num1);
            stack.Push(num2);
        }
        public static void pop(Stack<double> stack)
        {
            stack.Pop();
        }
#endregion
    }
}
